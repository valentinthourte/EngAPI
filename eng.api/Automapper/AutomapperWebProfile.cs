using AutoMapper;
using eng.api.Model;
using eng.application.Model;

namespace eng.api.Automapper
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile() 
        {
            UsersAutoMapper();

        }

        private void UsersAutoMapper()
        {
            CreateMap<UserDTO, User>()
                .ForMember(x => x.Active, y => y.MapFrom(z => z.Active ?? true))
                .ReverseMap();
        }
    }
}
