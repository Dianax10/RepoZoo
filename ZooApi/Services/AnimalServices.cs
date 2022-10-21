
using ZooApi.Models;

namespace ZooApi.Services
{
    public class AnimalServices : IAnimalService
    {
        private static readonly string _animalPath = "Animals.txt";
        private IList<Animal> _animalList = new List<Animal>();
        private AnimalFiles _animalFile = new AnimalFiles();
        private int IncrementId()
        {
            if (_animalList.Count == 0)
                return 1;

            return _animalList.Max(animal => animal.IdAnimal) + 1;
        }
        public Animal Create(SimpleAnimal animal)
        {

            var animalMap = new Animal();
            animalMap.IdAnimal = IncrementId();
            animalMap.Specie = animal.Specie;
            animalMap.Peso = animal.Peso;
            animalMap.Altezza = animal.Altezza;

            var animals= _animalFile.ReadAndDeserialize(_animalPath);
            animals.Add(animalMap);
            _animalFile.WriteAndSerialize(_animalPath, animals);
            return animalMap;

        }

        public IList<Animal> Delete(int animalId)
        {
            throw new NotImplementedException();
        }

        public IList<Animal> GetAll()
        {
            throw new NotImplementedException();
        }

        public Animal GetDetail(int animalId)
        {
            throw new NotImplementedException();
        }

        public Animal Put(int animalId)
        {
            throw new NotImplementedException();
        }

        //public AnimalServices(IList<Animal> animalList)
        //{
        //    _animalList = animalList;
        //}



    }
}
