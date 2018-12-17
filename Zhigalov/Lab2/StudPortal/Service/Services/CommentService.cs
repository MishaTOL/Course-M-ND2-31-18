using Repository.Repositories;
using RepositoryModels;
using Service.Interfaces;
using ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CommentService : ICommentService
    {
        CommentRepository repository;

        public CommentService()
        {
            repository = new CommentRepository();
        }

        public void Create(CommentInfo comment)
        {
            var commentEntity = AutoMapper.Mapper.Map<CommentEntity>(comment);
            repository.Create(commentEntity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Edit(CommentInfo comment)
        {
            var commentEntity = AutoMapper.Mapper.Map<CommentEntity>(comment);
            repository.Edit(commentEntity);
        }

        public IEnumerable<CommentInfo> GetAll()
        {
            var commentsEntity = repository.GetAll();
            var commentsInfo = AutoMapper.Mapper.Map<IEnumerable<CommentInfo>>(commentsEntity);
            return commentsInfo;
        }
    }
}
