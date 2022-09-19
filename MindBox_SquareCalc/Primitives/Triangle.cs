namespace MindBox_SquareCalc.Primitives;

public class Triangle : BaseShape
{
  
    public double FirstSide { get; init; }

    public double SecondSide { get; init; }

    public double ThirdSide { get; init; }

    public bool IsRightTriangle { get; init; }


    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        if (firstSide < 0 || secondSide < 0 || thirdSide < 0)
            throw new ArgumentOutOfRangeException("Сторона не может быть отрицательной");

        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;

        IsRightTriangle = IsRight();
        Square = CalculateSuare();
    }

    private bool IsRight()
    {
        var maxSide = new[] { FirstSide, SecondSide, ThirdSide }.Max();
        var maxSideSqr = maxSide * maxSide;

        return maxSideSqr + maxSideSqr == FirstSide * FirstSide + SecondSide * SecondSide + ThirdSide * ThirdSide;
    }

    protected sealed override double CalculateSuare()
    {
        var semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;

        var firstSideCoefficient = semiPerimeter - FirstSide;
        var secondSideCoefficient = semiPerimeter - SecondSide;
        var thirdSideCoefficient = semiPerimeter - ThirdSide;

        return Math.Sqrt(semiPerimeter * firstSideCoefficient * secondSideCoefficient * thirdSideCoefficient);
    }
}
