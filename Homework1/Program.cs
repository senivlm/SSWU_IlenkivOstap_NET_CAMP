namespace Homework1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1.GenerateSpiralMatrix(3, 4, Task1.StartPoint.BottomLeft, Task1.Direction.ToRight);
            Console.WriteLine("Pres any key to continue.");
            Console.ReadKey();
            Task2 task2 = new Task2();
            task2.GetIndexesAndLenght();
        }
    }
}