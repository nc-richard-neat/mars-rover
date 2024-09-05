using FluentAssertions;
using MarsRover.InputLayer;

namespace MarsRoverTests
{
    internal class LandRoverTests
    {
        [Test]
        public void LandRoverTest()
        {
            var plateau = new Plateau(5, 5);
            plateau.LandRover(new Position(2, 3, Direction.N));
            plateau.Rovers[0].Position.X.Should().Be(2);
            plateau.Rovers[0].Position.Y.Should().Be(3);
            plateau.Rovers[0].Position.Facing.Should().Be(Direction.N);
        }
        [Test]
        public void MultipleLandRoverTest()
        {
            var plateau = new Plateau(5, 5);
            plateau.LandRover(new Position(2, 3, Direction.N));
            plateau.Rovers[0].Position.X.Should().Be(2);
            plateau.Rovers[0].Position.Y.Should().Be(3);
            plateau.Rovers[0].Position.Facing.Should().Be(Direction.N);
            plateau.LandRover(new Position(3, 2, Direction.S));
            plateau.Rovers[1].Position.X.Should().Be(3);
            plateau.Rovers[1].Position.Y.Should().Be(2);
            plateau.Rovers[1].Position.Facing.Should().Be(Direction.S);
        }
        [Test]
        public void CannotLandRoverOutsideOfPlateauTest()
        {
            var plateau = new Plateau(5, 5);
            Action act1 = () => plateau.LandRover(new Position(6, 3, Direction.N));
            Action act2 = () => plateau.LandRover(new Position(3, 6, Direction.N));
            act1.Should().Throw<ArgumentException>()
                .WithMessage("Rover landing coords out of bounds");
            act2.Should().Throw<ArgumentException>()
                .WithMessage("Rover landing coords out of bounds");
        }
        [Test]
        public void CannotLandRoverOnAnotherRoverTest()
        {
            var plateau = new Plateau(5, 5);
            plateau.LandRover(new Position(2, 3, Direction.N));
            Action act = () => plateau.LandRover(new Position(2, 3, Direction.S));
            act.Should().Throw<ArgumentException>()
                .WithMessage("Another rover in landing coords");
        }
    }
}
