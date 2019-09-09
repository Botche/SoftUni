using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motors;

        public MotorcycleRepository()
        {
            motors = new List<IMotorcycle>();
        }
        public void Add(IMotorcycle model)
        {
            motors.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return motors.AsReadOnly();
        }

        public IMotorcycle GetByName(string name)
        {
            return motors.FirstOrDefault(r => r.Model == name);
        }

        public bool Remove(IMotorcycle model)
        {
            return motors.Remove(model);
        }
    }
}
