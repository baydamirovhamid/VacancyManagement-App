using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Queries.GetAllQuestions
{
    public class GetAllQuestionQueryRequest:IRequest<GetAllQuestionQueryResponse>
    {
    }
}
