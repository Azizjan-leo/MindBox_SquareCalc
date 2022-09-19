namespace MindBox_SquareCalc.Primitives;

public class Circle : BaseShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        if(radius < 0)
            throw new ArgumentOutOfRangeException("The radius must be positive.");

        Radius = radius;
        Square = CalculateSuare();
    }

    protected sealed override double CalculateSuare()
    {
        return Math.PI * Radius * Radius;
    }
}
