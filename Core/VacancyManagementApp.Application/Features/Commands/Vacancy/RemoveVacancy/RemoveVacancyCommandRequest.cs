using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Commands.Vacancy.RemoveVacancy
{
    public class RemoveVacancyCommandRequest: IRequest<RemoveVacancyCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
