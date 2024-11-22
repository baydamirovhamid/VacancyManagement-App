using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Answer;
using VacancyManagementApp.Application.Repositories;

namespace VacancyManagementApp.Application.Features.Commands.Answer.Create
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommandRequest, CreateAnswerCommandResponse>
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;
        public CreateAnswerCommandHandler(IMapper mapper, IAnswerService answerService)
        {
            _mapper = mapper;
            _answerService = answerService;
        }

        public async Task<CreateAnswerCommandResponse> Handle(CreateAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var createAnswerDto = _mapper.Map<CreateAnswerDto>(request);
            var responseDto = await _answerService.CreateAnswerAsync(createAnswerDto);
            return _mapper.Map<CreateAnswerCommandResponse>(responseDto);
        }
    }
}
