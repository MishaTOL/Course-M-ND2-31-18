using AutoMapper;
using Laba2.BusinessLogicLayer.DataTransferObject;
using Laba2.BusinessLogicLayer.Interfaces;
using Laba2.DataAccessLayer.Entity;
using Laba2.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.BusinessLogicLayer.Services
{
    public class ServiceComment : IServiceComment
    {
        private IUnitOfWork database;
        private IMapper mapper;
        public ServiceComment(IUnitOfWork database)
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment,CommentDTO>().ForMember(p => p.Author, o => o.MapFrom(s => $"{s.Student.FirstName} {s.Student.LastName}"));
                cfg.CreateMap<CommentDTO, Comment>();
            }
            ).CreateMapper();
            this.database = database;
        }

        public IEnumerable<CommentDTO> GetComments(int postId)
        {
            return mapper.Map<IEnumerable<Comment>,IEnumerable<CommentDTO>>(database.Comments.Find(x => x.PostId == postId));
        }

        public void Insert(CommentDTO record)
        {
            record.DateCreate = DateTime.Now;
            database.Comments.Create(mapper.Map<CommentDTO, Comment>(record));
            database.Save();
        }
    }
}
