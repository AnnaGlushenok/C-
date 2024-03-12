using auth.Model;
using auth.Repos;
using AutoMapper;
using System.Text;
using auth.Profile;

namespace auth.Services;
public class AuthService : IAuthService {
	private IAuthRepository _accountRepository;
	IMapper mapper = new MapperConfiguration(mc => mc.AddProfile(new UserProfile())).CreateMapper();

	public AuthService(IAuthRepository authRepository) =>
		_accountRepository = authRepository;

	public async Task<bool> LoginAsync(string login, string password) {
		var result = await _accountRepository.LoginAsync(login, password);

		if (!result.Succeeded)
			throw new Exception();

		return true;
	}

	public async Task LogoutAsync()
		=> await _accountRepository.LogoutAsync();


	public async Task<bool> RegisterAsync(User user, string password, string role) {
		var mapperModel = mapper.Map<User>(user);

		var result = await _accountRepository.RegisterAsync(mapperModel, password, role);

		if (!result.Succeeded) {
			var errors = new StringBuilder(16);
			result.Errors.ToList().ForEach(i => errors.Append(i.Description));

			throw new Exception(errors.ToString());
		}

		return true;
	}
}
