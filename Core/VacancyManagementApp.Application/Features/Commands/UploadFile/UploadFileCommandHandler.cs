using MediatR;
using Microsoft.AspNetCore.Identity;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Domain.Entities.Identity;

namespace VacancyManagementApp.Application.Features.Commands.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommandRequest, UploadFileCommandResponse>
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly IFileUploadWriteRepository _fileUploadWriteRepository;
       private readonly IApplicationFormReadRepository _applicationFormReadRepository;

        public UploadFileCommandHandler(IFileUploadService fileUploadService,
            IFileUploadWriteRepository fileUploadWriteRepository,
            UserManager<Domain.Entities.Identity.AppUser> userManager,
            IApplicationFormReadRepository applicationFormReadRepository)
        {
            _fileUploadService = fileUploadService;
            _fileUploadWriteRepository = fileUploadWriteRepository;
            _applicationFormReadRepository = applicationFormReadRepository;
        }

        public async Task<UploadFileCommandResponse> Handle(UploadFileCommandRequest request, CancellationToken cancellationToken)
        {
            var extension = _fileUploadService.GetValidFileExtension(request.File);
            if (extension == null)
            {
                return new UploadFileCommandResponse { Success = false, Message = "Invalid file extension (.pdf, .docx only)." };
            }

            if (!_fileUploadService.IsFileSizeValid(request.File, 5 * 1024 * 1024))
            {
                return new UploadFileCommandResponse { Success = false, Message = "Maximum file size is 5MB." };
            }

            string fileName = Guid.NewGuid() + extension;
            var form=await _applicationFormReadRepository.GetByIdAsync(request.ApplicationFormId);
            string filePath = await _fileUploadService.SaveFileAsync(request.File, fileName,form.Email );

            var uploadedFile = new UploadedFile
            {
                FileName = fileName,
                FilePath = filePath,
                FileSize = request.File.Length,
                ApplicationFormId=form.Id
            };

            await _fileUploadWriteRepository.AddAsync(uploadedFile);
            await _fileUploadWriteRepository.SaveAsync();

            return new UploadFileCommandResponse { Success = true, FileName = fileName, Message = "File uploaded successfully." };
        }
    }
}
