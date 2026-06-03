using ISP.Interfaces;

namespace ISP.Clases
{
    /// <summary>
    /// El humano implementa AMBAS interfaces porque puede trabajar y comer.
    /// No hay métodos innecesarios: cada uno tiene sentido para esta clase.
    /// </summary>
    public class Humano : ITrabajador, IComedor
    {
        public void Trabajar()
        {
            Console.WriteLine("Humano trabajando...");
        }

        public void Comer()
        {
            Console.WriteLine("Humano comiendo...");
        }
    }
}
