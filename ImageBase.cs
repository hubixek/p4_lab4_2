using System.Text;

namespace RasterFilters;

public abstract class ImageBase
{
    public int Width { get; }
    public int Height { get; }

    protected ImageBase(int width, int height)
    {
        Width = width;
        Height = height;
    }
    public abstract Pixel this[int x, int y] { get; set; }

    public bool Contains(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }

    public bool TryGetPixel(int x, int y, out Pixel pixel)
    {
        if (Contains(x, y))
        {
            pixel = this[x, y];
            return true;
        }
        pixel = default;
        return false;
    }

    public void Fill(IColor color)
    {
        RGB rgb = new RGB(color.R, color.G, color.B);

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                this[x, y] = new Pixel(rgb, 255);
            }
        }
    }

    public int[] GetHistogram()
    {
        int[] histogram = new int[256];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                float luminance = this[x, y].Color.GetLuminance();
                int k = (int)MathF.Round(luminance);
                histogram[k]++;
            }
        }
        return histogram;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("P3");
        sb.AppendLine($"{Width} {Height}");
        sb.AppendLine("255");
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (x > 0)
                {
                    sb.Append(' ');
                }
                sb.Append(this[x, y].Color);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}