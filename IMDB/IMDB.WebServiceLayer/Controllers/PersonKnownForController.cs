using IMDB.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using IMDB.WebServiceLayer.DTO;
namespace IMDB.WebServiceLayer.Controllers;

[ApiController]
[Route("api/persons/{personId:int}/known-for")]
public class PersonKnownForController: ControllerBase
{
    private readonly IPersonKnownFor _service;
    public PersonKnownForController(IPersonKnownFor service) => _service = service;

    [HttpGet]
    public IActionResult GetKnownFor(int personId)
    {
        var personknownfor = _service.GetPersonKnownFor(personId);
        var knownForDTO = personknownfor.Select(pk => new PersonKnownForDTO
        {
            PrimaryTitle = pk.Movie.PrimaryTitle,
            StartYear = pk.Movie.StartYear,
            RunTimeMinutes = pk.Movie.RunTimeMinutes,
        }).ToList();
        return Ok(knownForDTO);
    }
}