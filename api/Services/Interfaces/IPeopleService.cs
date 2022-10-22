using gather_api.Dtos;
using gather_api.Entities;

namespace gather_api.Services.Interfaces {
  public interface IPeopleService {
    Task<IEnumerable<Person>> GetPeopleAsync();
    Task<Person> CreatePersonAsync(PersonDto personDto);
    Task<bool> DeletePersonAsync(int id);
    Task<Person> UpdatePersonAsync(int id, PersonDto personDto);
  }
}