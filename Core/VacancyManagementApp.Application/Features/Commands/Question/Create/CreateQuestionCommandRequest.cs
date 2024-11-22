using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.Question;

namespace VacancyManagementApp.Application.Features.Commands.Question.Create
{
    public class CreateQuestionCommandRequest:IRequest<CreateQuestionCommandResponse>
    {
        public string Description { get; set; }
        public Guid VacancyId { get; set; }
    }
}
