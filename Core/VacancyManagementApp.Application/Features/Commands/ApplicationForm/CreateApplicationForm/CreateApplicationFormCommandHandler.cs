using AutoMapper;
using MediatR;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.ApplicationForm;

namespace VacancyManagementApp.Application.Features.Commands.ApplicationForm.CreateApplicationForm
{
    public class CreateApplicationFormCommandHandler : IRequestHandler<CreateApplicationFormCommandRequest, CreateApplicationFormCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationFormService _applicationFormService;

        public CreateApplicationFormCommandHandler(IMapper mapper, IApplicationFormService applicationFormService)
        {
            _mapper = mapper;
            _applicationFormService = applicationFormService;
        }

        public async Task<CreateApplicationFormCommandResponse> Handle(CreateApplicationFormCommandRequest request, CancellationToken cancellationToken)
        {
            // Map the command request to the DTO
            var createApplicationFormDto = _mapper.Map<CreateApplicationFormDto>(request);

            // Call the service method and get the result DTO
            var dto = await _applicationFormService.CreateApplicationFormAsync(createApplicationFormDto);

            // Map the result DTO to the response model
            var response = _mapper.Map<CreateApplicationFormCommandResponse>(dto);

            return response;
        }
    }
}
