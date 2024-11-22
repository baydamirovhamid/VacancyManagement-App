using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Domain.Entities.Common;
using VacancyManagementApp.Domain.Entities.Identity;

namespace VacancyManagementApp.Domain.Entities
{
    public class UploadedFile: BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public Guid ApplicationFormId { get; set; }
        public ApplicationForm ApplicationForm { get; set; }
    }
}
