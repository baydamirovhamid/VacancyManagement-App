using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.ApplicationForm;

namespace VacancyManagementApp.Application.Features.Queries.GetAllApplicationForm
{
    public class GetAllApplicationFormQueryResponse
    {
        public List<GetAllApplicationFormDto> GetAllApplicationForm { get; set; }

    }
}
