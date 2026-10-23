namespace RasterFilters;

public interface IColor
{
    int R { get; }
    int G { get; }
    int B { get; }
    float GetLuminance();
}