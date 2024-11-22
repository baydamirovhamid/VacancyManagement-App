using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Commands.UploadFile
{
    public class UploadFileCommandResponse
    {
        public string AppUserId { get; set; }
        public bool Success { get; set; }
        public string FileName { get; set; }
        public string Message { get; set; }
    }
}
