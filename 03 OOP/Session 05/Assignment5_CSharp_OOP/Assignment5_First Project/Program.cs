namespace Assignment5_First_Project
{

    internal class Program
    {
        private static void ReadPoint(Point3D P)
        {
            bool flag;
            int x1, y1, z1;
            Console.WriteLine("please enter Coordinates for P1");
            do
            {
                Console.Write("X: ");
                flag = int.TryParse(Console.ReadLine(), out x1);
            }
            while (!flag);

            do
            {
                Console.Write("Y: ");
                flag = int.TryParse(Console.ReadLine(), out y1);
            }
            while (!flag);

            do
            {
                Console.Write("Z: ");
                flag = int.TryParse(Console.ReadLine(), out z1);
            }
            while (!flag);

            P.X = x1;
            P.Y = y1;
            P.Z = z1;
        }
        static void Main(string[] args)
        {

            Point3D P1 = new Point3D();
            Point3D P2 = new Point3D();
            // 3- Read from the User the Coordinates for 2 points P1, P2 (Check the input using try Pares, Parse, Convert).
            ReadPoint(P1);
            ReadPoint(P2);
            Console.WriteLine(P1.ToString()); //no boxing here
            Console.WriteLine(P2.ToString());

            // 4-Try to use ==
            if (P1 == P2) // it will compare the references not the values
            {
                Console.WriteLine("P1 and P2 are equal");
            }
            else
            {
                Console.WriteLine("P1 and P2 are not equal");
            }

            //5- Define an array of points and sort this array based on X & Y coordinates.
            Point3D[] points = new Point3D[5];
            points[0] = new Point3D(5, 5, 5);
            points[1] = new Point3D(3, 3, 3);
            points[2] = new Point3D(1, 1, 1);
            points[3] = new Point3D(4, 4, 4);
            points[4] = new Point3D(2, 2, 2);

            // sort the array based on X & Y coordinates
            Array.Sort(points);
            Array.ForEach(points, p => Console.WriteLine(p.ToString()));

            // clone the object
            Console.WriteLine("clone the object");
            Point3D P3 = (Point3D)P1.Clone();
            Console.WriteLine(P3.ToString());


        }
    }
}
