using AutoMapper;
using gather_api.DbContexts;
using gather_api.Dtos;
using gather_api.Entities;
using gather_api.Services;
using gather_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gather_api.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class PeopleController : ControllerBase {
    private readonly GatherContext _context;
    private readonly IPeopleService _peopleService;
    private readonly IMapper _mapper;

    public PeopleController(GatherContext context, IMapper mapper) {
      _context = context;
      _mapper = mapper;
      _peopleService = new PeopleService(_context, _mapper);
    }

    [HttpGet()]
    public async Task<IEnumerable<Person>> GetPeople() {
      try {
        IEnumerable<Person>? people = await _peopleService.GetPeopleAsync();
        return people;
      } catch (System.Exception) {
        throw;
      }
    }

    [HttpPost()]
    public async Task<ActionResult<Person>> AddPerson(PersonDto personDto) {
      try {
        Person person = await _peopleService.CreatePersonAsync(personDto);

        return Ok(person);
      } catch (System.Exception) {
        throw;
      }
    }
  }
}