using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Answer;

namespace VacancyManagementApp.Application.Features.Commands.Answer.Update
{
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommandRequest, UpdateAnswerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnswerService _answerService;

        public UpdateAnswerCommandHandler(IMapper mapper, IAnswerService answerService)
        {
            _mapper = mapper;
            _answerService = answerService;
        }

        public async Task<UpdateAnswerCommandResponse> Handle(UpdateAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var updateAnswerDto = _mapper.Map<UpdateAnswerDto>(request);

            var dto = await _answerService.UpdateAnswerAsync(updateAnswerDto);

            var response = _mapper.Map<UpdateAnswerCommandResponse>(dto);

            return response;
        }
    }
}
