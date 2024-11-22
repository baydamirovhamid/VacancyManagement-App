using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Commands.Question.Update
{
    public class UpdateQuestionCommandRequest : IRequest<UpdateQuestionCommandResponse>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid VacancyId { get; set; }
    }
}
