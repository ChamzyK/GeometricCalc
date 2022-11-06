using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometricCalc.Lib.Figures.Tests;

[TestClass()]
public class CircleTests
{
    private readonly double _accuracy = 0.001;

    [DataTestMethod]
    [DataRow(0, 0)]
    [DataRow(456.212, 653857.759)]
    [DataRow(3, 28.274)]
    public void Area_CalcValidArea_Test(double radius, double expArea)
    {
        var circle = new Circle { Radius = radius };

        var area = circle.Area;
        var result = Math.Abs(expArea - area) < _accuracy;

        Assert.IsTrue(result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Radius_SetNotValidRadius_Test()
    {
        var circle = new Circle { Radius = -1 };
    }
}