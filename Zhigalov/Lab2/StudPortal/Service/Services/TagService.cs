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
    public class TagService : ITagService
    {
        TagRepository repository;

        public TagService()
        {
            repository = new TagRepository();
        }

        public void Create(TagInfo tag)
        {
            var tagEntity = AutoMapper.Mapper.Map<TagEntity>(tag);
            repository.Create(tagEntity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<TagInfo> GetAll()
        {
            var tagsEntity = repository.GetAll();
            var tagsInfo = AutoMapper.Mapper.Map<IEnumerable<TagInfo>>(tagsEntity);
            return tagsInfo;
        }
    }
}
