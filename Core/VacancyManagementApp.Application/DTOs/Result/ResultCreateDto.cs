using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Domain.Entities.Identity;

namespace VacancyManagementApp.Application.DTOs.Result
{
    public class ResultCreateDto
    {
        public int TrueQuestionCount { get; set; }
        public int FalseAnswerCount { get; set; }
        public int Point { get; set; }
        public Guid VacancyId { get; set; }
        public Guid ApplicationFormId { get; set; }
    }
}
