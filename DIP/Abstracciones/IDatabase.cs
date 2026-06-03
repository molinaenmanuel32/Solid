namespace DIP.Abstracciones
{
    /// <summary>
    /// Abstracción que define el contrato para cualquier base de datos.
    /// Los módulos de alto nivel dependen de esta interfaz, no de implementaciones concretas.
    /// </summary>
    public interface IDatabase
    {
        void Guardar(string datos);
    }
}
