using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Persistence.Contexts;

namespace VacancyManagementApp.Persistence.Repositories
{
    public class FileUploadReadRepository : ReadRepository<UploadedFile>, IFileUploadReadRepository
    {
        public FileUploadReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
