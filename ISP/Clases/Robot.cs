using ISP.Interfaces;

namespace ISP.Clases
{
    /// <summary>
    /// El robot SOLO implementa ITrabajador porque no come.
    /// ISP evita que tenga que implementar Comer() con un throw.
    /// </summary>
    public class Robot : ITrabajador
    {
        public void Trabajar()
        {
            Console.WriteLine("Robot trabajando...");
        }
    }
}
