using ShapesApp;


List<IShape>? shapes = new();

Circle circle = new Circle() { Id = 1, Radius = 5.2};
shapes.Add(circle);

Rectangle rectangle = new Rectangle() { Id = 2, Width = 10, Height = 32.3 };
shapes.Add(rectangle);

Line line = new Line() { Id = 3, Length = 21};
shapes.Add(line);


shapes.ForEach(x => 
{

    if (x is ITwoDimensional)
    {
        Console.WriteLine($"Area: { ((ITwoDimensional)x).GetArea() }");
    }

});