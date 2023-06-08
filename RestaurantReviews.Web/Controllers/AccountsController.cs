using HeloMVCAuth.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantReviews.Data.Migrations;
using RestaurantReviews.Web.Models.Auth;

namespace RestaurantReviews.Web.Controllers {
    public class AccountsController : Controller {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public AccountsController(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm model , string returnUrl = null) {


            if (ModelState.IsValid) {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: false);
                if (result.Succeeded) {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor) {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe =true});
                }
                if (result.IsLockedOut) {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                } else {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    
                }
            }

            return View();
        }

    }
}
