using Students.RepositoryModel;
using Students.ServicesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Services.Services
{
    public class AbstractService<TServiceModel, TRepositoryModel> : IInfoModelService<TServiceModel>
    {
        IEntityRepository<TRepositoryModel> _baseRepository;

        public AbstractService(IEntityRepository<TRepositoryModel> baseRepository)
        {
            _baseRepository = baseRepository;//new EntityFrameworkRepository.StudentRepository();
        }

        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public IEnumerable<TServiceModel> GetModelCollections()
        {
            var repositoryResponse = _baseRepository.GetModelCollections();
            return AutoMapper.Mapper.Map<IEnumerable<TRepositoryModel>, IEnumerable<TServiceModel>>(repositoryResponse);
        }

        public void Create(TServiceModel infpModel)
        {
            var dbModel = AutoMapper.Mapper.Map<TServiceModel, TRepositoryModel>(infpModel);
            _baseRepository.Create(dbModel);
        }

        public TServiceModel GetModelById(int id)
        {
            var dbModel = _baseRepository.GetModelById(id);
            return AutoMapper.Mapper.Map<TRepositoryModel, TServiceModel>(dbModel);
        }

        public void Update(TServiceModel infoModel)
        {
            var dbStudentModel = AutoMapper.Mapper.Map<TServiceModel, TRepositoryModel>(infoModel);
            _baseRepository.Update(dbStudentModel);
        }
    }
}
