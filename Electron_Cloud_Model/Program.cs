using System;
using System.IO;

class Program
{
    static void Main()
    {   
        // Quantum Numbers
        int n = 4;
        int l = 0;
        int m = 0;

        // Calculate the orbital
        double[,] density = Psi.Orbital(n, l, m, 50, 50, 50);

        //density = Plot.LogScale(density);
        density = Plot.Normalize(density);
        Plot.PPMWriter(density, $"/Users/jackson.rankin/Desktop/Student/6/CSE310/Electron_Cloud_Model/Electron_Cloud_Model/orbital_{n}_{l}_{m}.ppm");
    }
}
