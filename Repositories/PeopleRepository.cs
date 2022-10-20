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
      try {
        await _context.Person.AddAsync(person);
        return person;
      } catch (System.Exception) {
        throw;
      }
    }
  }
}