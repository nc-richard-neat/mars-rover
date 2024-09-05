using System.Text.RegularExpressions;

namespace MarsRover.InputLayer.Parsers
{
    internal static class Parser
    {
        public static Plateau Plateau(string plateauInput)
        {
            string noSpaceInput = Regex.Replace(plateauInput, @"\s+", "");
            return new Plateau(noSpaceInput[0] - '0', noSpaceInput[1] - '0');
        }
        public static Position LandPosition(string landCoordsInput)
        {
            string noSpaceInput = Regex.Replace(landCoordsInput, @"\s+", "");
            Direction facing = noSpaceInput[2] switch
            {
                'N' => Direction.N,
                'S' => Direction.S,
                'E' => Direction.E,
                'W' => Direction.W,
                _ => throw new ArgumentException("Not a valid input", nameof(facing))
            };
            return new Position(noSpaceInput[0] - '0', noSpaceInput[1] - '0', facing);
        }
        public static List<Instruction> Instructions(string instructionsInput)
        {
            var instructions = new List<Instruction>();
            foreach (var instruction in instructionsInput)
            {
                instructions.Add(instruction switch
                {
                    'L' => Instruction.L,
                    'R' => Instruction.R,
                    'M' => Instruction.M,
                    _ => throw new ArgumentException("Not a valid instruction", nameof(instruction))
                });
            }
            return instructions;
        }
    }
}