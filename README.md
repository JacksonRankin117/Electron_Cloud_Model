# Overview

I am developing this project to deepen my understanding of computational physics and to strengthen my skills in software development, particularly in numerical simulation, data visualization, and working with complex mathematical models. This project allows me to explore the intersection of physics and programming, building practical experience in implementing algorithms that simulate real-world phenomena.

The software generates and visualizes electron orbitals for hydrogen-like atoms. It calculates the wavefunctions using the quantum numbers n,l,m, and evaluates the corresponding radial and angular components. The program produces 2D representations of the probability densities, including optional log scaling or gamma normalization to highlight features, though I recommend gamma normalization, as log scaling tends to blow up the small values too much. It also supports multiple visualization modes, such as coloring by probability density or wavefunction phase.

The purpose of this software is to create a flexible and interactive tool for exploring quantum mechanical orbitals. It serves both as a learning platform for visualizing abstract concepts like nodal structures and angular momentum, and as a practical exercise in software engineering—combining algorithm design, numerical methods, and data visualization. Additionally, it provides experience in optimizing performance for large datasets and handling complex data structures.

[Software Demo Video](https://youtu.be/qLh1_4a3ZGE)

# Development Environment

For this project, I used VSCode with a PPM viewer extension which can be found [here](https://marketplace.visualstudio.com/items?itemName=ngtystr.ppm-pgm-viewer-for-vscode). All of this information can be accessed online, though I did reference my Modern Physics textbook by Gary N. Felder and Kenny M. Felder and my old lecture notes from a sophomore-level modern physics course, which dipped into electron orbitals and solving the TISE in Cartesian Coordinates, though we only ever dipped into 3d once, and never with Spherical coordniates. After Writing that second markdown file, I think I understand why it wasn't included in a sophomore-level course.

To program this, I used pure C#. I used a couple .NET libraries like System.Numerics for handling complex numbers, and System.IO for handling file output. The image file I used were P3 PPM files, which are very simple to generate. If you open up a P3 PPM image, you should get something like this:

<pre>
P3         // Type of PPM file
2500 2500  // Pixel 
255        // Pixel depth (How many shades per color channel)
0 0 0      // RGB values for the first pixel (Black)
255 0 0    // RGB values for the second pixel (Red)
0 255 0    // RGB values for the third pixel (Green)
0 0 255    // RGB values for the fourth pixel (Blue)
255 0 255  // RGB values for the fifth pixel (Purple)
... and so on
</pre>


# Useful Websites

- [Wikipedia - Associated Legendre polynomials](https://en.wikipedia.org/wiki/Associated_Legendre_polynomials)
- [Wikipedia - Spherical harmonics](https://en.wikipedia.org/wiki/Spherical_harmonics)
- [Wikipedia - Schrödinger equation](https://en.wikipedia.org/wiki/Schr%C3%B6dinger_equation)

# Future Work

- More Colormaps
- 16-bit HDR in output
- 3D visualizations. GIFs of electron orbital slices incrementing through the orbital
