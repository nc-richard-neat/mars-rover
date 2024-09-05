using FluentAssertions;
using MarsRover.InputLayer;
using MarsRover.LogicLayer;

namespace MarsRoverTests
{
    internal class RoverRotateTests
    {
        [Test]
        public void ShouldRotateRightTest()
        {
            var input = Instruction.R;
            var rover = new Rover(new Position(1, 2, Direction.N));
            rover.Rotate(input);
            rover.Position.Facing.Should().Be(Direction.E);
        }
        [Test]
        public void ShouldRotateLeftTest()
        {
            var input = Instruction.L;
            var rover = new Rover(new Position(1, 2, Direction.N));
            rover.Rotate(input);
            rover.Position.Facing.Should().Be(Direction.W);
        }
        [Test]
        public void ShouldRotateFromAnyPositionTest()
        {
            var input = Instruction.L;
            var rover = new Rover(new Position(1, 2, Direction.E));
            rover.Rotate(input);
            rover.Position.Facing.Should().Be(Direction.N);
        }
        [Test]
        public void RotateInvalidInputTest()
        {
            var input = Instruction.M;
            var rover = new Rover(new Position(1, 2, Direction.E));
            Action act = () => rover.Rotate(input);
            act.Should().Throw<ArgumentException>()
               .WithMessage("invalid rotation*")
               .And.ParamName.Should().Be("instruction");
        }
    }
}
