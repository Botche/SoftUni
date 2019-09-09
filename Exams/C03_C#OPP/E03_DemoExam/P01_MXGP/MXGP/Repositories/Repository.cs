using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        public void Add(T model)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T model)
        {
            throw new NotImplementedException();
        }
    }
}
