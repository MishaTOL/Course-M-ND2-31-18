using Students.RepositoryModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.EntityFrameworkRepository
{
    public class StudentRepository : AbstractRepository<Student>
    {
        private ApplicationContext applicationContext;
        //protected override ApplicationContext ApplicationContext
        //{
        //    get
        //    {
        //        if (IsNeedRecreateContext)
        //            this.applicationContext = new ApplicationContext();
        //        return this.applicationContext;
        //    }
        //}
    }
}
