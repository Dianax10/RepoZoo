
using ZooApi.Models;

namespace ZooApi.Services
{
    public class AnimalServices : IAnimalService
    {
        private static readonly string _animalPath = "Animals.txt";
        private IList<Animal> _animalList = new List<Animal>();
        private AnimalFiles _animalFile = new AnimalFiles();

        public Animal Mapping(SimpleAnimal animal)
        {
            var animalMap = new Animal();
            animalMap.IdAnimal = IncrementId();
            animalMap.Specie = animal.Specie;
            animalMap.Peso = animal.Peso;
            animalMap.Altezza = animal.Altezza;
            return animalMap;
        }
        private int IncrementId()
        {
            var animal = _animalFile.ReadAndDeserialize(_animalPath);
            if (animal.Count == 0)
                return 1;

            return animal.Max(animal => animal.IdAnimal) + 1;
        }
        public Animal Create(SimpleAnimal animal)
        {

            //var animalMap = new Animal();
            //animalMap.IdAnimal = IncrementId();
            //animalMap.Specie = animal.Specie;
            //animalMap.Peso = animal.Peso;
            //animalMap.Altezza = animal.Altezza;
            var animalMap= Mapping(animal);
            var animals = _animalFile.ReadAndDeserialize(_animalPath);
            animals.Add(animalMap);
            _animalFile.WriteAndSerialize(_animalPath, animals);
            return animalMap;

        }
        public IList<Animal> GetAllAnimal() => _animalFile.ReadAndDeserialize(_animalPath);
        //{
        //    return _animalFile.ReadAndDeserialize(_animalPath);
        //}
        public Animal? GetDetail(int animalId)
        {
            var animalReaded = _animalFile.ReadAndDeserialize(_animalPath);
            var animalById = animalReaded.FirstOrDefault(animal => animal.IdAnimal == animalId);
            return animalById;
        }

        public IList<Animal>? Delete(int animalId)
        {
            var animalReaded = _animalFile.ReadAndDeserialize(_animalPath);
            var animalById = animalReaded.FirstOrDefault(animal => animal.IdAnimal == animalId);
            if (animalById != null)
            {
                animalReaded.Remove(animalById);
                _animalFile.WriteAndSerialize(_animalPath, animalReaded);
                return animalReaded;
            }
            return null;
        }


        public Animal Put(SimpleAnimal animal,int animalId)
        {

            var animalMap = Mapping(animal);
            var animalReaded = _animalFile.ReadAndDeserialize(_animalPath);
            var animalById = animalReaded.FirstOrDefault(animal => animal.IdAnimal == animalId);

            if (animalById == null)
            {
                animalReaded.Add(animalMap);
                _animalFile.WriteAndSerialize(_animalPath, animalReaded);
                return animalMap;
            }

            animalReaded.Remove(animalById);

            var animalFinale = new Animal();
            animalFinale.IdAnimal = animalById.IdAnimal;
            animalFinale.Specie = animal.Specie;
            animalFinale.Peso = animal.Peso;
            animalFinale.Altezza = animal.Altezza;

            animalReaded.Add(animalFinale);

            _animalFile.WriteAndSerialize(_animalPath, animalReaded);
            return animalFinale;

        }

        public IList<Animal> GetAnimaliFromSpecie(string specie)
        {
            var animalReaded = _animalFile.ReadAndDeserialize(_animalPath);
            var animalBySpecie= animalReaded.Where(animal=> animal.Specie == specie).ToList();
            return animalBySpecie;
        }

        public IList<Animal> GetOrderByPeso()
        {
            var animalReaded = _animalFile.ReadAndDeserialize(_animalPath);
            var animalByPeso= animalReaded.OrderBy(animal=>animal.Peso).ToList();
            return animalByPeso;
        }
    }
}
