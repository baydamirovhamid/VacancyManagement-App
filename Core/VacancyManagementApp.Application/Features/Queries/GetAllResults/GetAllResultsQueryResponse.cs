using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.Result;
using VacancyManagementApp.Domain.Entities.Identity;

namespace VacancyManagementApp.Application.Features.Queries.GetAllResults
{
    public class GetAllResultsQueryResponse
    {
       public List<GetAllResultDto> GetAllResultDtos { get; set; }=new();
    }
}
