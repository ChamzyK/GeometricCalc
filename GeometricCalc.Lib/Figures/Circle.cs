namespace GeometricCalc.Lib.Figures;

public class Circle : Figure
{
    private double _radius;
    public double Radius 
    { 
        get => _radius;
        set => SetSize(ref _radius, value); 
    }

    public override double Area => Math.PI * Radius * Radius;
}
