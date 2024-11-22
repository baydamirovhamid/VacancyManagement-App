using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Domain.Entities;

namespace VacancyManagementApp.Application.Repositories
{
    public interface IFileUploadReadRepository : IReadRepository<UploadedFile>
    {
    }
}
