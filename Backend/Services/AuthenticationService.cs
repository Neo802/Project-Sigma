using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProjectRunAway.Services.Interfaces;

namespace ProjectRunAway.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IEmailSender _emailSender;

        public AuthenticationService(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<AuthenticationService> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> RegisterAsync(string email, string password, string returnUrl, ModelStateDictionary modelState, IUrlHelper urlHelper)
        {
            returnUrl ??= urlHelper.Content("~/");

            if (modelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return new RedirectToPageResult("RegisterConfirmation", new { email = email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return new LocalRedirectResult(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    modelState.AddModelError(string.Empty, error.Description);
                }
            }

            return new PageResult();
        }

        public async Task<IActionResult> LoginAsync(string email, string password, bool rememberMe, string returnUrl, ModelStateDictionary modelState, IUrlHelper urlHelper)
        {
            returnUrl ??= urlHelper.Content("~/");

            if (modelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return new LocalRedirectResult(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return new RedirectToPageResult("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = rememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return new RedirectToPageResult("./Lockout");
                }
                else
                {
                    modelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return new PageResult();
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
