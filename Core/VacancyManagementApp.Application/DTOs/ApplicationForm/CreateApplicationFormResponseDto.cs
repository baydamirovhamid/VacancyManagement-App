using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.DTOs.ApplicationForm
{
    public class CreateApplicationFormResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Guid Id { get; set; }

    }

}
