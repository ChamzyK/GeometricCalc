namespace GeometricCalc.Lib.Figures;

public class Triangle : Figure
{
    private double _sideA;
    private double _sideB;
    private double _sideC;

    public double SideA { get => _sideA; }
    public double SideB { get => _sideB; }
    public double SideC { get => _sideC; }

    public double Perimeter => SideA + SideB + SideC;
    public double HalfPerimeter => Perimeter / 2;
    public double PerimeterAB => HalfPerimeter - SideC;
    public double PerimeterBC => HalfPerimeter - SideA;
    public double PerimeterAC => HalfPerimeter - SideB;

    public override double Area => Math.Sqrt(HalfPerimeter * PerimeterAB * PerimeterBC * PerimeterAC);

    public Triangle(double sideA = 1, double sideB = 1, double sideC = 1)
    {
        SetSides(sideA, sideB, sideC);
    }

    public void SetSides(double sideA, double sideB, double sideC)
    {
        if (!IsValid(sideA, sideB, sideC))
        {
            throw new ArgumentException("Not valid sides for a triangle");
        }
        SetSize(ref _sideA, sideA);
        SetSize(ref _sideB, sideB);
        SetSize(ref _sideC, sideC);
    }

    public bool IsRight()
    {
        var isHypotenuseA = IsHypotenuse(SideA, SideB, SideC);
        var isHypotenuseB = IsHypotenuse(SideB, SideA, SideC);
        var isHypotenuseC = IsHypotenuse(SideC, SideB, SideA);
        return isHypotenuseA || isHypotenuseB || isHypotenuseC;
    }

    private static bool IsHypotenuse(double hypotenuse, double firstLeg, double secondLeg)
    {
        return hypotenuse * hypotenuse == (firstLeg * firstLeg) + (secondLeg * secondLeg);
    }

    public static bool IsValid(double sideA, double sideB, double sideC)
    {
        var validSideA = sideA < sideB + sideC;
        var validSideB = sideB < sideA + sideC;
        var validSideC = sideC < sideB + sideA;
        return validSideA && validSideB && validSideC;
    }
}
