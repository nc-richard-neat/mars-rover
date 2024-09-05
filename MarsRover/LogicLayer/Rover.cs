using MarsRover.InputLayer;
using MarsRover.InputLayer.Parsers;

namespace MarsRover.LogicLayer
{
    internal class Rover
    {
        public Position Position {  get; set; }
        public Rover(Position position)
        {
            Position = position;
        }
        public void Rotate(Instruction instruction)
        {
            Position.Facing = (Position.Facing, instruction) switch
            {
                (Direction.N, Instruction.R) => Direction.E,
                (Direction.N, Instruction.L) => Direction.W,
                (Direction.E, Instruction.R) => Direction.S,
                (Direction.E, Instruction.L) => Direction.N,
                (Direction.S, Instruction.R) => Direction.W,
                (Direction.S, Instruction.L) => Direction.E,
                (Direction.W, Instruction.R) => Direction.N,
                (Direction.W, Instruction.L) => Direction.S,
                _ => throw new ArgumentException("invalid rotation", nameof(instruction))
            };
        }
        public void Move()
        {
            switch (Position.Facing)
            {
                case Direction.N:
                    Position.Y++;
                    break;
                case Direction.E:
                    Position.X++;
                    break;
                case Direction.S:
                    if (Position.Y - 1 < 0) throw new InvalidOperationException("cannot drive off the plateau!");
                    Position.Y--;
                    break;
                case Direction.W:
                    if (Position.X - 1 < 0) throw new InvalidOperationException("cannot drive off the plateau!");
                    Position.X--;
                    break;
                default:
                    throw new ArgumentException("invalid move");
            };
        }
    }
}
