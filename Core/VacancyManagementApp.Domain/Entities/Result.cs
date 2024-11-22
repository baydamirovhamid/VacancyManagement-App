using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Domain.Configurations;
using VacancyManagementApp.Domain.Entities.Common;
using VacancyManagementApp.Domain.Entities.Identity;

namespace VacancyManagementApp.Domain.Entities
{
    [EntityTypeConfiguration(typeof(ResultConfiguration))]
    public class Result:BaseEntity
    {
        public int TrueQuestionCount { get; set; }
        public int FalseAnswerCount { get; set; }
        public int Point { get; set; }
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public ApplicationForm ApplicationForm { get; set; }
        public Guid ApplicationFormId { get; set; }
    }
}
