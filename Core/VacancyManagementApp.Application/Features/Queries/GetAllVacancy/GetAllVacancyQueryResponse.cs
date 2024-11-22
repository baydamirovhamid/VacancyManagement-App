using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.Vacancy;

namespace VacancyManagementApp.Application.Features.Queries.GetAllVacancy
{
    public class GetAllVacancyQueryResponse
    {
        public List<ListVacancyDto> GetAllVacancies { get; set; } = new();
    }
}
