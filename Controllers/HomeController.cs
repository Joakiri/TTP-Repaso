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
        return View();
    }
    public IActionResult newTarea(){

    }

    [HttpPost]
    public IActionResult saveNewTarea(){

    }
    
    public IActionResult editTarea(){

    }

    [HttpPost]
    public IActionResult endEditTarea(){

    }
    public IActionResult deleteTarea(){

    }
    public IActionResult endTarea(){

    }
    
}
