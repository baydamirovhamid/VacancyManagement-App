using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Queries.GetByIdVacancy
{
    public class GetByIdVacancyQueryRequest:IRequest<GetByIdVacancyQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
