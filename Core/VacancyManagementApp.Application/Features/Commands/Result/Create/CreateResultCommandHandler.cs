using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Result;

namespace VacancyManagementApp.Application.Features.Commands.Result.Create
{
    public class CreateResultCommandHandler : IRequestHandler<CreateResultCommandRequest, CreateResultCommandResponse>
    {
        private readonly IResultService _resultService;
        private readonly IMapper _mapper;

        public CreateResultCommandHandler(IResultService resultService, IMapper mapper)
        {
            _resultService = resultService;
            _mapper = mapper;
        }
        public async Task<CreateResultCommandResponse> Handle(CreateResultCommandRequest request, CancellationToken cancellationToken)
        {
            var createDto = _mapper.Map<ResultCreateDto>(request);
            var responseDto = await _resultService.CreateResultAsync(createDto);
            return _mapper.Map<CreateResultCommandResponse>(responseDto);
        }
    }
}
