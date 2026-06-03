using ISP.Clases;
using ISP.Interfaces;

public static class ISPDemo
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== ISP ===");

        ITrabajador humano = new Humano();
        ITrabajador robot = new Robot();

        humano.Trabajar();
        robot.Trabajar();

        IComedor comedor = new Humano();
        comedor.Comer();
    }
}