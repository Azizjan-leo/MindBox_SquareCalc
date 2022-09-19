namespace MindBox_SquareCalc;

public abstract class BaseShape
{
	public double Square { get; init; }

	public BaseShape()
	{
		Square = CalculateSuare();
	}

	protected abstract double CalculateSuare();
}
