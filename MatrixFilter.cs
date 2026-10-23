namespace RasterFilters;

public class MatrixFilter
{
    private readonly float[,] _kernel;
    public int Size { get; private set; }

    public MatrixFilter(float[,] kernel)
    {
        _kernel = kernel;
        Size = kernel.GetLength(0);
    }

    public static MatrixFilter BoxBlur(int size)
    {
        float[,] kernel = new float[size, size];
        float weight = 1.0f / (size * size);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                kernel[i, j] = weight;
            }
        }

        return new MatrixFilter(kernel);
    }
    private static void Accumulate(in RGB color, float weight, ref float r, ref float g, ref float b)
    {
        r += weight * color.R;
        g += weight * color.G;
        b += weight * color.B;
    }

    public Image Apply(ImageBase source)
    {
        Image result = new Image(source.Width, source.Height);
        int radius = (Size - 1) / 2;

        for (int y = 0; y < source.Height; y++)
        {
            for (int x = 0; x < source.Width; x++)
            {
                float r = 0, g = 0, b = 0;

                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        int sx = Math.Clamp(x + j - radius, 0, source.Width - 1);
                        int sy = Math.Clamp(y + i - radius, 0, source.Height - 1);
                        Accumulate(source[sx, sy].Color, _kernel[i, j], ref r, ref g, ref b);
                    }
                }

                result[x, y] = new Pixel(RGB.FromFloat(r, g, b), source[x, y].Alpha);
            }
        }

        return result;
    }
}