using Microsoft.Data.SqlClient;
using Dapper;
namespace TP06.Models;
public static class BD{
    private static string _connectionString = @"Server=localhost;DataBase=TP06-Repaso;Integrated Security=True;TrustServerCertificate=True;";

public static void signIn(Usuario user)
{
    string query = "INSERT INTO Usuarios (Nombre, Apellido, Foto, Username, UltimoLogin, Password) VALUES (@pNombre, @pApellido, @pFoto, @pUsername, @pUltimoLogin, @pPassword)";
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
    connection.Execute(query, new {pNombre = user.Nombre, pApellido = user.Apellido, pFoto = user.Foto, pUsername = user.Username, pUltimoLogin = user.UltimoLogin, pPassword = user.Password});
    }
}
public static Usuario searchUsuario(string username, string password){
        Usuario usuario = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE Username = @PUsername AND Password = @PPassword";
            usuario = connection.QueryFirstOrDefault<Usuario>(query, new { PUsername = username, PPassword = password});
        }
        return usuario;
    }  
    public static bool searchUsername(string username)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE Username = @Username";
            Usuario usuario = connection.QueryFirstOrDefault<Usuario>(query, new { Username = username });
            return usuario == null;
        }
    }

public static Usuario LogIn(string Username, string Password)
{
    Usuario miUser = null;
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Usuario WHERE Nombre = @pNombre AND @password = @ppassword";
        if(query == null){
    
        }
        else
        {
            miUser = connection.QueryFirstOrDefault<Usuario>(query, new {pUser = Username, ppassword = Password});
        }
    }
    return miUser;
}

public static List<Tarea> returnTareas(int IDUsuario)
{
    List<Tarea> tareas = new List<Tarea>(); 
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
    string sql = @"SELECT * FROM Tareas WHERE IDUsuario = @pId";
    tareas = connection.Query<Tarea>(sql, new { pId = IDUsuario }).ToList();
    }
    return tareas;
}
public static Tarea returnTarea(int IDTarea)
{
    Tarea tarea = null; 
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
    string sql = @"SELECT * FROM Tareas WHERE ID = @id";
    tarea = connection.QueryFirstOrDefault<Tarea>(sql, new {Id = IDTarea});
    }
    return tarea;
}
public  static void modifyTarea(Tarea tarea) //pasar bien el objeto por parametro y es void/bool
{

}
public  static void deleteTarea(Tarea ID) //void
{

}
public static void newTarea(Tarea tarea) //pasar bien el objeto por parametro y es void/bool
{

}
public  static void endTarea(Tarea ID) //void
{

}
public  static void ActLogIn(int IDUsuario)
{

    string query = "UPDATE Usuarios SET UltimoLogin = GETDATE() WHERE Id = @Id";
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Execute(query, new { Id = IDUsuario });
    }
}
}