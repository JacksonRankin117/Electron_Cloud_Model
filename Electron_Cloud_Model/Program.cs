using System;
using System.IO;

class Program
{
    static void Main()
    {
        Plot plot = new Plot();

        double[,] data = plot.RandData(400, 400);
        plot.PPMWriter(data, "/Users/jackson.rankin/Desktop/Student/6/CSE310/Electron_Cloud_Model/Electron_Cloud_Model/output.ppm");
    }
}
