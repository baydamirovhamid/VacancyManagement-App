using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.ApplicationForm;

namespace VacancyManagementApp.Application.Validators
{
    public class CreateFormValidator : AbstractValidator<CreateApplicationFormDto>
    {
        public CreateFormValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name must contain only letters.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Surname must contain only letters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Please enter a valid email format.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^(077|050|055|010|070)[\s-]?\d{3}[\s-]?\d{2}[\s-]?\d{2}$").WithMessage("Phone number must be in a valid format.");


        }

    }
}
