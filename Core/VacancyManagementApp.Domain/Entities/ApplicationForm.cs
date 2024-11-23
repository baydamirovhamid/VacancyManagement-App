using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Domain.Entities.Common;
using VacancyManagementApp.Domain.Entities.Identity;

namespace VacancyManagementApp.Domain.Entities
{
    public class ApplicationForm : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public UploadedFile? UploadedFile { get; set; }
        public List<Result> Results { get; set; }
    }

}
