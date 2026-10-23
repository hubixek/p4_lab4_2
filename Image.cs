namespace RasterFilters;

public class Image : ImageBase
{
    private readonly Pixel[,] _pixels;

    public Image(int width, int height) : base(width, height)
    {
        _pixels = new Pixel[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                _pixels[x, y] = new Pixel(RGB.Black, 255);
            }
        }
    }

    public override Pixel this[int x, int y] { get => _pixels[x, y]; set => _pixels[x, y] = value; }
}