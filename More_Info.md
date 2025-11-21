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

\frac{1}{r^{2}}\frac{\partial}{\partial r}\left(r^{2}\frac{\partial \psi}{\partial r}\right) + 
\frac{1}{r^{2}\sin\theta}\frac{\partial}{\partial \theta}\left(\sin\theta\ \frac{\partial \psi}{\partial \theta}\right) + 
\frac{1}{r^{2}\sin^{2}\theta}\ \frac{\partial^{2}\psi}{\partial\phi^{2}}

\quad \left[\text{Spherical } \psi \left(r, \; \theta, \; \phi \right)\right]
$$

$$ 
\nabla^2 \psi = 

\frac{1}{\rho}\ \frac{\partial}{\partial \rho}\left(\rho \ \frac{\partial \psi}{\partial \rho}\right) + 
\frac{1}{\rho^{2}}\ \frac{\partial^{2}\psi}{\partial \phi^{2}} + 
\frac{\partial^{2}\psi}{\partial z^{2}}

\quad \left[\text{Cylindrical } \psi \left(\rho, \; \phi, \; z \right)\right]$$

Since we will be working with orbitals, it will be useful to work with spherical coordinates, as it will be harder to describe the motion of an orbiting electron with Cartesian or Cylindrical coordinates.

The next two symbols represent energy. $U$ represents potential energy, and is often also represented by $V$. There is no difference between the two symbols, and can be used interchangeably. 

$U$ or $V$ can be gravitational potential energy, but in our case we will use potential energy of two electrically charged particles, i.e. the negative electron and the positive nucleus. I use $U$ because $V$ is also used for electric potential, which is something else entirely.

$E$ represents total energy of the system, which is often kinetic energy $T$ summed with potential energy $U$.

## Analytical Method - Separation of Variables.

So, forget solving this equation numerically. How do we solve it with math?

Our goal is to find what $\psi$ is, but you'll find very quickly that this is an extremely difficult thing to do. So what do we do?

The answer is pray that the solution looks something like this:

$$
\psi \left(r, \; \theta, \; \phi \right) = 
R(r) \Theta(\theta) \Phi(\phi)
$$

Where the solution is the product of three other functions $R(r)$, $\Theta(\theta)$, and $\Phi(\phi)$. This is obviously a ridiculous case, because it cannot be applied to the vast majority of partial differential equations.

But what if we roll with it?

First, lets see what our Laplacian looks like:

$$\frac{1}{r^{2}}\frac{\partial}{\partial r}\left(r^{2}\frac{\partial R(r) \Theta(\theta) \Phi(\phi)}{\partial r}\right) + 
\frac{1}{r^{2}\sin\theta}\frac{\partial}{\partial \theta}\left(\sin\theta\ \frac{\partial R(r) \Theta(\theta) \Phi(\phi)}{\partial \theta}\right) + 
\frac{1}{r^{2}\sin^{2}\theta}\ \frac{\partial^{2}R(r) \Theta(\theta) \Phi(\phi)}{\partial\phi^{2}}$$

If we recognize that we can pull out the functions that don't depend on the variables we are taking the derivative with respect to, we can pull the other functions out, simplifying our Laplacian a bit. I'm also going to drop the parentheses which denote which variables the function depends on.

$$\nabla^2\psi = \left[\frac{1}{r^{2}}\frac{\partial}{\partial r}\left(r^{2}\frac{\partial R}{\partial r}\right)\right]\Theta \Phi + 
\left[\frac{1}{r^{2}\sin\theta}\frac{\partial}{\partial \theta}\left(\sin\theta\ \frac{\partial \Theta }{\partial \theta}\right)\right]R\Phi + 
\left[\frac{1}{r^{2}\sin^{2}\theta}\ \frac{\partial^{2} \Phi}{\partial\phi^{2}}\right] R\Theta
$$

Now lets multiply by $\frac{r^2}{R \Theta \Phi}$

$$r^2\frac{\nabla^2\psi}{R\Theta\Psi} = \frac{1}{R}\left[\frac{\partial}{\partial r}\left(r^{2}\frac{\partial R}{\partial r}\right)\right] + 
\frac{1}{\Theta}\left[\frac{1}{\sin\theta}\frac{\partial}{\partial \theta}\left(\sin\theta\ \frac{\partial \Theta }{\partial \theta}\right)\right] + 
\frac{1}{\Phi}\left[\frac{1}{\sin^{2}\theta}\ \frac{\partial^{2} \Phi}{\partial\phi^{2}}\right]
$$

Lets put this aside for now and look at the Schrödinger equation for a minute.

$$-\frac{\hbar^2}{2m}\nabla^2\psi\left( \mathbf{r}\right) + U\psi\left( \mathbf{r}\right) = E\psi\left( \mathbf{r}\right)$$

This can be rearranged to become:

$$\nabla^2\psi = \frac{2m}{\hbar^2}(U-E)\psi$$

Remember, our $\psi$ we assume has the form $\psi = R\Theta\Phi$. When we divide by $ R\Theta\Phi$ and multiply by $r^2$ again, we find that our Schrödinger equation now takes the form:

$$\frac{1}{R}\left[\frac{d}{d r}\left(r^{2}\frac{d R}{d r}\right)\right] + 
\frac{1}{\Theta}\left[\frac{1}{\sin\theta}\frac{d}{d \theta}\left(\sin\theta\ \frac{d \Theta }{d \theta}\right)\right] + 
\frac{1}{\Phi}\left[\frac{1}{\sin^{2}\theta}\ \frac{d^{2} \Phi}{d\phi^{2}}\right] = \frac{2mr^2}{\hbar^2}(U-E)$$

Which we can rearrange to find:

$$\underbrace{\frac{1}{R}\left[\frac{d}{d r}\left(r^{2}\frac{d R}{d r}\right)\right] -\frac{2mr^2}{\hbar^2}(U-E)}_{\text{= function of } r} + 

\underbrace{\frac{1}{\Theta}\left[\frac{1}{\sin\theta}\frac{d}{d \theta}\left(\sin\theta\ \frac{d \Theta }{d \theta}\right)\right] + 
\frac{1}{\Phi}\left[\frac{1}{\sin^{2}\theta}\ \frac{d^{2} \Phi}{d\phi^{2}}\right]}_{\text{= function of } \theta \text{ and }\phi} = 0$$

Lets examine this generally. If we have two function added up together, and when added up, they both equal 0, one must equal the negative of itself. So if we have a variable $\lambda$ to represent the function of $r$, the function of $\theta$ and $\phi$ must be $-\lambda$. In fact, lets expand upon this:

$$\frac{1}{R}\left[\frac{d}{d r}\left(r^{2}\frac{d R}{d r}\right)\right] -\frac{2mr^2}{\hbar^2}(U-E) = \lambda$$

$$\frac{1}{\Theta}\left[\frac{1}{\sin\theta}\frac{d}{d \theta}\left(\sin\theta\ \frac{d \Theta }{d \theta}\right)\right] + 
\frac{1}{\Phi}\left[\frac{1}{\sin^{2}\theta}\ \frac{d^{2} \Phi}{d\phi^{2}}\right] = -\lambda$$

And examine even closer. This time, on the angular function:

$$\frac{1}{\Theta}\left[\frac{1}{\sin\theta}\frac{d}{d \theta}\left(\sin\theta\ \frac{d \Theta }{d \theta}\right)\right] + 
\frac{1}{\Phi}\left[\frac{1}{\sin^{2}\theta}\ \frac{d^{2} \Phi}{d\phi^{2}}\right] = -\lambda$$

$\phi$ represents an azimuthal angle, so the solution to the $\phi$-dependant part of our equation is periodic. Therefore, in $\frac{1}{\Phi}\left[\frac{1}{\sin^{2}\theta}\ \frac{d^{2} \Phi}{d\phi^{2}}\right]$, we can set up a differential equation of the form: 

$$\frac{d^{2} \Phi}{d\phi^{2}} = -\Phi m^2$$

Which the solution to is oscillatory:

$$\Phi(\phi) = Ae^{im\phi} + Be^{-im\phi} = Ce^{im\phi}$$

Where $C$ is a complex number. This solution also has the condition that:

$$\Phi(\phi) = \Phi(\phi + 2\pi)$$

Because of its oscillatory nature. So,

$$\Phi(\phi) = Ce^{im(\phi)} = Ce^{im(\phi + 2\pi)}$$

This implies that $m$ can really only be integer multiples. So, our solution is:

$$\Phi = Ce^{im\phi}$$

Whew. Thats one of three solutions we need.

Lets look back at what we have.

$$\frac{1}{\Theta}\left[\frac{1}{\sin\theta}\frac{d}{d \theta}\left(\sin\theta\ \frac{d \Theta }{d \theta}\right)\right] + 
\frac{1}{\Phi}\left[\frac{1}{\sin^{2}\theta}\ \frac{d^{2} \Phi}{d\phi^{2}}\right] = -\lambda$$

We know that $ \frac{1}{\Phi}\frac{d^{2} \Phi}{d\phi^{2}} = -m^2$, so we can substitute.

$$\frac{1}{\Theta}\left[\frac{1}{\sin\theta}\frac{d}{d \theta}\left(\sin\theta\ \frac{d \Theta }{d \theta}\right)\right] + 
\left[\frac{-m^2}{\sin^{2}\theta}\right] = -\lambda$$

If we take $\lambda$, which is an arbitrary constant, to be equal to $l(l + 1)$, then multiply through by $\Theta$, we now have the form:

$$\left[\frac{1}{\sin\theta}\frac{d}{d \theta}\left(\sin\theta\ \frac{d \Theta }{d \theta}\right)\right] + 
\left[l(l+1) + \frac{-m^2}{\sin^{2}\theta}\right]\Theta = 0$$

This is an equation for the Associated Legendre Polynomials. let me prove it.

Lets take $x$ to be equal to $\cos \theta$, and plug it into a Pythagorean identity:

$$\sin^2\theta + \cos^2 \theta = 1$$

$$\sin^2\theta + x^2 = 1$$

$$\sin^2\theta = 1-x^2$$

> $$\sin\theta = \sqrt{1-x^2}$$

Lets also take the derivative of $x$ with respect to $\theta$:

> $$\frac{d}{d\theta}\cos\theta = -\sin\theta$$

Another important result is to find what $\frac{d}{d\theta}$ actually is:

>$$\frac{d}{d\theta} = \frac{dx}{d\theta}\frac{d}{dx} = -\sin\theta \frac{d}{dx}$$

One last assumption. Lets assume that our $\Theta(\theta)$ is equivalent to a function $P(x)$

These three results we can plug into the equation thats supposedly another form for the Associated Legendre Polynomial equation. 

$$\left[\frac{1}{\sin\theta}\left(-\sin\theta \frac{d}{dx}\right)\left(\sin\theta \left(-\sin\theta \frac{d}{dx}\right) P(x) \right)\right] + 
\left[l(l+1) + \frac{-m^2}{1-x^2}\right]P(x) = 0$$

And now we simplify to this:

$$
\left(\frac{d}{dx}\right)
(1-x^2)  \, P'(x) + 
\left[l(l+1) + \frac{-m^2}{1-x^2}\right]P(x) = 0
$$

The solutions to $P(x)$, or, equivalently, $\Theta(\theta)$, are, of course, the Legendre Polynomials.

$$P^m_l(x) = \frac{(-1)^m}{2^l l!}(1-x^2)^{m/2} \ \frac{d^{l+m}}{dx^{l+m}} (x^2-l)^l$$

Where $l$ and $m$ are the and angular momentum and magnetic quantum numbers respectively.

We now have our second result. By now we have completely forgotten what we are working on, and have to remind ourselves that of course the last part we need to solve for is the radial solution.

$$\frac{1}{R}\left[\frac{d}{d r}\left(r^{2}\frac{d R}{d r}\right)\right] -\frac{2mr^2}{\hbar^2}(U-E) = \lambda$$

We know from above that $\lambda$ is $l(l+1)$, but we can do some simplification before we plug it in:

$$
\frac{1}{R}\left[\frac{d}{d r}\left(r^{2}\frac{d R}{d r}\right)\right] - 

\frac{2mr^2}{\hbar^2}(U-E) = 

\lambda
$$

$$
\frac{d}{d r}\left(r^{2}\frac{d R}{d r}\right) - 

\frac{2mr^2}{\hbar^2}(U-E)R = 0

R\lambda
$$

$$
2rR' + r^2R''- 

\left[\frac{2mr^2}{\hbar^2}(U-E) - \lambda \right]R = 0
$$

Now we can plug in $\lambda$

$$
2rR' + r^2R''- 

\left[\frac{2mr^2}{\hbar^2}(U-E) - l(l+1) \right]R = 0
$$

Lets think about our potential energy for a second. Right now we are assuming the atom is alone in an empty universe. There is no external force on the atom, and therefore, the only force the electron feels on the aton is the Coulomb force from the nucleus.

The potential energy from a hydrogen-like atom is as such:

$$U = -\frac{1}{4 \pi \epsilon_0} \frac{q_1q_2}{r}$$

If we look at the net charge of the nucleus of the atom, we see that we can just multiply the charge of the proton multiplied by the atomic number, which is the number of protons in each atom. Protons and electrons have equal but opposite charge, so the potential energy can be simplified to:

$$U = \frac{Ze^2}{4 \pi \epsilon_0 r}$$

And we can now throw it in the equation:

$$
2rR' + r^2R''- 

\left[\frac{2mr^2}{\hbar^2}(\frac{Ze^2}{4 \pi \epsilon_0 r}-E) - l(l+1) \right]R = 0
$$

$$
2rR' + r^2R''+

\left[(\frac{2Emr^2}{\hbar^2} -\frac{2mr^2}{\hbar^2}\frac{Ze^2}{4 \pi \epsilon_0 r}) + l(l+1) \right]R = 0
$$

To make our lives easier, lets make a substitution:

$$u(r) = rR(r)$$

so that

$$R = \frac{u}{r}\text{.}$$

Lets find $R'$:

$$\frac{dR}{dr} = \frac{d}{dr} \frac{u}{r} = \frac{1}{r} 
\frac{du}{dr} - \frac{u}{r^2}$$
