using System;
using System.Collections.Generic;
using System.Linq;
using Last.Models;

namespace Last.Storage
{
    public class Avto : IStorage<Car>
    {
        private object _sync = new object();
        private List<Car> _avto = new List<Car>();
        public Car this[Guid id]
        {
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new Exceptions.IncorrectAvtoException($"No LabData with id {id}");

                    return _avto.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new Exceptions.IncorrectAvtoException("Cannot request Avto with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _avto.Add(value);
                }
            }
        }

        public System.Collections.Generic.List<Car> All => _avto.Select(x => x).ToList();

        public void Add(Car value)
        {
            if (value.Id == Guid.Empty) throw new Exceptions.IncorrectAvtoException($"Cannot add value with predefined id {value.Id}");

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public bool Has(Guid id)
        {
            return _avto.Any(x => x.Id == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _avto.RemoveAll(x => x.Id == id);
            }
        }
    }
}

