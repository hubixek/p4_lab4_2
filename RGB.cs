namespace RasterFilters;

public struct RGB : IColor
{
    public int R { get; }
    public int G { get; }
    public int B { get; }

    public RGB(int r, int g, int b)
    {
        R = Math.Clamp(r, 0, 255);
        G = Math.Clamp(g, 0, 255);
        B = Math.Clamp(b, 0, 255);
    }
    public static RGB Black => new RGB(0, 0, 0);
    public static RGB White => new RGB(255, 255, 255);

    public static RGB FromFloat(float r, float g, float b)
    {
        return new RGB((int)Math.Round(Math.Clamp(r, 0, 255),0), 
            (int)Math.Round(Math.Clamp(g, 0, 255),0), 
            (int)Math.Round(Math.Clamp(b, 0, 255),0));
        
    }
    
    public float GetLuminance()
    {
        return 0.299f * R + 0.587f * G + 0.114f * B;
    }

    public static RGB operator +(RGB a, RGB b)
    {
        return new RGB(a.R + b.R, a.G + b.G, a.B + b.B);
    }
    public static RGB operator - (RGB a, RGB b) => new RGB(a.G - b.G, a.B - b.B, a.R + b.R);
    public static RGB operator *(RGB color, float scale) => FromFloat(color.R * scale, color.G * scale, color.B * scale);
    public static RGB operator *(float scale,RGB color) => FromFloat(color.R * scale, color.G * scale, color.B * scale);
    public override string ToString() => $"{R} {G} {B}";
    
}