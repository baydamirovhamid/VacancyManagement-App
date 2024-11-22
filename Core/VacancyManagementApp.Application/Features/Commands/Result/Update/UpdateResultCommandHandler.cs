using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Result;

namespace VacancyManagementApp.Application.Features.Commands.Result.Update
{
    public class UpdateResultCommandHandler : IRequestHandler<UpdateResultCommandRequest, UpdateResultCommandResponse>
    {
        private readonly IResultService _resultService;
        private readonly IMapper _mapper;

        public UpdateResultCommandHandler(IResultService resultService, IMapper mapper)
        {
            _resultService = resultService;
            _mapper = mapper;
        }

        async Task<UpdateResultCommandResponse> IRequestHandler<UpdateResultCommandRequest, UpdateResultCommandResponse>.Handle(UpdateResultCommandRequest request, CancellationToken cancellationToken)
        {
            var dto =  _mapper.Map<UpdateResultDto>(request);
            var response =await _resultService.UpdateResultAsync(dto);
            return _mapper.Map<UpdateResultCommandResponse>(response);
        }
    }
}
