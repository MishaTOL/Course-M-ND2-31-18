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
    public class TagPostMapService : ITagPostMapService
    {
        TagPostMapRepository repository;

        public TagPostMapService()
        {
            repository = new TagPostMapRepository();
        }

        public void Create(TagPostMapInfo tagPost)
        {
            var tagPostEntity = AutoMapper.Mapper.Map<TagPostMap>(tagPost);
            repository.Create(tagPostEntity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<TagPostMapInfo> GetAll()
        {
            var tagPostEntity = repository.GetAll();
            var tagPostInfo = AutoMapper.Mapper.Map<IEnumerable<TagPostMapInfo>>(tagPostEntity);
            return tagPostInfo;
        }
    }
}
