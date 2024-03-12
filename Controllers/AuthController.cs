using auth.Model;
using auth.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers;
public class AuthController : Controller {
	private AuthService service;
	private UserManager<User> userManager;

	public AuthController(AuthService service, UserManager<User> userManager) =>
			(this.service, this.userManager) = (service, userManager);

	[HttpGet]
	public ActionResult Login() => View();

	[HttpGet]
	public ActionResult Reg() => View();

	[HttpGet]
	public async Task<IActionResult> Logout(User user) {
		try {
			await service.LogoutAsync();
			return RedirectToAction("Index", "Student");
		}
		catch {
			return RedirectToAction("Index", "Student");
		}
	}

	[HttpPost]
	public async Task<IActionResult> Login([FromBody] LoginModel login) {
		try {
			if (!ModelState.IsValid)
				return View(login);

			var result = await service.LoginAsync(login.Login, login.Password);

			if (!result)
				return View("~/Views/Student/Index.cshtml");

			return RedirectToAction("Login");
		}
		catch {
			return View();
		}
	}

	public async Task<IActionResult> Check() {
		try {
			var userr = await userManager.GetUserAsync(User);
			if (userr == null) {
				return RedirectToAction("SignOut", userr);
			}

			return RedirectToAction("Index", "Student");
		}
		catch {
			return RedirectToAction("Index", "Student");
		}
	}

	[HttpPost]
	public async Task<IActionResult> Reg([FromBody] User user) {
		try {
			//if (!ModelState.IsValid)
			//	return View();

			var result = await service.RegisterAsync(user, user.Password, "User");

			if (!result)
				return View("~/Views/Student/Index.cshtml");

			return RedirectToAction("Check");
		}
		catch {
			return View();
		}
	}
}
