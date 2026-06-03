public class DescuentoRegular : IDescuento
{
    public double Calcular(double monto)
    {
        return monto * 0.05;
    }
}