using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public interface IRepository<in TKey, TModel>
    {
        TModel Get(TKey ID);

        void Add(TModel Model);
        void Update(TModel Model);
        void Delete(TModel Model);
    }
}