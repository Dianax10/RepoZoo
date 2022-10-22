using ZooApi.Models;

namespace ZooApi.Services
{
    public interface IAnimalService
    {

        public Animal Create(SimpleAnimal animal);
        public IList<Animal> GetAllAnimal();
        public Animal? GetDetail(int animalId);
        public Animal Put(SimpleAnimal animal,int animalId);
        public IList<Animal> Delete(int animalId);
        public IList<Animal> GetAnimaliFromSpecie(string specie);
        public IList<Animal> GetOrderByPeso();

    }
}
