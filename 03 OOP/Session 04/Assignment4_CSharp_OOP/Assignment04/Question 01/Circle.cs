namespace Assignment04.Question_01
{
    internal class Circle : ICircle
    {
        public int Radius { get; set; }
        public decimal Area
        {
            get
            {
                return (decimal)Math.PI * Radius * Radius;
            }
        }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"shap type: Circle\nRadius: {Radius}\nArea: {Area}");
        }
    }
}
