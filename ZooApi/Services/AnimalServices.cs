
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
            var animal = _animalFile.ReadAndDeserialize(_animalPath);
            if (animal.Count == 0)
                return 1;

            return animal.Max(animal => animal.IdAnimal) + 1;
        }
        public Animal Create(SimpleAnimal animal)
        {

            var animalMap = new Animal();
            animalMap.IdAnimal = IncrementId();
            animalMap.Specie = animal.Specie;
            animalMap.Peso = animal.Peso;
            animalMap.Altezza = animal.Altezza;

            var animals = _animalFile.ReadAndDeserialize(_animalPath);
            animals.Add(animalMap);
            _animalFile.WriteAndSerialize(_animalPath, animals);
            return animalMap;

        }
        public IList<Animal> GetAllAnimal()
        {
            return _animalFile.ReadAndDeserialize(_animalPath);
        }
        public Animal? GetDetail(int animalId)
        {
            var animalReaded = _animalFile.ReadAndDeserialize(_animalPath);
            var animalById = animalReaded.FirstOrDefault(animal => animal.IdAnimal == animalId);
            return animalById;
        }

        public IList<Animal> Delete(int animalId)
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
