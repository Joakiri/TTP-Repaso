using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TP06.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public IActionResult logIn()
    {
        return View("LogIn"); 
    }
    
    [HttpPost]
    public IActionResult saveLogIn(string username, string password)
    { 
        Usuario usuario = BD.searchUsuario(username, password);
        if (usuario != null)
        {
            HttpContext.Session.SetString("IdUsuario", usuario.ID.ToString());
            BD.ActLogIn(usuario.ID);
            return RedirectToAction("IndexOpciones", "Home"); 
        }
        else
        {
            ViewBag.message = "Usuario o contraseña incorrectos.";
            return View("Login");
        }
}
    
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult logOut()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
    public IActionResult signIn()
    {
        return View("SignIn");
    }
    
    [HttpPost]
    public IActionResult saveSignIn(string nombre, string apellido, string foto, string username, string password)
    {
        if (!BD.searchUsername(username))
        {
            ViewBag.message = "El nombre de usuario ya existe.";
            return View("SignIn"); 
        }
        else
        {
            Usuario usuario = new Usuario(nombre, apellido, foto, username, DateTime.Now, password);
            BD.signIn(usuario);
            return RedirectToAction("IndexOpciones", "Home"); 
        }
    }
    
}