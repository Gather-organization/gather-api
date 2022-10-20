using gather_api.Entities;

namespace gather_api.Repositories.Interfaces {
  public interface IPeopleRepository {
    Task<IEnumerable<Person>> GetPeopleAsync();
  }
}