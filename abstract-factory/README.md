### Problem Statement:

You are tasked with implementing an abstract factory pattern to create shapes.

There are initially two types of shapes: circles and squares. You need to create an abstract factory for creating these shapes, and then use the factory to create instances of shapes.

There is a skeleton implementation available, but it doesn't use a factory and so won't scale well.

### Task:

1. Create an interface for the shapes, and have them both implement it
2. Create an interface for our abstract factory, containing a method to create each type of shape
3. Implement two concrete factories, one for each shape, using the interface
4. Use the new factories to create the instances of the shapes
5. Add a new shape - a triangle, and create one using the factory

A new requirement comes in to create coloured shapes - red and blue. How might we implement this?

1. Update our shape classes to reflect their colour - RedCircle, BlueCircle, and so on
2. Update the Draw method to display the colour as well as type of shape
3. Add new methods to our factory to create the coloured shapes
4. Create one of each shape!

Finally, a new requirement comes in - the shapes need the ability to be any valid Color. What can we do?

1. Refactor the solution to return to having base shapes, which this time contain a Color property
2. Update the interfaces so we can pass a Color in at creation, which then gets set as the shape Color on creation

Ensure your solution is well tested!