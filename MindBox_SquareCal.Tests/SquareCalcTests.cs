using MindBox_SquareCalc.Primitives;

namespace MindBox_SquareCal.Tests;

public class SquareCalcTests
{
    [Fact]
    public void CircleNegativeRadiusTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
    }

    [Fact]
    public void TriangleNegativeSidesTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-10, 0, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, -10, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 0, -10));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-10, -10, -10));
    }

    [Fact]
    public void CircleSqrCalculationTest()
    {
        var circle = new Circle(10);

        var circleSquare = circle.Square;

        Assert.Equal(314.15926535897931, circleSquare);
    }

    [Fact]
    public void TriangleSqrCalculationTest()
    {
        var triangle = new Triangle(3, 4, 5);

        var triangleSquare = triangle.Square;

        Assert.Equal(6, triangleSquare);
    }

    [Fact]
    public void RightAngleTriangleTest()
    {
        var triangle = new Triangle(3, 4, 5);

        var isTriangleRightAngled = triangle.IsRightTriangle;

        Assert.True(isTriangleRightAngled);
    }

    [Fact]
    public void NotRightAngleTriangleTest()
    {
        var triangle = new Triangle(6, 2, 5);

        var isTriangleRightAngled = triangle.IsRightTriangle;

        Assert.False(isTriangleRightAngled);
    }
}