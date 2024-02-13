using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonServices _personServices;

        public PersonController(
                                ILogger<PersonController> logger,
                                IPersonServices personServices
                                )
        {
            _logger = logger;
            _personServices = personServices;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(long Id)
        {
            var result = await _personServices.Find(Id);

            if (result == null)
                return BadRequest("Person not found.");

            return Ok(result);            
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var result = await _personServices.FindAll();

            if (result == null)
                return BadRequest("List of Person not found.");

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest("Data of Person required.");

            var result = await _personServices.Insert(person);

            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest("Data of Person required.");

            var result = await _personServices.Update(person);

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _personServices.Delete(Id);

            return Ok(result);
        }
    }
}
