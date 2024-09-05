using MarsRover.LogicLayer;

namespace MarsRover.InputLayer
{
    internal class Plateau
    {
        public int MaxXCoord {  get; set; }
        public int MaxYCoord { get; set; }
        public List<Rover> Rovers { get; set; } = new List<Rover>();
        public Plateau(int width, int height)
        {
            MaxXCoord = width;
            MaxYCoord = height;
        }
        public void LandRover(Position position)
        {
            if (position.X > MaxXCoord || position.Y > MaxYCoord) throw new ArgumentException("Rover landing coords out of bounds");
            var rover = new Rover(position);
            bool roverAlreadyInCoords = Rovers.Any(rover => rover.Position.X == position.X && rover.Position.Y == position.Y);
            if (roverAlreadyInCoords) throw new ArgumentException("Another rover in landing coords");
            Rovers.Add(rover);
        }
    }
}
