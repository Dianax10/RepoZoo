﻿using Microsoft.AspNetCore.Mvc;
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
        // GET: api/<AnimalController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AnimalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

      
        [HttpPost]
        public IActionResult Post([FromBody] SimpleAnimal postAnimal)
        {
            var animalAdd= _animalService.Create(postAnimal);
            return Created("",animalAdd);//createdat

        }

        // PUT api/<AnimalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnimalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}