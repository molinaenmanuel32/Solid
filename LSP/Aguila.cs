using System;

public class Aguila : IAve, IAveVoladora
{
    public void Moverse()
    {
        Console.WriteLine("El águila se mueve");
    }

    public void Volar()
    {
        Console.WriteLine("El águila vuela");
    }
}