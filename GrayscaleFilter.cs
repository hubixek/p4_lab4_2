namespace RasterFilters;

public class GrayscaleFilter : ColorFilter
{
    public override RGB Transform(in RGB color)
    {
        RGB  temp = color;
        float l = temp.GetLuminance();
        return RGB.FromFloat(l,l,l);
    }
}