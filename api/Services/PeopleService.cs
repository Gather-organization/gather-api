using AutoMapper;
using gather_api.DbContexts;
using gather_api.Dtos;
using gather_api.Entities;
using gather_api.Repositories;
using gather_api.Services.Interfaces;

namespace gather_api.Services {
  public class PeopleService : IPeopleService {
    private readonly GatherContext _context;
    private readonly IMapper _mapper;
    private readonly PeopleRepository _peopleRepository;

    public PeopleService(GatherContext context, IMapper mapper) {
      _context = context;
      _mapper = mapper;
      _peopleRepository = new PeopleRepository(_context);
    }

    public async Task<IEnumerable<Person>> GetPeopleAsync() {
      IEnumerable<Person>? people = await _peopleRepository.GetPeopleAsync();

      return people;
    }

    public async Task<Person> CreatePersonAsync(PersonDto personDto) {
      Person person = _mapper.Map<Person>(personDto);

      person = await _peopleRepository.AddPersonAsync(person);

      await _context.SaveChangesAsync();

      return person;
    }

    public async Task<bool> DeletePersonAsync(int id) {
      Person? person = await _peopleRepository.GetPersonByIdAsync(id);

      if (person == null) throw new Exception("No person found for provided Id.");

      _peopleRepository.DeletePerson(person);

      await _context.SaveChangesAsync();

      return true;
    }

    public async Task<Person> UpdatePersonAsync(int id, PersonDto personDto) {
      Person? person = await _peopleRepository.GetPersonByIdAsync(id);

      if (person == null) throw new Exception("Could not find a person for the provided Id.");

      _mapper.Map(personDto, person);

      await _context.SaveChangesAsync();

      return person;
    }
  }
}