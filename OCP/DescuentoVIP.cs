public class DescuentoVIP : IDescuento
{
    public double Calcular(double monto)
    {
        return monto * 0.10;
    }
}