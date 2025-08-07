public class Tarea
{
    [JsonProperty]
    public int ID {get; private set;}
    [JsonProperty]
    public string Titulo {get; private set;}
    [JsonProperty]
    public string Descripcion {get; private set;}
    [JsonProperty]
    public DateTime Fecha {get; private set;}
    [JsonProperty]
    public bool Finalizado {get; private set;}
    [JsonProperty]
    public int IDUsuario {get; private set;}
    [JsonProperty]
   

    public Tarea(int ID, string Titulo, string Descripcion, DateTime Fecha, bool Finalizado, int IDUsuario){
        this.ID = ID;
        this.Titulo = Titulo;
        this.Descripcion = Descripcion;
        this.Fecha = Fecha;
        this.Finalizado = Finalizado;
        this.IDUsuario = IDUsuario;
    }

    public Tarea(){
        
    }
    
}