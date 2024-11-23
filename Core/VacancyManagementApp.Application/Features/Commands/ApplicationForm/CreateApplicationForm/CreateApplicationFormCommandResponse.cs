using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Commands.ApplicationForm.CreateApplicationForm
{
    public class CreateApplicationFormCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Guid Id { get; set; }
        public List<ValidationFailure> Errors { get; set; } = null;
    }
}
