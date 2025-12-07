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

}