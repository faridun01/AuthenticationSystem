using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuthenticationSystem.Models;
using Microsoft.AspNetCore.Identity;
using AuthenticationSystem.Areas.Identity.Data;

namespace AuthenticationSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AuthentificationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<AuthentificationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        ViewBag.FirstName = user?.FirsName; 
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
