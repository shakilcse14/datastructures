using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.StacksAndQueues
{
    public class AnimalShelter
    {
        private LinkedList<Animal> _animals;

        public AnimalShelter()
        {
            _animals = new LinkedList<Animal>();
        }

        public void Enqueue(int type)
        {
            _animals.AddLast(new Animal()
            {
                Type = type
            });
        }

        public Animal DequeueAny()
        {
            if(_animals.Count <= 0)
                throw new InvalidOperationException();

            var animal = _animals.First.Value;
            _animals.RemoveFirst();
            return animal;
        }

        public Animal DequeueDog()
        {
            if (_animals.Count <= 0)
                throw new InvalidOperationException();
            var count = 0;
            var totalCount = _animals.Count;
            Animal animalAsDog = null;
            while (count <= totalCount)
            {
                if (_animals.First.Value.Type.Equals(0))
                {
                    animalAsDog = _animals.First.Value;
                    break;
                }
                var animal = _animals.First.Value;
                _animals.RemoveFirst();
                _animals.AddLast(animal);
                count++;
            }

            if (animalAsDog != null)
            {
                _animals.RemoveFirst();

                for (var index = 1; index <= (totalCount - count - 1); index++)
                {
                    var animal = _animals.First.Value;
                    _animals.RemoveFirst();
                    _animals.AddLast(animal);
                }
            }

            return animalAsDog;
        }

        public Animal DequeueCat()
        {
            if (_animals.Count <= 0)
                throw new InvalidOperationException();

            var count = 0;
            var totalCount = _animals.Count;
            Animal animalAsCat = null;
            while (count <= totalCount)
            {
                if (_animals.First.Value.Type.Equals(1))
                {
                    animalAsCat = _animals.First.Value;
                    break;
                }
                var animal = _animals.First.Value;
                _animals.RemoveFirst();
                _animals.AddLast(animal);
                count++;
            }

            if (animalAsCat != null)
            {
                _animals.RemoveFirst();

                for (var index = 1; index <= (totalCount - count - 1); index++)
                {
                    var animal = _animals.First.Value;
                    _animals.RemoveFirst();
                    _animals.AddLast(animal);
                }
            }

            return animalAsCat;
        }
    }

    public class Animal
    {
        public int Type { get; set; }
    }
}