using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Commands.UploadFile
{
    public class UploadFileCommandRequest : IRequest<UploadFileCommandResponse>
    {
        public IFormFile File { get; set; }
    }
}
