using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Queries.GetPaginatedQuestion
{
    public class GetPaginatedQuestionQueryRequest : IRequest<GetPaginatedQuestionQueryResponse>
    {
        public int Page { get; set; } = 1; 
        public Guid VacancyId { get; set; }
    }

}
