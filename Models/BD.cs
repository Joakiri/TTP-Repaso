using Microsoft.Data.SqlClient;
using Dapper;

namespace TPnoNumero.Models;
public static class BD{
    private static string _connectionString = @"Server=localhost;DataBase=TP06-Repaso;Integrated Security=True;TrustServerCertificate=True;";
}
public static BD signIn(Usuario usuario) //pasar bien el objeto por parametro y es void/bool
{

}
public static BD LogIn(Usuario username, Usuario Password)
{

}
public static BD returnTareas(Tarea IDUsuario)
{
    using var connection = new SqlConnection(_connectionString);
    string sql = @"SELECT * FROM Tareas WHERE UsuarioId = @id AND FechaEliminacion IS NULL";
    return connection.Query<Tarea>(sql, new { id = usuarioId }).ToList();
}
public static BD returnTarea(Tarea ID)
{

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