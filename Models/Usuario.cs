public class Usuario
{
    [JsonProperty]
    public int ID {get; private set;}
    [JsonProperty]
    public string Nombre {get; private set;}
    [JsonProperty]
    public string Apellido {get; private set;}
    [JsonProperty]
    public string Foto {get; private set;}
    [JsonProperty]
    public string Username {get; private set;}
    [JsonProperty]
    public DateTime UltimoLogin {get; private set;}
    [JsonProperty]
    public string Password {get; private set;}
    [JsonProperty]

    public usuario(int ID, string Nombre, string Apellido, string Foto, string Username, DateTime UltimoLogin, string Password){
        this.ID = ID;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Foto = Foto;
        this.Username = Username;
        this.UltimoLogin = UltimoLogin;
        this.Password = Password;
    }
    public usuario (){

    }
}