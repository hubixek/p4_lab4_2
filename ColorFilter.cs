namespace RasterFilters;

public abstract class ColorFilter
{
    public abstract RGB Transform(in RGB color);

    public virtual void ApplyTo(ref Pixel pixel)
    {
        pixel.Color = Transform(pixel.Color);
    }

    public void Apply(ImageBase image)
    {
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Pixel pixel = image[x, y];
                ApplyTo(ref pixel);
                image[x, y] = pixel;
            }
        }
    }
}