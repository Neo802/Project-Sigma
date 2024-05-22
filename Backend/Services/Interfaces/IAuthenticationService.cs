using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProjectRunAway.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IActionResult> RegisterAsync(string email, string password, string returnUrl, ModelStateDictionary modelState, IUrlHelper urlHelper);
        Task<IActionResult> LoginAsync(string email, string password, bool rememberMe, string returnUrl, ModelStateDictionary modelState, IUrlHelper urlHelper);
    }
}
