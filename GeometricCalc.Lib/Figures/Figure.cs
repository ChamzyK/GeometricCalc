namespace GeometricCalc.Lib.Figures;

public abstract class Figure
{
    public abstract double Area { get; }

    protected static void SetSize(ref double oldSize, double newSize)
    {
        if (newSize < 0)
        {
            throw new ArgumentException($"Triangle side size cannot be less than zero", nameof(newSize));
        }
        oldSize = newSize;
    }
}
