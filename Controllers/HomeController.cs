using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TP06.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult showTareas(){
        BD.returnTareas(1);
        return View();
    }
    public IActionResult newTarea(){
        return View();
    }

    [HttpPost]
    public IActionResult saveNewTarea(){
        return View();
    }
    
    public IActionResult editTarea(){
        return View();
    }

    [HttpPost]
    public IActionResult endEditTarea(){
        return View();
    }
    public IActionResult deleteTarea(){
        return View();
    }
    public IActionResult endTarea(){
        return View();
    }
    
}
