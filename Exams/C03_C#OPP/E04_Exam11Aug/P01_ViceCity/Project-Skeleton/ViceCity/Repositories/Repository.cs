using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class Repository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public Repository()
        {
            models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models { get => models;}

        public void Add(IGun model)
        {
            if (models.FirstOrDefault(m => m.Name == model.Name) == null)
            {
                models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return models.First(m => m.Name == name);
        }

        public bool Remove(IGun model)
        {
            return models.Remove(model);
        }
    }
}
