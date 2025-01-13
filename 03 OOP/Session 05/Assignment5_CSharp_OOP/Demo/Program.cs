using Demo.Abstraction;

namespace Demo
{



    internal class Program
    {

        private static void drawShape(IDraw2D shape)
        {
            shape.Draw();
        }

        static void Main(string[] args)
        {
            #region Abstraction [Abstract Class, Abstract Method, Abstract property]

            //Shape s = new Shape(); // can't create instance of abstract class
            //RectSquareBase rs = new RectSquareBase(); // can't create instance of abstract class

            Shape shape = new Rect(10, 20);
            decimal rectPeri = shape.Perimeter;
            decimal rectArea = shape.CalcArea();
            Console.WriteLine($"Rect Peri = {rectPeri}");
            Console.WriteLine($"Rect Area = {rectArea}");
            Console.WriteLine();

            shape = new Square(10);
            decimal squarePeri = shape.Perimeter;
            decimal squareArea = shape.CalcArea();
            Console.WriteLine($"Square Peri = {squarePeri}");
            Console.WriteLine($"Square Area = {squareArea}");
            Console.WriteLine();

            shape = new Circle(10);
            decimal circlePeri = shape.Perimeter;
            decimal circleArea = shape.CalcArea();
            Console.WriteLine($"Circle Peri = {circlePeri}");
            Console.WriteLine($"Circle Area = {circleArea}");
            Console.WriteLine();

            // shape can be Rect, Square, Circle, ... etc

            drawShape(shape);


            #endregion


            #region Note
            /// Abstract Class
            /// is a Partial Implementation for Other Classes.
            /// is a Container for Common Code [Implemented Members, Abstract Members] among many Classes.
            /// U Can't Create an Object from Abstract Class [it is not fully implemented].
            /// Abstract Class not acutally exist in business model.

            // if i implemment interface i can add get or set to the property if it is not exist in the interface
            // if i implement abstract class i can't add get or set to the property if it is not exist in the abstract class
            // if only get exist i have to add get only, i can't add set

            // Interface is a contract between the class and the outside world to provide a specific behavior.

            // Abstract Class can have constructors, interfaces can't have constructors



            #endregion

        }
    }
}
