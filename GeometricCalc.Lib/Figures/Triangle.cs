namespace GeometricCalc.Lib.Figures;

public class Triangle : Figure
{
    private double _sideA;
    private double _sideB;
    private double _sideC;

    public double SideA
    {
        get => _sideA;
        set => SetSize(ref _sideA, value);
    }
    public double SideB
    {
        get => _sideB;
        set => SetSize(ref _sideB, value);
    }
    public double SideC
    {
        get => _sideC;
        set => SetSize(ref _sideC, value);
    }

    public double Perimeter => SideA + SideB + SideC;
    public double HalfPerimeter => Perimeter / 2;
    public double PerimeterAB => HalfPerimeter - SideC;
    public double PerimeterBC => HalfPerimeter - SideA;
    public double PerimeterAC => HalfPerimeter - SideB;

    public bool IsRight()
    {
        var conditionA = SideA * SideA == (SideB * SideB) + (SideC * SideC);
        var conditionB = SideB * SideB == (SideA * SideA) + (SideC * SideC);
        var conditionC = SideC * SideC == (SideB * SideB) + (SideA * SideA);
        return conditionA || conditionB || conditionC;
    }

    public override double Area => Math.Sqrt(HalfPerimeter * PerimeterAB * PerimeterBC * PerimeterAC);

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }
}
