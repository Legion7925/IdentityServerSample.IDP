using Duende.IdentityServer;
using Duende.IdentityServer.Services;
using IdentityModel;
using Marvin.IDP.Entities;
using Marvin.IDP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;


namespace TTech.IDP.Pages.User.Registration;

[AllowAnonymous]
[SecurityHeaders]
public class IndexModel : PageModel
{
    private readonly ILocalUserService _localUserService;
    private readonly IIdentityServerInteractionService _interaction;

    [BindProperty]
    public RegistrationInputModel Input { get; set; }


    public IndexModel(
        ILocalUserService localUserService,
        IIdentityServerInteractionService interaction)
    {
        _localUserService = localUserService ??
            throw new ArgumentNullException(nameof(localUserService));
        _interaction = interaction ??
            throw new ArgumentNullException(nameof(interaction));
    }

    public IActionResult OnGet(string returnUrl)
    {
        BuildModel(returnUrl);
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            // something went wrong, show form with error
            BuildModel(Input.ReturnUrl);
            return Page();
        }

        // create user & claims
        var userToCreate = new Marvin.IDP.Entities.User
        {
            UserName = Input.UserName,
            Subject = Guid.NewGuid().ToString(),
            Email = Input.Email,
            Active = false
        };

        userToCreate.Claims.Add(new UserClaim()
        {
            Type = "country",
            Value = Input.Country
        });

        userToCreate.Claims.Add(new UserClaim()
        {
            Type = JwtClaimTypes.GivenName,
            Value = Input.GivenName
        });

        userToCreate.Claims.Add(new UserClaim()
        {
            Type = JwtClaimTypes.FamilyName,
            Value = Input.FamilyName
        });

        _localUserService.AddUser(userToCreate, Input.Password);
        await _localUserService.SaveChangesAsync();

        // create an activation link - we need an absolute URL, therefore
        // we use Url.PageLink instead of Url.Page
        var activationLink = Url.PageLink("/user/activation/index",
            values: new { securityCode = userToCreate.SecurityCode });

        Debug.WriteLine($"Activation link: {activationLink}");

        //// Issue authentication cookie (log the user in)
        //var isUser = new IdentityServerUser(userToCreate.Subject)
        //{
        //    DisplayName = userToCreate.UserName
        //};
        //await HttpContext.SignInAsync(isUser);

        //// continue with the flow     
        //if (_interaction.IsValidReturnUrl(Input.ReturnUrl) || Url.IsLocalUrl(Input.ReturnUrl))
        //{
        //    return Redirect(Input.ReturnUrl);
        //}

        return Redirect("~/User/ActivationCodeSent");
    }

    private void BuildModel(string returnUrl)
    {
        Input = new RegistrationInputModel
        {
            ReturnUrl = returnUrl
        };
    }
}
