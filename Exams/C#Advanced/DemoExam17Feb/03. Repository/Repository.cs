using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Repository
{
    class Repository
    {
        private Dictionary<int, Person> respository;

        public int Count { get; private set; } = 0;

        public Repository()
        {
            respository = new Dictionary<int, Person>();
        }

        public void Add(Person person)
        {
            respository.Add(Count, person);
            Count++;
        }

        public Person Get(int id)
        {
            Person person = respository.FirstOrDefault(x => x.Key == id).Value;

            return person;
        }

        public bool Update(int id,Person person)
        {
            bool isValid = false;
            if (respository.ContainsKey(id))
            {
                isValid = true;

                respository[id] = person;
            }

            return isValid;
        }

        public bool Delete(int id)
        {
            bool isValid = false;
            if (respository.ContainsKey(id))
            {
                isValid = true;

                respository.Remove(id);
                Count--;
            }

            return isValid;
        }
    }
}
