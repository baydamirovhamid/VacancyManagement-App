using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Domain.Entities.Common;

namespace VacancyManagementApp.Domain.Entities
{
    public class Vacancy: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Question> Questions { get; set; }
        public int QuestionCount { get; set; }
        public List<Result> Results { get; set; }
    }
}
