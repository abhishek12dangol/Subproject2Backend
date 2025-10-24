using IMDB.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.WebServiceLayer.Controllers;

[ApiController]
[Route("api/persons")]
public class PersonController: ControllerBase
{
    private readonly IPersonService _personService;
    public PersonController(IPersonService personService) => _personService = personService;

    [HttpGet("{id:int}")]
    public IActionResult GetPersonById(int id)
    {
        var person = _personService.GetPersonById(id);
        if (person == null) return NotFound();
        return Ok(person);
    }
}