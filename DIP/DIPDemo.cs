using DIP.Implementaciones;
using DIP.Servicios;

public static class DIPDemo
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== Dependency Inversion Principle (DIP) ===\n");

        // --- Con MySQL ---
        Console.WriteLine(">> Usando MySQL:");
        var serviceMySQL = new UsuarioService(new MySQLDatabase());
        serviceMySQL.CrearUsuario("Ana García");

        // --- Con PostgreSQL ---
        Console.WriteLine(">> Usando PostgreSQL:");
        var servicePostgres = new UsuarioService(new PostgreSQLDatabase());
        servicePostgres.CrearUsuario("Luis Pérez");

        // --- Con InMemory ---
        Console.WriteLine(">> Usando InMemory (pruebas unitarias):");
        var dbMemoria = new InMemoryDatabase();
        var serviceMemoria = new UsuarioService(dbMemoria);
        serviceMemoria.CrearUsuario("Carlos Test");

        Console.WriteLine(">> Registros en memoria:");
        foreach (var r in dbMemoria.ObtenerRegistros())
            Console.WriteLine($"   - {r}");

        Console.WriteLine("\n=== Fin DIP ===");
        Console.WriteLine("UsuarioService nunca fue modificado. Solo se cambió la implementación inyectada.");
    }
}