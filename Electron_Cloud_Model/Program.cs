using System;
using System.IO;

class Program
{
    static void Main()
    {   
        // Quantum Numbers
        int n = 1;
        int l = 0;
        int m = 0;

        // Calculate the orbital
        double[,] data = Psi.Orbital(n, l, m, 30, 30, 100);
        Plot.PPMWriter(data, $"/Users/jackson.rankin/Desktop/Student/6/CSE310/Electron_Cloud_Model/Electron_Cloud_Model/orbital_{n}_{l}_{m}.ppm");
    }
}
