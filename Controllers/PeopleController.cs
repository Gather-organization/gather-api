using API.Controllers;
using AutoMapper;
using gather_api.DbContexts;
using gather_api.Dtos;
using gather_api.Entities;
using gather_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gather_api.Controllers {
  public class PeopleController : BaseApiController {
    private readonly GatherContext _context;
    private readonly PeopleService _peopleService;
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

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeletePerson(int id) {
      try {
        bool result = await _peopleService.DeletePersonAsync(id);

        return Ok(result);
      } catch (System.Exception) {
        throw;
      }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Person>> UpdatePerson(int id, PersonDto personDto) {
      try {
        Person person = await _peopleService.UpdatePersonAsync(id, personDto);

        return Ok(person);
      } catch (System.Exception) {
        throw;
      }
    }
  }
}