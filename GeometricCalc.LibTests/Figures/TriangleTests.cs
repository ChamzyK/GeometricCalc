using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometricCalc.Lib.Figures.Tests;

[TestClass()]
public class TriangleTests
{
    private readonly double _accuracy = 0.001;

    [DataTestMethod]
    [DataRow(17, 15, 8, true)]
    [DataRow(5, 5, 5, false)]
    public void IsRight_Test(double sideA, double sideB, double sideC, bool expResult)
    {
        var triangle = new Triangle(sideA, sideB, sideC);

        var result = triangle.IsRight();

        Assert.AreEqual(expResult, result);
    }

    [DataTestMethod]
    [DataRow(5, 5, 5, true)]
    [DataRow(6, 1, 1, false)]
    [DataRow(0, 0, 0, false)]
    public void IsValid_Test(double sideA, double sideB, double sideC, bool expResult)
    {
        var result = Triangle.IsValid(sideA, sideB, sideC);

        Assert.AreEqual(expResult, result);
    }

    [DataTestMethod]
    [DataRow(-1, 1, 1)]
    [DataRow(1, -1, 1)]
    [DataRow(1, 1, -1)]
    [DataRow(0, 0, 0)]
    [ExpectedException(typeof(ArgumentException))]
    public void SetSides_SetNotValidSides_Test(double sideA, double sideB, double sideC)
    {
        var triangle = new Triangle();
        triangle.SetSides(sideA, sideB, sideC);
    }

    [DataTestMethod]
    [DataRow(4, 5, 3, 6)]
    [DataRow(5, 5, 5, 10.825)]
    [DataRow(34.2, 12.6, 45.32, 116.301)]
    public void Area_CalcValidArea_Test(double sideA, double sideB, double sideC, double expResult)
    {
        var triangle = new Triangle(sideA, sideB, sideC);

        var area = triangle.Area;
        var result = Math.Abs(area - expResult) < _accuracy;

        Assert.IsTrue(result);
    }
}