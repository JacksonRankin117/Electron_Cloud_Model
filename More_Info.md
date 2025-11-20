# Introduction to the Time-Independent Schrödinger Equation.

For this project I have chosen to simulate electron clouds on hydrogen-like atoms. Hydrogen-like atoms are atoms where there is only one electron. We will also assume because of the distance from the nucleus and the orbiting electrons, that protons will occupy only one point in space, which is a fine approximation in our case.

Because the probability distribution of the electron around the nucleus of the atom don't change in time at all, we can use the time-independent Schrödinger equation, which takes the form:

$$-\frac{\hbar^2}{2m}\nabla^2\psi\left( \mathbf{r}\right) + U\psi\left( \mathbf{r}\right) = E\psi\left( \mathbf{r}\right)$$

Let me explain some symbols. First and easiest is $-\frac{\hbar^2}{2m}$. This looks like a bunch of constants, but it sets the kinetic energy of the system. $\hbar$ is the reduced Planck constant, and has the value of about $1.055 \cdot 10^{-34} \text{J} \cdot \text{s}$. The $m$ is just the mass, so in the case of the electron, $m = 9.11 \cdot 10^{-31}\text{ kg}$.

Most importantly, we have $\psi \left( \mathbf{r}\right)$. This is the spatial wavefunction of the particle. Its essentially a function that carries all the accessible information we can get out a quantum system, neglecting any relativistic effects. And it has a really useful property if the system in question is one particle:

$$P(\mathbf{r}) = \left| \psi\left(\mathbf{r}\right)\right|^2$$

So if you use this equation, you can find the particle's probability density. This will be our probability distribution.

The next symbol of note is $\nabla^2$, which is called the Laplacian. In three dimensions, it can be expanded to (using ISO convention):

$$
\nabla^2 \psi = 

\left( 
\frac{\partial^2 \psi}{\partial x^2} + 
\frac{\partial^2 \psi}{\partial y^2} + 
\frac{\partial^2 \psi}{\partial z^2}
\right) 

\quad \left[\text{Cartesian } \psi \left(x, \; y, \; z\right)\right]
$$

$$
\nabla^2 \psi = 

\frac{1}{r^{2}}\frac{\partial}{\partial r}\left(r^{2}\frac{d\partial \psi}{\partial r}\right) + 
\frac{1}{r^{2}\sin\left(\theta\right)}\frac{\partial}{\partial \theta}\left(\sin\theta\ \frac{\partial \psi}{\partial \theta}\right) + 
\frac{1}{r^{2}\sin^{2}\theta}\ \frac{\partial^{2}\psi}{\partial\phi^{2}}

\quad \left[\text{Spherical } \psi \left(r, \; \theta, \; \phi \right)\right]
$$

$$ 
\nabla^2 \psi = 

\frac{1}{\rho}\ \frac{\partial}{\partial \rho}\left(\rho \ \frac{\partial \psi}{\partial \rho}\right) + 
\frac{1}{\rho^{2}}\ \frac{\partial^{2}\psi}{\partial \phi^{2}} + 
\frac{\partial^{2}\psi}{\partial z^{2}}

\quad \left[\text{Cylindrical } \psi \left(\rho, \; \phi, \; z \right)\right]$$

Since we will be working with orbitals, it will be useful to work with spherical coordinates.

The next two symbols represent energy. $U$ represents potential energy, and is often also represented by $V$. There is no difference between the two, and can be used interchangeably. $U$ or $V$ can be gravitational potential energy, but in our case we will use potential energy of two electrically charged particles, i.e. the negative electron and the positive nucleus. $E$ represents total energy of the system.