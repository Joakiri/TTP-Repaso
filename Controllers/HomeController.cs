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
    public IActionResult saveNewTarea(string titulo, string descripcion, DateTime fecha){
        if(BD.returnTareaTit(titulo) == null){
            string IDUsuarioStr = HttpContext.Session.GetString("IdUsuario");
            int IDUT = int.Parse(IDUsuarioStr);
            Tarea tar = new Tarea(titulo, descripcion, fecha, false, IDUT);
            BD.newTarea(tar);
            ViewBag.message = "Tarea agregada con exito";
            return RedirectToAction("showTareas");
        }
        else{
            ViewBag.message = "No se pudo agregar la tarea"; 
            return View("NewTarea");
        }

        
    }
    
    public IActionResult editTarea(int id){
        Tarea tarea = BD.returnTarea(id);
        ViewBag.tareaa = tarea;
        return View("ModifyTarea");
    }

       
     [HttpPost]
    public IActionResult endEditTarea(int ID, string ntitulo, string ndescripcion, DateTime nfecha, int nidusuario){
        Tarea nTar = new Tarea (ntitulo, ndescripcion, nfecha, false , nidusuario);
        BD.modifyTarea(nTar);
        return View("ModifyTarea");
    }


    public IActionResult endTarea(int id){
        BD.endTarea(id);
        return RedirectToAction("showTareas");
    }
    public IActionResult deleteTarea(int id){
        BD.deleteTarea(id);
        return RedirectToAction("showTareas");
    }
    
}
