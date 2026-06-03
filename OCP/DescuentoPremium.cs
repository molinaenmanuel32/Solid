public class DescuentoPremium : IDescuento
{
    public double Calcular(double monto)
    {
        return monto * 0.15;
    }
}