using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Commands.Result.Create
{
    public class CreateResultCommandRequest : IRequest<CreateResultCommandResponse>
    {
        public int TrueQuestionCount { get; set; }
        public int FalseAnswerCount { get; set; }
        public int Point { get; set; }
        public Guid VacancyId { get; set; }
        public Guid ApplicationFormId { get; set; }
    }
}
