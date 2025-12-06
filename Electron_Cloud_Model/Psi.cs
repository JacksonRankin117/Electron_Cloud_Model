using System;
using System.Numerics;

class Psi
{   
    public static Complex Psi_Val(int n, int l, int m, double r, double theta, double phi)
    {
        Complex psi = Radial.RadialFunction(n, l, r) * Angular.Ylm(l, m, theta, phi);
        return psi;
    }

    public static double[,] Orbital(int n, int l, int m,           // Energy, angular momentum, and magnetic quantum numbers
                             double widthBohr, double heightBohr,  // Dimensions in Bohr Radii
                             int res)                              // pixels per Bohr radius)
    {
        int w = (int)(widthBohr * res);
        int h = (int)(heightBohr * res);

        double[,] density = new double[w, h];

        for(int ix = 0; ix < w; ix++)
        for(int iy = 0; iy < h; iy++)
        {
            // Map the pixels to real space
            double x = (ix - w/2.0) / res;
            double y = (iy - h/2.0) / res;
            double z = 0.0;

            // Spherical coordinates
            double r = Math.Sqrt(x*x + y*y + z*z);
            if (r == 0) r = 1e-12;  // avoid division by zero

            double theta = Math.Acos(z / r);
            double phi = Math.Atan2(y, x);

            // Compute psi
            Complex psi = Psi_Val(n, l, m, r * Radial.a0, theta, phi);

            // Probability density
            density[ix, iy] = psi.Magnitude * psi.Magnitude;
        }
        return density;
    }
}