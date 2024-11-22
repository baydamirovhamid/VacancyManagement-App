using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Domain.Entities;

namespace VacancyManagementApp.Domain.Configurations
{
    public class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        void IEntityTypeConfiguration<Result>.Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasOne(x => x.ApplicationForm).
           WithMany(x => x.Results).
           HasForeignKey(x => x.ApplicationFormId).
           OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Vacancy).
           WithMany(x => x.Results).
           HasForeignKey(x => x.VacancyId).
           OnDelete(DeleteBehavior.Restrict);
           
        }
    }
}
