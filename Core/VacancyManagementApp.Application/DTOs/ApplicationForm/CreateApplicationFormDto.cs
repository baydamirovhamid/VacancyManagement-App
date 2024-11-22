using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.DTOs.ApplicationForm
{
    public class CreateApplicationFormDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid VacancyId { get; set; }
        public string? AppUserId { get; set; }
    }

}
