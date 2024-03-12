using auth.Model;
using Microsoft.AspNetCore.Identity;

namespace auth.Repos;
public interface IAuthRepository {
	public Task<IdentityResult> RegisterAsync(User user, string password, string role);
	public Task<SignInResult> LoginAsync(string login, string password);
	public Task LogoutAsync();
}
