using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private List<Cat> cats = new List<Cat>() { 
            new Cat(){ 
                id = 1,
                Name = "Coco",
                Age = 3,
                Breed = "tabby"
            },
            new Cat(){
                id = 2,
                Name = "Lenny",
                Age = 7,
                Breed = "persian"
            }
        };
        

        [HttpGet]
        [Route("getCatYears")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCatYears(int humanyears)
        {
            if (humanyears  < 0 ) return BadRequest("The inputs must be greater than zero");
            return Ok(humanyears*7);
        }

       
        [HttpGet]
        [ProducesResponseType(200)]
        [Route("getCats")]
        public IActionResult GetCats()
        {
            return Ok(cats);
        }

   
        [HttpPost]
        [Route("surrenderCat")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Cat>> AddCat(Cat request)
        {
            cats.Add(request);
            return Ok(cats);
        }

       
        [HttpPut]
        [Route("editCat")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Cat>> EditCat(Cat request)
        {
            var cat = cats.Find(x => x.id == 1);
            if (cat == null) return BadRequest("Cat not found");
            cat.Name = request.Name;
            cat.Age = request.Age;
            cat.Breed = request.Breed;

            return Ok(cats);

        }

        [HttpDelete]
        [Route("AdoptCat")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Cat>> AdoptCat(Cat request)
        {
            var cat = cats.Find(x => x.id == 1);
            if (cat == null) return BadRequest("Cat not found");
            cat.Name = request.Name;
            cat.Age = request.Age;
            cat.Breed = request.Breed;

            cats.Remove(cat);

            return Ok(cats);

        }




    }
}
