public class Usuario
{
    public int ID {get; private set;}
    public string Nombre {get; private set;}
    public string Apellido {get; private set;}
    public string Foto {get; private set;}
    public string Username {get; private set;}
    public DateTime UltimoLogin {get; private set;}
    public string Password {get; private set;}

    public Usuario( string Nombre, string Apellido, string Foto, string Username, DateTime UltimoLogin, string Password){
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Foto = Foto;
        this.Username = Username;
        this.UltimoLogin = UltimoLogin;
        this.Password = Password;
    }
    public Usuario (){

    }
}