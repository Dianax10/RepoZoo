using ZooApi.Models;

namespace ZooApi.Services
{
    public interface IAnimalService
    {

        public Animal Create(SimpleAnimal animal);
        public IList<Animal> GetAll();
        public Animal GetDetail(int animalId);
        public Animal Put(int animalId);
        public IList<Animal> Delete(int animalId);


    }
}
