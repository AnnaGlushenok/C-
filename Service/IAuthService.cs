using auth.Model;

namespace auth.Services;
internal interface IAuthService {
	public Task<bool> RegisterAsync(User user, string password, string role);
	public Task<bool> LoginAsync(string login, string password);
	public Task LogoutAsync();
}
