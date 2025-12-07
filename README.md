# Overview

This project I made was to help further my understanding of the Schrödinger Equation and of computational physics. In the past I've made diffraction simulator engines, but I've not ever done anything that is involved with very much quantum mechanics, so this was a fun challenge for me. 

The software I wrote is compiled into many different classes, that all have a unique purpose. The Angular.cs, Radial.cs, and Psi.cs files all contain the necessary physics to simulate electron orbitals, the Plot.cs and ColorMap.cs files can be characterized by 

My purpose in writing this software is to help me understand better how electrons move in a hydrogen atom. 

{Provide a link to your YouTube demonstration. It should be a 4-5 minute demo of the software running and a walkthrough of the code.}

[Software Demo Video](http://youtube.link.goes.here)

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
