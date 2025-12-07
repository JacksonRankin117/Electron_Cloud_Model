using System.Diagnostics;

class Program
{
    static void Main()
    {   
        // ************************************************** Simulation Pipeline **************************************************
        // Stopwatch:
        Stopwatch sw = new Stopwatch();
        sw.Start();

        // Quantum Numbers
        int n = 5;
        int l = 3;
        int m = 2;

        // File path. Change this to your desired file destination.
        // i.e. C:\Users\jackson.rankin\Desktop\Projects\Electron_Cloud_Model\
        string filepath = "";

        // Calculate the orbital. This is really good for getting an image. I wouldn't recommend changing these arguments
        // They are set up in a way to get pretty good image resolution (2000 x 2000), and keeps the scaling fairly constant per 
        // orbital
        double[,] density = Psi.Orbital(n, l, m, 6*n*n, 6*n*n, 10000 / (6*n*n));

        // NOTE: Since these algorithms are fairly quick, you probably don't have to wait that long for images that are 
        // ~10,000 pixels wide

        // This scales the data to produce better visualizations. This helps brighten smaller values, while keeping large values
        // tame.
        density = Plot.GammaNormalize(density, 0.5);

        // Output to a file, i.e. orbital_5_3_2.ppm
        Plot.PPMWriter(density, $"{filepath}orbital_{n}_{l}_{m}.ppm");

        // Stop the stopwatch
        sw.Stop();

        // Text output signaling the completion of the render.
        Console.WriteLine($"Simulation complete for the ({n}, {l}, {m}) orbital");
        Console.WriteLine($"Render time: {sw.Elapsed.TotalSeconds:F3} s");
        Console.WriteLine($"File output at {filepath}");
    }
}
