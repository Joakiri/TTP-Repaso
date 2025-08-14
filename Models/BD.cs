using Microsoft.Data.SqlClient;
using Dapper;

namespace TPnoNumero.Models;
public static class BD{
    private static string _connectionString = @"Server=localhost;DataBase=TP06-Repaso;Integrated Security=True;TrustServerCertificate=True;";
}
public void signIn(Usuario user)
{
string query = "INSERT INTO Usarios (Nombre, Apellido, Foto, Username, UltimoLogin, Password) VALUES (@pNombre, @pApellido, @pFoto, @pUsername, @pUltimoLogin, @pPassword)";
using(SqlConnection connection = new SqlConnection(_connectionString))
{
    connection.Execute(query, new {pNombre = user.pNombre, pApellido = user.pApellido, pFoto = user.pFoto, pUsername = user.pUsername, pUltimoLogin = user.pUltimoLogin, pPassword = user.pPassword});
}
}
public Usuario searchUsuario(string username, string password){
return contexto.Usuarios.FirstOrDefault(u => u.Username == username && u.Password == password);
    
}
public Usuario LogIn(string Username, string Password)
{
    Usuario miUser = null;
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
string query = "SELECT * FROM Usuario WHERE Nombre = @pNombre AND @password = @ppassword";
if(query == null){
    
}else{
    miUser = connection.QueryFirstOrDefault<Usuario>(query, new {pNombre = Nombre, ppassword = Password});
}
    }
    return miUser;
}

public static List<Tarea> returnTareas(Tarea IDUsuario)
{
    List<Tarea> tareas = new List<Tarea>(); 
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
    string sql = @"SELECT * FROM Tareas WHERE IDUsuario = @pId";
    tareas = connection.Query<Tarea>(sql, new { pId = usuarioId }).ToList();
    }
    return tareas;
}
public static Tarea returnTarea(Tarea IDT)
{
    Tarea tarea = null; 
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
    string sql = @"SELECT * FROM Tareas WHERE ID = @id";
    tarea = connection.Query<Tarea>(sql, new { id = usuarioId }).ToList();
    }
    return tareas;
}
public static BD modifyTarea(Tarea tarea) //pasar bien el objeto por parametro y es void/bool
{

}
public static BD deleteTarea(Tarea ID) //void
{

}
public static BD newTarea(Tarea tarea) //pasar bien el objeto por parametro y es void/bool
{

}
public static BD endTarea(Tarea ID) //void
{

}
public static BD ActLogIn(Tarea IDUsuario)
{

}