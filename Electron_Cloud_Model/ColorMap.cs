class ColorMap
{
    // Linear colormap
    public (int r, int g, int b) Linear(double value, byte rmax, byte gmax, byte bmax)
    {
        // Clamp value to 0..1
        // This is technically redundant, but a nice failsafe
        if (value < 0) value = 0;
        if (value > 1) value = 1;

        int r = (int)(value * rmax);
        int g = (int)(value * gmax);
        int b = (int)(value * bmax);

        return (r, g, b);
    }

    public (int r, int g, int b) Linear_r(double value, byte rmax, byte gmax, byte bmax)
    {
        // Clamp value to 0..1
        // This is technically redundant, but a nice failsafe
        if (value < 0) value = 0;
        if (value > 1) value = 1;

        int r = (int)((1 - value) * rmax);
        int g = (int)((1 - value) * gmax);
        int b = (int)((1 - value) * bmax);

        return (r, g, b);
    }

    public (int r, int g, int b) Greyscale(double value)
    {
        // Clamp value to 0..1
        // This is technically redundant, but a nice failsafe
        if (value < 0) value = 0;
        if (value > 1) value = 1;

        int r = (int)((value) * 255);
        int g = (int)((value) * 255);
        int b = (int)((value) * 255);

        return (r, g, b);
    }

    public (int r, int g, int b) Greyscale_r(double value)
    {
        // Clamp value to 0..1
        // This is technically redundant, but a nice failsafe
        if (value < 0) value = 0;
        if (value > 1) value = 1;

        int r = (int)((1-value) * 255);
        int g = (int)((1-value) * 255);
        int b = (int)((1-value) * 255);

        return (r, g, b);
    }

    public (int r, int g, int b) HotCold(double value)
    {
        // Clamp value to 0..1
        // This is technically redundant, but a nice failsafe
        if (value < 0) value = 0;
        if (value > 1) value = 1;

        int r = (int)((value) * 255);
        int g = 0;
        int b = (int)((1-value) * 255);

        return (r, g, b);
    }

    public (int r, int g, int b) Gradient(double value)
    {
        // Clamp value to 0..1
        if (value < 0) value = 0;
        if (value > 1) value = 1;

        // Define the gradient stops
        (double pos, byte r, byte g, byte b)[] stops = new (double, byte, byte, byte)[]
        {
            (0.0, 0, 0, 0),        // Black
            (0.25, 0, 0, 255),     // Blue
            (0.5, 0, 255, 0),      // Green
            (0.75, 255, 0, 0),     // Red
            (1.0, 255, 255, 255)   // White
        };

        // Find which segment the value is in
        (double pos, byte r, byte g, byte b) start = stops[0];
        (double pos, byte r, byte g, byte b) end = stops[stops.Length - 1];

        for (int i = 0; i < stops.Length - 1; i++)
        {
            if (value >= stops[i].pos && value <= stops[i + 1].pos)
            {
                start = stops[i];
                end = stops[i + 1];
                break;
            }
        }

        // Linear interpolation
        double t = (value - start.pos) / (end.pos - start.pos);
        int rInterp = (int)(start.r + t * (end.r - start.r));
        int gInterp = (int)(start.g + t * (end.g - start.g));
        int bInterp = (int)(start.b + t * (end.b - start.b));

        return (rInterp, gInterp, bInterp);
    }
}