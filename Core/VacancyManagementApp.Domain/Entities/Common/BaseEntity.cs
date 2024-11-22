using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
<<<<<<< HEAD
        public DateTime UpdatedDate { get; set; }= DateTime.Now;  
=======
        virtual public DateTime UpdatedDate { get; set; }=DateTime.Now;
>>>>>>> ba0b12033145760089b2021797f080099fe1e6ee
    }
}
