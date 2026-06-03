using DIP.Abstracciones;

namespace DIP.Implementaciones
{
    /// <summary>
    /// Implementación concreta para MySQL.
    /// Módulo de bajo nivel que depende de la abstracción IDatabase.
    /// </summary>
    public class MySQLDatabase : IDatabase
    {
        public void Guardar(string datos)
        {
            Console.WriteLine($"[MySQL] Guardando: {datos}");
        }
    }
}
