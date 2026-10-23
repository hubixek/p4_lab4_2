namespace RasterFilters;

public struct Pixel
{
    private RGB _color =  new RGB();
    public RGB Color
    {
        get { return _color; }
        set { _color = value; }
    }
    public byte Alpha { get; set; }
    public bool IsOpaque => Alpha == 255;
    public Pixel(RGB color, byte alpha)
    {
        _color = color;
        Alpha = alpha;
    }

    public override string ToString() => $"{Color} a:{Alpha}";
}