using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TP06.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public IActionResult logIn()
    {
        return View("LogIn", "Account"); 
    }
    
    [HttpPost]
    public IActionResult saveLogIn(string username, string password)
    { 
        Usuario usuario = BD.searchUsuario(username, password);
        if (usuario != null)
        {
            HttpContext.Session.SetString("IdUsuario", usuario.ID.ToString());
            BD.ActLogIn(usuario.ID);
            return RedirectToAction("Index", "Home");
        }
        else{
            ViewBag.Mensaje = "Usuario o contraseña incorrectos.";
        }
        
        return View("Login");

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
        return View("Account", "SignIn");
    }
    
    [HttpPost]
    public IActionResult saveSignIn()
    {
        return View();
    }
    
}