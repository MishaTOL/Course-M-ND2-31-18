using Laba3.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.DataAccessLayer.Repository
{
    public class OneRepository : IRepository
    {
        public string ViewDetails()
        {
            return "Class OneRepository - metod ViewDetails";
        }
    }
}
