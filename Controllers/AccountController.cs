using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TP06.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public IActionResult logIn()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult saveLogIn()
    {
        return View();  
    }
    
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult logOut()
    {
        return View();
    }
    public IActionResult signIn()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult saveSignIn()
    {
        return View();
    }
    
}