using DIP.Abstracciones;

namespace DIP.Implementaciones
{
    /// <summary>
    /// Implementación en memoria, ideal para pruebas unitarias.
    /// No requiere conexión real a una base de datos.
    /// Demuestra cómo DIP facilita el testing.
    /// </summary>
    public class InMemoryDatabase : IDatabase
    {
        private readonly List<string> _registros = new();

        public void Guardar(string datos)
        {
            _registros.Add(datos);
            Console.WriteLine($"[InMemory] Guardando en memoria: {datos}");
        }

        public IReadOnlyList<string> ObtenerRegistros() => _registros.AsReadOnly();
    }
}
