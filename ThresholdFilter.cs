namespace RasterFilters;

public class ThresholdFilter : GrayscaleFilter
{
    public int Threshold { get; }

    public ThresholdFilter(int threshold)
    {
        Threshold = threshold;
    }
    public override RGB Transform(in RGB color)
    {
        RGB  temp = color;
        float l = temp.GetLuminance();
        if (l >= Threshold)
        {
            return RGB.White;
        }
        return RGB.Black;
    }
}