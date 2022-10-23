
using ZooApi.Models;

namespace ZooApi.Services
{
    public class AnimalServices : IAnimalService
    {
        private static readonly string _animalPath = "Animals.txt";
      //  private IList<Animal> _animalList = new List<Animal>();
        //private FileHelper _animalFile = new FileHelper();

        public Animal Mapping(SimpleAnimal animal)
        {
            var animalMap = new Animal();
            animalMap.IdAnimal = IncrementId();
            animalMap.Specie = animal.Specie;
            animalMap.Peso = animal.Peso;
            animalMap.Altezza = animal.Altezza;
            return animalMap;
        }
        private  int IncrementId()
        {
            var animal = FileHelper.ReadAndDeserialize<Animal>(_animalPath).ToList();
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
            var animals = FileHelper.ReadAndDeserialize<Animal>(_animalPath).ToList();
            animals.Add(animalMap);
            FileHelper.WriteAndSerialize(_animalPath, animals);
            return animalMap;

        }
        public IList<Animal> GetAllAnimal() /*=> FileHelper.ReadAndDeserialize<Animal>(_animalPath).ToList();*/
        {
            var animalReaded = FileHelper.ReadAndDeserialize<Animal>(_animalPath).ToList();
            var animaliOrdinati= animalReaded.OrderBy(animalReaded => animalReaded.IdAnimal).ToList();
            return animaliOrdinati;
        }
        public Animal? GetDetail(int animalId)
        {
            var animalReaded = FileHelper.ReadAndDeserialize<Animal>(_animalPath);
            var animalById = animalReaded.FirstOrDefault(animal => animal.IdAnimal == animalId);
            return animalById;
        }

        public IList<Animal>? Delete(int animalId)
        {
            var animalReaded = FileHelper.ReadAndDeserialize<Animal>(_animalPath).ToList();
            var animalById = animalReaded.FirstOrDefault(animal => animal.IdAnimal == animalId);
            if (animalById != null)
            {
                animalReaded.Remove(animalById);
                FileHelper.WriteAndSerialize(_animalPath, animalReaded);
                return animalReaded;
            }
            return null;
        }


        public Animal Put(SimpleAnimal animal,int animalId)
        {

            var animalMap = Mapping(animal);
            var animalReaded = FileHelper.ReadAndDeserialize<Animal>(_animalPath).ToList();
            var animalById = animalReaded.FirstOrDefault(animal => animal.IdAnimal == animalId);

            if (animalById == null)
            {
                animalReaded.Add(animalMap);
                FileHelper.WriteAndSerialize(_animalPath, animalReaded);
                return animalMap;
            }

            animalReaded.Remove(animalById);

            var animalFinale = new Animal();
            animalFinale.IdAnimal = animalById.IdAnimal;
            animalFinale.Specie = animal.Specie;
            animalFinale.Peso = animal.Peso;
            animalFinale.Altezza = animal.Altezza;

            animalReaded.Add(animalFinale);

            FileHelper.WriteAndSerialize(_animalPath, animalReaded);
            return animalFinale;

        }

        public IList<Animal> GetAnimaliFromSpecie(string specie)
        {
            var animalReaded = FileHelper.ReadAndDeserialize<Animal>(_animalPath).ToList();
            var animalBySpecie= animalReaded.Where(animal=> animal.Specie == specie).ToList();
            return animalBySpecie;
        }

        public IList<Animal> GetOrderByPeso()
        {
            var animalReaded = FileHelper.ReadAndDeserialize<Animal>(_animalPath).ToList();
            var animalByPeso= animalReaded.OrderBy(animal=>animal.Peso).ToList();
            return animalByPeso;
        }
    }
}
