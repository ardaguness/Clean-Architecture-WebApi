using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Domain.Entities.Identity;
using Domain.Interfaces;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class AuthService : IAuthService
{
    readonly UserManager<Domain.Entities.Identity.ApplicationUser> _userManager;
    readonly SignInManager<Domain.Entities.Identity.ApplicationUser> _signInManager;
    private readonly EFDBContext db;

    public AuthService(EFDBContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        db = dbContext;
    }

    private string GenerateRandomRefransCode()
    {
        Random random = new Random();
        const string allowedChars = "ABCDEFGHJKLMNPQRSTWXYZ";
        string code = new string(Enumerable.Repeat(allowedChars, 7)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        return code;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterUser model)
    {
        var user = new ApplicationUser
        {
            UserName = model.Username,
            Email = model.Email,
            Name = model.Name,
            Surname = model.Surname,
            UserNumber = GenerateRandomRefransCode()
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        return result;
    }


    public async Task<SignInResult> LoginAsync(string username, string password, bool rememberMe)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);

        return result;
    }

}
