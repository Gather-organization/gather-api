using AutoMapper;
using gather_api.Dtos;
using gather_api.Entities;

namespace gather_api.Profiles {
  public class PersonProfile : Profile {
    public PersonProfile() {
      CreateMap<Person, PersonDto>().ReverseMap();
    }
  }
}