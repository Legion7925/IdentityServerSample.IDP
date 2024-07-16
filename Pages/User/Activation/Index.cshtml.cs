using Marvin.IDP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TTech.IDP.Pages.User.Activation;

[SecurityHeaders]
[AllowAnonymous]
public class IndexModel : PageModel
{
    private readonly ILocalUserService _localUserService;

    public IndexModel(ILocalUserService localUserService)
    {
        _localUserService = localUserService;
    }

    [BindProperty]
    public ActivationInputModel InputModel { get; set; } = new();

    public async Task<IActionResult> OnGet(string securityCode)
    {
        if(await _localUserService.ActivateUserAsync(securityCode))
        {
            InputModel.Message = "you account was succesfully activated. Navigate to your client application to log in";
        }
        else
        {
            InputModel.Message = "something went wrong for activating your account call admin !";
        }

        await _localUserService.SaveChangesAsync();

        return Page();
    }
}
