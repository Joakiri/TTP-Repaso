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
        if(BD.returnTareaTit(titulo) == null){
            string IDUsuarioStr = HttpContext.Session.GetString("IdUsuario");
            int IDUT = int.Parse(IDUsuarioStr);
            Tarea tar = new Tarea(titulo, descripcion, DateTime.Now, false, IDUT);
            BD.newTarea(tar);
            ViewBag.message = "Tarea agregada con exito";
        }
        else{
            ViewBag.message = "Tarea agregada con exito"; 
        }

        return View("IndexOpciones");
    }
    
    public IActionResult editTarea(){
        return View("ModifyTareaTit");
    }

    [HttpPost]
    public IActionResult endEditTareaTit(string titulo){
        string IDUsuarioStr = HttpContext.Session.GetString("IdUsuario");
        Tarea ttar = BD.returnTareaTit(titulo);
        if(ttar != null){
            ViewBag.tareaa = ttar;
            ViewBag.message = "Tarea encontrada con exito";
            return View("ModifyTarea");//Poner Placeholder en form
        }
        else{
            ViewBag.message = "No se encontro el titulo de la tarea.";
            return View("ModifyTareaTit");
        }
        }
        
       
     [HttpPost]
    public IActionResult endEditTarea(int ID, string ntitulo, string ndescripcion, DateTime nfecha, bool nFinalizado, int nidusuario){
        //Borrar vieja y hacer nueva
        string idUsuarioStr = HttpContext.Session.GetString("IdUsuario");
        Tarea nTar = new Tarea (ID, ntitulo, ndescripcion, nfecha, nFinalizado, nidusuario);
        BD.modifyTarea(ntar);
        return View("ModifyTarea");
    }
    [HttpPost]
    public IActionResult endTarea(int id){
    string idUsuarioStr = HttpContext.Session.GetString("IDUsuario");
        BD.endTarea(id);
        return View("endTarea");
    }
    
}
