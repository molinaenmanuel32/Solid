using DIP.Abstracciones;

namespace DIP.Implementaciones
{
    /// <summary>
    /// Implementación concreta para PostgreSQL.
    /// Se puede intercambiar con MySQLDatabase sin modificar UsuarioService.
    /// </summary>
    public class PostgreSQLDatabase : IDatabase
    {
        public void Guardar(string datos)
        {
            Console.WriteLine($"[PostgreSQL] Guardando: {datos}");
        }
    }
}
