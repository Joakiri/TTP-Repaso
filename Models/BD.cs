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
    
    public static Usuario getUsuarioByUsername(string username)
    {
        Usuario usuario = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE Username = @PUsername";
            usuario = connection.QueryFirstOrDefault<Usuario>(query, new { PUsername = username });
        }
        return usuario;
    }
        
    public static bool searchUsername(string username)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE Username = @pUsername";
            Usuario usuario = connection.QueryFirstOrDefault<Usuario>(query, new { pUsername = username });
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

public static List<Tarea> returnTareas(string IDUsuario)
{
    List<Tarea> tareas = new List<Tarea>(); 
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
    string sql = @"SELECT * FROM Tareas WHERE IDUsuario = @pId";
    tareas = connection.Query<Tarea>(sql, new { pId = IDUsuario }).ToList();
    }
    return tareas;
}
public static Tarea returnTarea(int Id)
{
    Tarea tarea = null; 
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
    string sql = @"SELECT * FROM Tareas WHERE ID = @id";
    tarea = connection.QueryFirstOrDefault<Tarea>(sql, new {id = Id});
    }
    return tarea;
}
public static Tarea returnTareaTit(string titulo)
{
    Tarea tarea = null; 
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
    string sql = @"SELECT * FROM Tareas WHERE Titulo = @ptitulo";
    tarea = connection.QueryFirstOrDefault<Tarea>(sql, new {ptitulo = titulo});
    }
    return tarea;
}
public  static void modifyTarea(Tarea tarea, int ID)
{
string query = @"UPDATE Tareas SET Titulo = @pTitulo, Descripcion = @pDescripcion, Fecha = @pFecha, Finalizado = @pFinalizado WHERE ID = @pID";   
using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Execute(query, new
        {
            pTitulo = tarea.Titulo,
            pDescripcion = tarea.Descripcion,
            pFecha = tarea.Fecha,
            pFinalizado = tarea.Finalizado,
            pID = ID
        });
    }
}
public static void newTarea(Tarea tarea) 
{
 string query = @"INSERT INTO Tareas (Titulo, Descripcion, Fecha, Finalizado, IDUsuario)
                     VALUES (@Titulo, @Descripcion, @Fecha, @Finalizado, @IDUsuario)";
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Execute(query, new
        {
            Titulo = tarea.Titulo,
            Descripcion = tarea.Descripcion,
            Fecha = tarea.Fecha,
            Finalizado = tarea.Finalizado,
            IDUsuario = tarea.IDUsuario
        });
    }
}
public  static void endTarea(int id) 
{
    string query = "UPDATE Tareas SET Finalizado = 1 WHERE Id = @Id";
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Execute(query, new { Id = id });
    }
}
public static void deleteTarea(int id){
   string query = @"DELETE FROM Tareas WHERE ID = @ID";    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Execute(query, new { ID = id });
    }  
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