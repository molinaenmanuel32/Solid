namespace ISP.Interfaces
{
    /// <summary>
    /// Interfaz específica para entidades que pueden comer.
    /// Solo los seres que realmente comen implementan esta interfaz.
    /// </summary>
    public interface IComedor
    {
        void Comer();
    }
}
