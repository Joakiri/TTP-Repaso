public class Tarea
{
    public int ID {get; private set;}
    
    public string Titulo {get; private set;}
   
    public string Descripcion {get; private set;}
    public DateTime Fecha {get; private set;}
    
    public bool Finalizado {get; private set;}
    
    public int IDUsuario {get; private set;}
    
   

    public Tarea(string Titulo, string Descripcion, DateTime Fecha, bool Finalizado, int IDUsuario){        
        this.Titulo = Titulo;
        this.Descripcion = Descripcion;
        this.Fecha = Fecha;
        this.Finalizado = Finalizado;
        this.IDUsuario = IDUsuario;
    }

    public Tarea(){
        
    }
    
}