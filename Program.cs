using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== PRUEBA SRP ===");

        GeneradorReporte generador = new GeneradorReporte();
        GuardadorArchivo guardador = new GuardadorArchivo();
        EnviadorCorreo enviador = new EnviadorCorreo();

        generador.Generar();
        guardador.Guardar();
        enviador.Enviar();

        Console.WriteLine();

        Console.WriteLine("=== PRUEBA OCP ===");

        IDescuento regular = new DescuentoRegular();
        IDescuento vip = new DescuentoVIP();
        IDescuento premium = new DescuentoPremium();

        Console.WriteLine("Descuento Regular: " + regular.Calcular(1000));
        Console.WriteLine("Descuento VIP: " + vip.Calcular(1000));
        Console.WriteLine("Descuento Premium: " + premium.Calcular(1000));

        Console.WriteLine();

        Console.WriteLine("=== PRUEBA LSP ===");

        Aguila aguila = new Aguila();
        Pinguino pinguino = new Pinguino();

        aguila.Moverse();
        aguila.Volar();

        pinguino.Moverse();

        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine();

        // ISP
        ISPDemo.Ejecutar();

        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine();

        // DIP
        DIPDemo.Ejecutar();

        Console.WriteLine();
        Console.WriteLine("=== FIN DE TODAS LAS PRUEBAS SOLID ===");
    }
}