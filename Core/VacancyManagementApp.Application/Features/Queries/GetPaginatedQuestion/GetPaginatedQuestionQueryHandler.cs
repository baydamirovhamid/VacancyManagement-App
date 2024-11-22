using MediatR;
using Microsoft.EntityFrameworkCore;
using VacancyManagementApp.Application.DTOs.Question;
using VacancyManagementApp.Application.Repositories;

namespace VacancyManagementApp.Application.Features.Queries.GetPaginatedQuestion
{
    public class GetPaginatedQuestionQueryHandler : IRequestHandler<GetPaginatedQuestionQueryRequest, GetPaginatedQuestionQueryResponse>
    {
        private readonly IQuestionReadRepository _questionReadRepository;

        public GetPaginatedQuestionQueryHandler(IQuestionReadRepository questionReadRepository)
        {
            _questionReadRepository = questionReadRepository;
        }

        public async Task<GetPaginatedQuestionQueryResponse> Handle(GetPaginatedQuestionQueryRequest request, CancellationToken cancellationToken)
        {
           
            var question = await _questionReadRepository.GetWhere(q => q.VacancyId == request.VacancyId)
                .Skip((request.Page - 1) * 1) 
                .Take(1)
                .Select(q => new QuestionDto
                {
                    Description = q.Description,
                    Answers = q.Answers.Select(a => new AnswerDto
                    {
                        AnswerText = a.Name,
                        IsCorrect = a.IsCorrect
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return new GetPaginatedQuestionQueryResponse
            {
                Question = question
            };
        }
    }
}
