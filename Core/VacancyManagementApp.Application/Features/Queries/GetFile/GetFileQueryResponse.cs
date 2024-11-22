using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Queries.GetAllFile
{
    public class GetFileQueryResponse
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
    }
}
