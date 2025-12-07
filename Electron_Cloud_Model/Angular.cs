using System;
using System.Numerics;

class Angular
{
    // Compute factorial for normalization
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

    // Associated Legendre Polynomial P_l^m(x)
    public static double AssociatedLegendre(int l, int m, double x)
    {
        if (m < 0)
        {
            // Use relation P_l^-m = (-1)^m (l-m)! / (l+m)! * P_l^m
            double pos = AssociatedLegendre(l, -m, x);
            return Math.Pow(-1, m) * Factorial(l - m) / (double)Factorial(l + m) * pos;
        }

        double pmm = 1.0;
        if (m > 0)
        {
            double somx2 = Math.Sqrt(1.0 - x * x);
            pmm = 1.0;
            for (int i = 1; i <= m; i++)
                pmm *= -somx2;
        }

        if (l == m) return pmm;

        double pmmp1 = x * (2 * m + 1) * pmm;
        if (l == m + 1) return pmmp1;

        double plm = 0.0;
        for (int ll = m + 2; ll <= l; ll++)
        {
            plm = ((2 * ll - 1) * x * pmmp1 - (ll + m - 1) * pmm) / (ll - m);
            pmm = pmmp1;
            pmmp1 = plm;
        }

        return plm;
    }

    // Spherical Harmonics Y_l^m(theta, phi)
    public static Complex Ylm(int l, int m, double theta, double phi)
    {
        double norm = Math.Sqrt((2.0 * l + 1) / (4.0 * Math.PI) * Factorial(l - Math.Abs(m)) / (double)Factorial(l + Math.Abs(m)));
        double leg = AssociatedLegendre(l, Math.Abs(m), Math.Cos(theta));
        Complex exp = Complex.Exp(Complex.ImaginaryOne * m * phi);
        return norm * leg * exp;
    }
}
