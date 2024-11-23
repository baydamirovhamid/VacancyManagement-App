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
            var createApplicationFormDto = _mapper.Map<CreateApplicationFormDto>(request);
            var dto = await _applicationFormService.CreateApplicationFormAsync(createApplicationFormDto);
            var response = _mapper.Map<CreateApplicationFormCommandResponse>(dto);
            return response;
        }
    }
}
