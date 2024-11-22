using Microsoft.EntityFrameworkCore;
using VacancyManagementApp.Domain.Entities.Common;

namespace VacancyManagementApp.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
