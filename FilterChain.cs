namespace RasterFilters;

public class FilterChain : ColorFilter
{
    public List<ColorFilter> Filters { get; } = new List<ColorFilter>();

    public void Add(ColorFilter filter)
    {
        Filters.Add(filter);
    }

    public override RGB Transform(in RGB color)
    {
        RGB current = color;
        foreach (ColorFilter filter in Filters)
        {
            current = filter.Transform(current);
        }
        return current;
    }
}