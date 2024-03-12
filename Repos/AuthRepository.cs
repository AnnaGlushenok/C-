using auth.Model;
using Microsoft.AspNetCore.Identity;

namespace auth.Repos;
public class AuthRepository : IAuthRepository {
	private UserManager<User> userManager;
	private SignInManager<User> signInManager;

	public AuthRepository(UserManager<User> userManager, SignInManager<User> signInManager) =>
			(this.userManager, this.signInManager) = (userManager, signInManager);

	public async Task<SignInResult> LoginAsync(string login, string password) {
		var result = await signInManager.PasswordSignInAsync(login, password, false, false);
		return result;
	}

	public async Task LogoutAsync() =>
		await signInManager.SignOutAsync();

	public async Task<IdentityResult> RegisterAsync(User user, string password, string role) {
		var result = await userManager.CreateAsync(user, password);

		if (!result.Succeeded)
			return result;

		await userManager.AddToRoleAsync(user, role);
		await signInManager.SignInAsync(user, false);

		return result;
	}
}
