using System.IO;
using System;

class Plot
{
    private static readonly Random random = new Random();
    private static readonly ColorMap colormap = new ColorMap();

    // This function will take a 2D array and output an image file
    public void PPMWriter(double[,] data, string filename)
    {   
        // FInd the dimensions of 'data' 2d array.
        int rows = data.GetLength(0);
        int cols = data.GetLength(1);

        // Normalize the data
        data = Normalize(data);

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
                var (r, g, b) = colormap.Greyscale(value);

                writer.WriteLine($"{r} {g} {b}");
            }
        }
    }

    // This function returns a dataset flled with random values.
    public double[,] RandData(int width, int height)
    {   
        // Initializes the dataset with varible dimensions
        double[,] data = new double[height, width];

        // Iterates through each index
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                // Populates each index with a random double 
                data[y, x] = random.NextDouble();

        return data;
    }

    // Normalize the data from 0 to 1
    public static double[,] Normalize(double[,] data)
    {   
        // Initialize min and max values with minimum and maximum values of double datatype. 
        // This will help handle any singularities
        double min = double.MaxValue;
        double max = double.MinValue;

        // Find the maximum and minimum values for the dataset.
        for (int y = 0; y < data.GetLength(0); y++)
            for (int x = 0; x < data.GetLength(1); x++)
            {   
                // Grabs the data point
                double v = data[y, x];

                // Updates the min and max values to find the true extrema values
                if (v < min) min = v;
                if (v > max) max = v;
            }

        // Normalize the data
        for (int y = 0; y < data.GetLength(0); y++)
            for (int x = 0; x < data.GetLength(1); x++)
                // Linearly squish the data between 0 and 1
                data[y, x] = (data[y, x] - min) / (max - min);

        return data;
    }
}
