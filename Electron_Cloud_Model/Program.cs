using System;
using System.IO;

class Program
{
    static void Main()
    {   
        // Simulation Pipeline
        // Quantum Numbers
        int n = 4;
        int l = 3;
        int m = 3;

        // File path. Where you want your file output to go
        string filepath = "/Users/jackson.rankin/Desktop/Student/6/CSE310/Electron_Cloud_Model/Electron_Cloud_Model/";

        // Calculate the orbital. This is really good for getting an image 
        double[,] density = Psi.Orbital(n, l, m, 6*n*n, 6*n*n, 2000 / (6*n*n));

        //density = Plot.LogScale(density);
        density = Plot.GammaNormalize(density, 0.5);
        Plot.PPMWriter(density, $"{filepath}orbital_{n}_{l}_{m}.ppm");

        Console.WriteLine($"Simulation complete for the ({n}, {l}, {m}) orbital");
        Console.WriteLine($"File output at {filepath}.");
    }
}
