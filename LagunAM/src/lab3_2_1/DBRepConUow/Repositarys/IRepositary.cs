using System;
using System.Collections.Generic;


namespace DBRepConUow.Repositarys
{
    public interface IRepositary<in TKey, TModel>
    {
        IEnumerable<TModel> GetAll();
        TModel Get(TKey ID);
        void Add(TModel Model);
        void Update(TModel Model);
        void Delete(TModel Model);
    }
}
