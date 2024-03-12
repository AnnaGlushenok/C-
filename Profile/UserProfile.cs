using auth.DTO;
using auth.Model;
using AutoMapper;

namespace auth.Profile;
public class UserProfile : AutoMapper.Profile {
	public UserProfile() => CreateMap<User, UserDTO>().ReverseMap();
}
