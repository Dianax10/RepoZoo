using Microsoft.AspNetCore.Mvc;
using ZooApi.Models;
using ZooApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private IAnimalService _animalService=new AnimalServices();
     
        [HttpGet]
        public IActionResult GetAll()
        {
            var allAnimal = _animalService.GetAllAnimal();
            if (allAnimal == null)
                return NotFound("Animale non trovato");

            return Ok(allAnimal);
        }

        // GET api/<AnimalController>/5
        [HttpGet("{animalId}")]
        public IActionResult GetById(int animalId)
        {
           var animal=_animalService.GetDetail(animalId);
            if (animal == null)
                return NoContent();
            return Ok(animal);
        }

      
        [HttpPost]
        public IActionResult Post([FromBody] SimpleAnimal postAnimal)
        {
            var animalAdd= _animalService.Create(postAnimal);
            return Created("",animalAdd);//createdat

        }

        // PUT api/<AnimalController>/5
        [HttpPut("{animalid}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{animalId}")]
        public IActionResult Delete(int animalId)
        {
            var animalToDelete = _animalService.Delete(animalId);
            if (animalToDelete==null)
                return NoContent();
            return Ok();
        }
    }
}
