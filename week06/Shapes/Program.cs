using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Polymorphism in Action: Shape Areas");
            Console.WriteLine("===================================\n");

            Console.WriteLine("Testing Individual Shapes:");
            Console.WriteLine("--------------------------");
            
            Square square = new Square("Red", 5);
            Console.WriteLine($"Square Color: {square.GetColor()}, Area: {square.GetArea():F2}");

            Rectangle rectangle = new Rectangle("Blue", 4, 6);
            Console.WriteLine($"Rectangle Color: {rectangle.GetColor()}, Area: {rectangle.GetArea():F2}");

            Circle circle = new Circle("Green", 3);
            Console.WriteLine($"Circle Color: {circle.GetColor()}, Area: {circle.GetArea():F2}");

            Console.WriteLine("\nDemonstrating Polymorphism:");
            Console.WriteLine("============================");

            // Create a list of shapes]
            List<Shape> shapes = new List<Shape>();

            // Add different types of shapes to the same list
            shapes.Add(new Square("Yellow", 7));
            shapes.Add(new Rectangle("Purple", 5, 8));
            shapes.Add(new Circle("Orange", 4.5));
            shapes.Add(new Square("Pink", 3.2));
            shapes.Add(new Rectangle("Cyan", 10, 2));

            foreach (Shape shape in shapes)
            {
                string shapeType = shape.GetType().Name;
                double area = shape.GetArea();
                Console.WriteLine($"{shapeType} - Color: {shape.GetColor()}, Area: {area:F2}");
            }

            // Additional demonstration: Using shapes in a method
            Console.WriteLine("\nUsing Shapes in a Method:");
            Console.WriteLine("==========================");
            
            foreach (Shape shape in shapes)
            {
                DisplayShapeInfo(shape);
            }

            Console.WriteLine("\nProgram completed successfully!");
        }

        
        static void DisplayShapeInfo(Shape shape)
        {
            Console.WriteLine($"This {shape.GetColor().ToLower()} shape has an area of {shape.GetArea():F2}");
        }
    }
}