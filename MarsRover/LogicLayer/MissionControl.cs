using MarsRover.InputLayer;
using MarsRover.InputLayer.Parsers;

namespace MarsRover.LogicLayer
{
    internal static class MissionControl
    {
        public static List<string> Execute(List<string> input)
        {
            Plateau plateau = Parser.Plateau(input[0]);
            Console.WriteLine($"Plateau created with max x coord: {plateau.MaxXCoord} and max y coord: {plateau.MaxYCoord}");

            var finalPositions = new List<string>();

            for (int i = 1; i < input.Count; i++)
            {
                if (i % 2 != 0)
                {
                    plateau.LandRover(Parser.LandPosition(input[i]));
                    Console.WriteLine($"Rover landed on x coord: {plateau.Rovers[plateau.Rovers.Count - 1].Position.X} y coord: {plateau.Rovers[plateau.Rovers.Count - 1].Position.X} facing: {plateau.Rovers[plateau.Rovers.Count - 1].Position.Facing}");
                }
                else
                {
                    List<Instruction> parsedInstructions = Parser.Instructions(input[i]);
                    parsedInstructions.ForEach(instruction =>
                    {
                        if (instruction is Instruction.R || instruction is Instruction.L) plateau.Rovers[plateau.Rovers.Count - 1].Rotate(instruction);
                        else plateau.Rovers[plateau.Rovers.Count - 1].Move();
                    });
                    finalPositions.Add($"{plateau.Rovers[plateau.Rovers.Count - 1].Position.X} {plateau.Rovers[plateau.Rovers.Count - 1].Position.Y} {plateau.Rovers[plateau.Rovers.Count - 1].Position.Facing.ToString()}");
                }
            };
            return finalPositions;
        }
    }
}
