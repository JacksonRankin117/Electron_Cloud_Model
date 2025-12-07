using System.Numerics;

class Psi
{
    public static Complex Psi_Val(int n, int l, int m, double r, double theta, double phi)
    {
        // Return the full complex wavefunction
        return Radial.RadialFunction(n, l, r) * Angular.Ylm(l, m, theta, phi);
    }

    public static double[,] Orbital(int n, int l, int m,
                                double widthBohr, double heightBohr,
                                int res)
    {
        if (Math.Abs(m) > l)
            throw new ArgumentException("Invalid quantum number m for given l.");

        int w = (int)(widthBohr * res);
        int h = (int)(heightBohr * res);
        double[,] density = new double[h, w];

        for (int ix = 0; ix < w; ix++)
        for (int iy = 0; iy < h; iy++)
        {
            double x = (ix - w / 2.0) / res;
            double z = (iy - h / 2.0) / res;
            double y = 0.0;

            double r = Math.Sqrt(x*x + y*y + z*z);
            if (r == 0) r = 1e-12;

            double theta = Math.Acos(z / r);
            double phi = Math.Atan2(y, x);

            Complex psi_p = Psi_Val(n, l, m,  r, theta, phi);
            Complex psi_m = Psi_Val(n, l, -m, r, theta, phi);

            // --- REAL ORBITAL CONSTRUCTION (FIXED) ---
            Complex psi_real;

            if (m == 0)
            {
                psi_real = psi_p;
            }
            else
            {
                // Cosine-type real orbital
                psi_real = (psi_p + psi_m) / Math.Sqrt(2);
            }

            // ********** PROBABILITY DENSITY **********
            density[iy, ix] = psi_real.Magnitude * psi_real.Magnitude;
        }

        return density;
    }
}
