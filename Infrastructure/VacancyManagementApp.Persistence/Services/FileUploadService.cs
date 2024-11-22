using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.File;
using VacancyManagementApp.Application.Repositories;

namespace VacancyManagementApp.Persistence.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string _fileSavePath = "wwwroot/uploads";
        private readonly IFileUploadReadRepository _readRepository;
        private readonly IMapper _mapper;

        public FileUploadService(IFileUploadReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<GetFileByOwnerDto> GetById(Guid id)
        {
          var entity= _readRepository.GetByIdAsync(id);
            return _mapper.Map<GetFileByOwnerDto>(entity);
        }

        public string GetValidFileExtension(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName).ToLower();
            if (extension == ".pdf" || extension == ".docx")
            {
                return extension;
            }
            return null;
        }

        public bool IsFileSizeValid(IFormFile file, long maxSize)
        {
            return file.Length <= maxSize;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string fileName)
        {
            if (!Directory.Exists(_fileSavePath))
            {
                Directory.CreateDirectory(_fileSavePath);
            }

            var filePath = Path.Combine(_fileSavePath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
