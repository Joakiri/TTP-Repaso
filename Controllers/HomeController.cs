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

    public IActionResult IndexOpciones()
    {
        return View("IndexOpciones");
    }
    public IActionResult showTareas(){
        List<Tarea> Tareas = new List<Tarea>();
        string IDUsuarioStr = HttpContext.Session.GetString("IdUsuario");
        Tareas = BD.returnTareas(IDUsuarioStr);
        ViewBag.Tareas = Tareas;
        return View("ShowTareas");
    }
    public IActionResult newTarea(){
        return View("NewTarea");
    }

    [HttpPost]
    public IActionResult saveNewTarea(string titulo, string descripcion){
        string IDUsuarioStr = HttpContext.Session.GetString("IdUsuario");
        int IDUT = int.Parse(IDUsuarioStr);
        Tarea tar = new Tarea(titulo, descripcion, DateTime.Now, false, IDUT);
        BD.newTarea(IDUsuarioStr, tar);
        ViewBag.message = "Tarea agregada con exito";
        return View("IndexOpciones");
    }
    
    public IActionResult editTarea(){
        return View("ModifyTarea");
    }

    [HttpPost]
    public IActionResult endEditTarea(){
        string IDUsuarioStr = HttpContext.Session.GetString("IdUsuario");//HACER
        int IDUT = int.Parse(IDUsuarioStr);
        Tarea tar = new Tarea(titulo, descripcion, DateTime.Now, false, IDUT);
        BD.newTarea(IDUsuarioStr, tar);
        ViewBag.message = "Tarea agregada con exito";
        return View("IndexOpciones");
    }
    public IActionResult endTarea(){

        return View("endTarea");
    }
    
}
