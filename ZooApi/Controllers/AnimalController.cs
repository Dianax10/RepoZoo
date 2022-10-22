using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ZooApi.Models;
using ZooApi.Services;

namespace ZooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private IAnimalService _animalService = new AnimalServices();

        [HttpGet]
        public IActionResult GetAll()
        {
            var allAnimal = _animalService.GetAllAnimal();
            if (allAnimal == null)
                return NotFound("Animale non trovato");

            return Ok(allAnimal);
        }

        [HttpGet("{animalId}")]
        public IActionResult GetById(int animalId)
        {
            var animal = _animalService.GetDetail(animalId);
            if (animal == null)
                return NoContent();
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SimpleAnimal postAnimal)
        {
            var animalAdd = _animalService.Create(postAnimal);
            return Created("", animalAdd);//createdat
        }

        [HttpPut("{animalId}")]
        public IActionResult Put(int animalId, [FromBody] SimpleAnimal animal)
        {
            var animalUpdate = _animalService.Put(animal, animalId);
            return Ok(animalUpdate);
        }

        [HttpDelete("{animalId}")]
        public IActionResult Delete(int animalId)
        {
            var animalToDelete = _animalService.Delete(animalId);
            if (animalToDelete == null)
                return NoContent();
            return Ok();
        }
        [HttpGet("{specie}/getSpecie")]
        public IActionResult GetBySpecie(string specie)
        {
            var animal = _animalService.GetAnimaliFromSpecie(specie);
            if (animal == null)
                return NoContent();
            return Ok(animal);
        }
        [HttpGet("/OrderByPeso")]
        public IActionResult GetByPeso()
        {
            var animal = _animalService.GetOrderByPeso();
            if (animal == null)
                return NoContent();
            return Ok(animal);
        }
    }
}
