class ColorMap
{
    // Greyscale colormap
    public (int r, int g, int b) Greyscale(double value)
    {
        // Clamp value to 0..1
        // This is technically redundant, but a nice failsafe
        if (value < 0) value = 0;
        if (value > 1) value = 1;

        int r = (int)(value * 0);
        int g = (int)(value * 255);
        int b = (int)(value * 255);

        return (r, g, b);
    }

}