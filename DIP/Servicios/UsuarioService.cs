using DIP.Abstracciones;

namespace DIP.Servicios
{
    /// <summary>
    /// Módulo de alto nivel. Depende de la abstracción IDatabase,
    /// no de ninguna implementación concreta (MySQL, PostgreSQL, etc.).
    /// La dependencia se inyecta por constructor (Dependency Injection).
    /// </summary>
    public class UsuarioService
    {
        private readonly IDatabase _db;

        // Inyección de dependencias por constructor
        public UsuarioService(IDatabase db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void CrearUsuario(string nombre)
        {
            Console.WriteLine($"Creando usuario '{nombre}'...");
            _db.Guardar($"Usuario: {nombre}");
            Console.WriteLine("Usuario creado correctamente.\n");
        }
    }
}
