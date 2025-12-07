using System.IO;
using System;

class Plot
{
    private static readonly Random random = new Random();
    private static readonly ColorMap colormap = new ColorMap();

    // This function will take a 2D array and output an image file
    public static void PPMWriter(double[,] data, string filename)
    {   
        // Find the dimensions of the 2d array data
        int rows = data.GetLength(0);
        int cols = data.GetLength(1);

        // Start file output
        using var writer = new StreamWriter(filename);

        // Header of the file output
        writer.WriteLine("P3");              // Type of PPM file
        writer.WriteLine($"{rows} {cols}");  // Dimensions
        writer.WriteLine("255");             // Maximum color channel value (255 would be SDR, 24-bit color. 16383 would be 48-bit color)

        // Data
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                double value = data[y, x];
                var (r, g, b) = colormap.Gradient(value);

                writer.WriteLine($"{r} {g} {b}");
            }
        }
    }

    // This function returns a dataset filled with random values.
    public double[,] RandData(int width, int height)
    {   
        // Initializes the dataset with variable dimensions
        double[,] data = new double[height, width];

        // Iterates through each index
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                // Populates each index with a random double 
                data[y, x] = random.NextDouble();

        return data;
    }

    // This function will find the probability distribution from the value of the wavefunction
    public double[,] PDist(double[,] psi)
    {
        // Find the dimensions of the data
        int rows = psi.GetLength(0);
        int cols = psi.GetLength(1);

        // 2D double to hold the dist
        double[,] prob = new double[rows, cols];
        double noise_floor = 1e-30; // Define a numerical noise floor

        for (int y = 0; y < rows; y++)
            for (int x = 0; x < cols; x++)
            {
                double psi_sq = psi[y, x] * psi[y, x];
                if (psi_sq < noise_floor) 
                {
                    prob[y, x] = 0.0;
                }
                else
                {
                    prob[y, x] = psi_sq;
                }
            }

        return prob;
    }

    // Normalize the data from 0 to 1
    public static double[,] Normalize(double[,] data)
    {
        double min = double.MaxValue;
        double max = double.MinValue;

        // Find extrema
        for (int y = 0; y < data.GetLength(0); y++)
            for (int x = 0; x < data.GetLength(1); x++)
            {
                double v = data[y, x];
                if (v < min) min = v;
                if (v > max) max = v;
            }

        // Prevent divide-by-zero
        if (Math.Abs(max - min) < 1e-14)
        {
            for (int y = 0; y < data.GetLength(0); y++)
                for (int x = 0; x < data.GetLength(1); x++)
                    data[y, x] = 0.0;

            return data;
        }

        // Normalize
        for (int y = 0; y < data.GetLength(0); y++)
            for (int x = 0; x < data.GetLength(1); x++)
                data[y, x] = (data[y, x] - min) / (max - min);

        return data;
    }

    
    public static double[,] LogScale(double[,] data)
    {
        int h = data.GetLength(0);
        int w = data.GetLength(1);
        double[,] outD = new double[h,w];

        for(int y=0;y<h;y++)
            for(int x=0;x<w;x++)
                outD[y,x] = Math.Log10(data[y,x] + 1e-30);

        return outD;
    }

    public static double[,] GammaNormalize(double[,] data, double gamma)
    {
        int h = data.GetLength(0);
        int w = data.GetLength(1);

        double min = double.MaxValue;
        double max = double.MinValue;

        for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
            {
                double v = data[y, x];
                if (v < min) min = v;
                if (v > max) max = v;
            }

        double range = max - min;
        double[,] norm = new double[h, w];

        for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
            {
                double v = (data[y, x] - min) / range;
                norm[y, x] = Math.Pow(v, gamma);
            }

        return norm;
    }
}
