# Vibration-simulator

For my Stem course, I needed to make a Thesis.
I decided to code a vibration simulator, which I decided to make in Unity.
I will put this in the unity asset store so that fellow programmer can use it to make more realistic vibrations.
This can then be used to make better earthquakes, or anything else which involves vibrations.
Now I am going to explain how I build it, which issues I came across, and which things can be still aproved upon by a programmer that is more adept than me.

Step 1: coding vibration
This was actually quite easy, you just add an elastic force to an object and when it's out of balance it vibrates.
I coded this by giving an equilibrium point to the object when the scene loads, it's begin position.
Then I constantly apply a force to it, this force is equal to the distance between the object and it's equilibrium force multiplied by the elasticity constant which you can change. 
The direction of the force is also towards the equilibrium point, this makes it vibrate when it's out of balance.

step 2: coding waves
This was way harder and took me a long time and several failed attempts.
Eventually I found a usefull tutorial that helped me to continue. https://www.youtube.com/watch?v=kRJE771mikA&t=87s
It was still not what I needed but it was a good basis that i tweaked to fit my purpose.
The video had a tutorial for an explosion, that casted an overlapSphere that would grow when it was activated.
An overlapSphere creates an array of colliders that are in it's domain.
The problem is that the same object could be multiple times in the same array, and does be hit multiple times.
I fixed this by creating a seperate list that would check if an object of the array was already in the list and would only add them, if it wasn't in the list yet.
The force would only be aplied on the objects in the list.
Instead of sending the force away from the source all objects would be sent in the same direction, the vibration direction which you can change.
I also made it so the force would diminish the further it was from the source.
The explosion effects made it so that I couldn't change the location of the source so I got rid of it.
Now all objects with in the max radius, that you can also change, will be affected by the pulse when it reaches them, causing a wave.
You can also the base-force and speed of the pulse.

Step 3: shaking ground.
It is one thing to make individual objects be affected by waves but it is a whole other thing to make an entire plain like the ground shake.
First i looked up how to make ground and ended up finding brackeys videos on mesh generations which I recommend watching.
https://www.youtube.com/watch?v=eJEpeUH1EMg and https://www.youtube.com/watch?v=64NblGkAabk
I had my ground now, but how do I shake it.
It took me several weeks but I found a way to solve this problem.
A mesh is defined by several vertices which create it's shape.
So I decided to make an empty game object, called it verticeBody, give it a rigidbody, collider and an ElasticityForce script.
Made a prefab out of it so I could instatiate it.
And when the mesh was generated made a verticeBody (VB) for every vertice, made the equilibriumpoint of the VB equal to the beginposition of it's corresponding.
And then make it so the position of the vertice changes continuously so it equals the position of the VB, therefor if the VB starts to vibrate the vertex also changes.
This makes it so that the mesh vibrates.
To make a shaking piece of ground you need to make an empty game object but th MeshGenerator script on it, fill in the desired sizes and put your VB in the spot that says Vertice Rigidbody. 

Step 4: bug fixing.
There were a lot of them but most of them where simpel fixes like the wave inverting when far enough instead of stopping.
Other ones where more difficult like the mesh not vibrating for vertices that where on negative x and z coördinates.
But at this point of the project I think I got rid of all of them, or atleast the worst/most visible ones.

Step 5: How to improve
The final result is a module that simulates realistic(-ish) vibrations.
But there is still room for improvement.




