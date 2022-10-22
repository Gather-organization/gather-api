using gather_api.DbContexts;
using gather_api.Entities;
using gather_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gather_api.Repositories {
  public class PeopleRepository : IPeopleRepository {
    private readonly GatherContext _context;

    public PeopleRepository(GatherContext context) {
      _context = context;
    }

    public async Task<IEnumerable<Person>> GetPeopleAsync() {
      return await _context.Person.ToListAsync();
    }

    public async Task<Person> AddPersonAsync(Person person) {
      await _context.Person.AddAsync(person);
      return person;
    }

    public async Task<Person?> GetPersonByIdAsync(int id) {
      Person? person = await _context.Person.FirstOrDefaultAsync(person => person.Id == id);
      return person;
    }

    public bool DeletePerson(Person person) {
      _context.Person.Remove(person);
      return true;
    }
  }
}