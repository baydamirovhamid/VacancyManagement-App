using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.DTOs.File
{
    public class GetFileByOwnerDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
    }
}
