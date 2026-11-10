using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using scrap_depot.Models;
using scrap_depot.ViewModels;

namespace Cryptids.Web.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<EmployeeUser> _userManager;
    private readonly SignInManager<EmployeeUser> _signInManager;

    public AccountController(UserManager<EmployeeUser> userManager, SignInManager<EmployeeUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET /Account/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST /Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel form)
    {
        if (!ModelState.IsValid)
        {
            return View(form);
        }

        var EmployeeUser = new EmployeeUser { UserName = form.Email, Email = form.Email, CrewNumber = form.CrewNumber };

        var result = await _userManager.CreateAsync(EmployeeUser, form.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(form);
        }

        await _signInManager.SignInAsync(EmployeeUser, isPersistent: false);
        return RedirectToAction("Index", "Home");
    }

    /*
    // GET /Account/Login — and where [Authorize] sends a visitor, with the
    // page they were trying to reach in ?ReturnUrl=
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    // POST /Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel form, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (!ModelState.IsValid)
        {
            return View(form);
        }

        var result = await _signInManager.PasswordSignInAsync(
            form.Email, form.Password, form.ReEmployeeUserMe, lockoutOnFailure: false);

        if (!result.Succeeded)
        {
            // One message for both mistakes. Saying "wrong password" would tell
            // a stranger that the email has an account.
            ModelState.AddModelError("", "That email and password don't match a EmployeeUser.");
            return View(form);
        }

        // LocalRedirect refuses a ReturnUrl that points at another site.
        return LocalRedirect(returnUrl ?? "/");
    }
    */

    // POST /Account/Logout — a POST, never a link. Any page on the internet
    // can make a browser send a GET.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}