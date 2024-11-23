using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.ApplicationForm;
using VacancyManagementApp.Application.DTOs.User;
using VacancyManagementApp.Application.Features.Queries.GetAllUser;

namespace VacancyManagementApp.Application.Features.Queries.GetAllApplicationForm
{
    public class GetAllApplicationFormQueryHandler : IRequestHandler<GetAllApplicationFormQueryRequest, GetAllApplicationFormQueryResponse>
    {
        private readonly IApplicationFormService _applicationFormService;
        private readonly IMapper _mapper;

        public GetAllApplicationFormQueryHandler(IApplicationFormService applicationFormService, IMapper mapper)
        {
            _applicationFormService = applicationFormService;
            _mapper = mapper;
        }

        public async Task<GetAllApplicationFormQueryResponse> Handle(GetAllApplicationFormQueryRequest request, CancellationToken cancellationToken)
        {
            var entities = await _applicationFormService.GetAllApplicationForm();
            var response = new GetAllApplicationFormQueryResponse();
            var getAllApplicationFormDto = _mapper.Map<List<GetAllApplicationFormDto>>(entities);
            response.GetAllApplicationForm = getAllApplicationFormDto;
            return response;
        }
    }
}
