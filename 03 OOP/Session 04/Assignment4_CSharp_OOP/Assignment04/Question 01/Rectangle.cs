namespace Assignment04.Question_01
{
    internal class Rectangle : IRectangle
    {
        public int Dim01 { get; set; }
        public int Dim02 { get; set; }

        public decimal Area
        {
            get
            {
                return Dim01 * Dim02;
            }
        }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"shap type: Rectangle\nDim01: {Dim01}, Dim02: {Dim02}\nArea: {Area}");
        }
    }
}
