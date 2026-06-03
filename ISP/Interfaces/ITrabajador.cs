namespace ISP.Interfaces
{
    /// <summary>
    /// Interfaz específica para entidades que pueden trabajar.
    /// Aplica ISP: separada de IComedor para no obligar a implementar
    /// métodos innecesarios.
    /// </summary>
    public interface ITrabajador
    {
        void Trabajar();
    }
}
