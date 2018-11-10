using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.EntityFrameworkServices
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
            :base("DefaultConnectionString")
        {

        }

        public DbSet<Students.ServicesModel.StudentInfo> Students { get; set; }

    }
}
