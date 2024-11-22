using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Domain.Entities;

namespace VacancyManagementApp.Application.DTOs.Question
{
    public class GetAllQuestionDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid VacancyId { get; set; }
    }
}
