using AutoMapper;
using MediatR;
using VacancyManagementApp.Application.Abstractions.Services;

namespace VacancyManagementApp.Application.Features.Queries.GetAllQuestions
{
    public class GetAllQuestionQueryHandler : IRequestHandler<GetAllQuestionQueryRequest, GetAllQuestionQueryResponse>
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        public GetAllQuestionQueryHandler(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        public async Task<GetAllQuestionQueryResponse> Handle(GetAllQuestionQueryRequest request, CancellationToken cancellationToken)
        {
            var getAllDto =  _questionService.GetAllQuestion();
            var responseDto =new GetAllQuestionQueryResponse();
            responseDto.GetAllQuestionDtos = getAllDto;
            return responseDto;
        }
    }
}
