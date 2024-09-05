using MarsRover.LogicLayer;

namespace MarsRover
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = new List<string>()
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };
            var result = MissionControl.Execute(input);
            Console.WriteLine("Final positions:");
            result.ForEach(Console.WriteLine);
        }
    }
}