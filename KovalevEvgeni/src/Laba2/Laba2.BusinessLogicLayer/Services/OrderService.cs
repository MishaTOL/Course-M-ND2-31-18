using Laba2.BusinessLogicLayer.Interfaces;
using Laba2.DataAccessLayer.Interfaces;
using Laba2.DataAccessLayer.Repositorues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork dataBase;
        private IServiceStudent serviceStudent;
        public IServiceStudent ServiceStudent
        {
            get
            {
                if (serviceStudent == null)
                    serviceStudent = new ServiceStudent(dataBase);
                return serviceStudent;

            }
        }

        private IServicePost servicePost;

        public IServicePost ServicePost
        {
            get
            {
                if (servicePost == null)
                    servicePost = new ServicePost(dataBase);
                return servicePost;
            }
        }

        private IServiceComment serviceComment;

        public IServiceComment ServiceComment
        {
            get
            {
                if (serviceComment == null)
                    serviceComment = new ServiceComment(dataBase);
                return serviceComment;
            }
        }

        public OrderService()
        {
            this.dataBase = new EFUnitOfWork();
        }
    }
}
