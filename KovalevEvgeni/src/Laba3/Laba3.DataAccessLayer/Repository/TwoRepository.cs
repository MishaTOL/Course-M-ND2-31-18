using Laba3.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.DataAccessLayer.Repository
{
    public class TwoRepository : IRepository
    {
        private string details;

        public TwoRepository()
        {
            this.details = "Default";
        }

        public TwoRepository(string details)
        {
            this.details=details;
        }

        public string ViewDetails()
        {
            return $"Class TwoRepository - metod ViewDetails, field details= {details}";
        }
    }
}
