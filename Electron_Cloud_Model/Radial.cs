using System;

class Radial
{
    public static double a0 = 1;  // The Bohr radius in meters is actually 5.29177210544e-11, but using 1 will simplify calculations

    // This function returns the radial function solution of the TISE
    public static double RadialFunction(int n, int l, double r)
    {
        // Convert r to atomic units if you want (optional)
        double rho = 2.0 * r / (n * a0); 

        // Factorials for normalization
        double numerator = Factorial(n - l - 1);
        double denominator = 2.0 * n * Factorial(n + l);
        double norm = Math.Sqrt(Math.Pow(2.0 / (n * a0), 3) * numerator / denominator);

        // Radial part
        double radial = norm * Math.Exp(-rho / 2.0) * Math.Pow(rho, l) * AssociatedLaguerre(n - l - 1, 2 * l + 1, rho);

        return radial; // This is R_nl(r)
    }


    // Generates the associated Laguerre functions with given converted quantum numbers
    public static double AssociatedLaguerre(int k, int alpha, double r)
    {   
        // Checks for first two solutions
        if (k == 0) return 1.0;
        if (k == 1) return 1 + alpha - r;

        // Initialize for iteration
        double Lkm2 = 1.0;
        double Lkm1 = 1 + alpha - r;
        double Lk = 0.0;

        // Reaccurance loop
        for (int n = 2; n <= k; n++)
        {
            Lk = ((2 * n - 1 + alpha - r) * Lkm1 - (n - 1 + alpha) * Lkm2) / n;
            Lkm2 = Lkm1;
            Lkm1 = Lk;
        }

        return Lk;
    }

    // Classic Factorial function. 
    public static long Factorial(int n)
    {   
        // Checks for cases
        if (n < 0) throw new ArgumentException("n must be a positive number, bonehead. We are NOT doing the Gamma function");
        if (n == 0 || n == 1) return 1;

        // Iteration loop
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        // Return the factorial solution
        return result;
    }
}