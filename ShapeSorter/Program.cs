using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");
            Console.WriteLine("----------------");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4),
                new Rectangle(6, 7),
                new Square(5),
                new Circle(3),
                new Rectangle(2, 4),
                new Circle(3.5),
                new Square(10)
            };

            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("----------------");

            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);

            Console.WriteLine("Shapes with an area > 50");

            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("----------------");

            IEnumerable<Circle> circles = shapes.OfType<Circle>();

            Console.WriteLine("All Circles");

            foreach (Circle shape in circles)
            {
                Console.WriteLine($"Circle with radius {shape.Radius} and area {shape.Area}");
            }
            Console.WriteLine("----------------");

            Console.WriteLine("Circles with area < 30");

            foreach (Circle shape in circles.Where(circle => circle.Area < 30))
            {
                Console.WriteLine($"Circle with radius {shape.Radius} and area {shape.Area}");
            }
            Console.WriteLine("----------------");

            IEnumerable<Rectangle> filteredRectangles = shapes.OfType<Rectangle>().Where(shape => shape.Length < 4);

            Console.WriteLine("Rectangles with length less than 4");

            foreach (Rectangle shape in filteredRectangles)
            {
                Console.WriteLine($"Rectangle with length {shape.Length} and area {shape.Area}");
            }
            Console.WriteLine("----------------");

            Console.WriteLine("Grouping By Area");

            var groupByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);

            foreach (var group in groupByArea)
            {
                Console.WriteLine(group.Key ? "Even Area" : "Non-Even Area");
                foreach (var shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}");
                }
            }
            Console.WriteLine("----------------");

            Console.WriteLine("Grouping By Type");

            var groupByType = shapes.GroupBy(shape => shape.GetType());

            foreach (var group in groupByType)
            {
                foreach (var shape in group)
                {
                    Console.WriteLine($"{group.Key.Name} with area {shape.Area}");
                }
            }
            Console.WriteLine("----------------");
        }
    }
}
