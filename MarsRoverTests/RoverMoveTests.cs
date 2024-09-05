using FluentAssertions;
using MarsRover.InputLayer;
using MarsRover.LogicLayer;

namespace MarsRoverTests
{
    internal class RoverMoveTests
    {
        [Test]
        public void ShouldMoveNorthTest()
        {
            var rover = new Rover(new Position(1, 2, Direction.N));
            rover.Move();
            rover.Position.X.Should().Be(1);
            rover.Position.Y.Should().Be(3);
            rover.Position.Facing.Should().Be(Direction.N);
        }
        [Test]
        public void ShouldMoveEastTest()
        {
            var rover = new Rover(new Position(1, 2, Direction.E));
            rover.Move();
            rover.Position.X.Should().Be(2);
            rover.Position.Y.Should().Be(2);
            rover.Position.Facing.Should().Be(Direction.E);
        }
        [Test]
        public void ShouldMoveSouthTest()
        {
            var rover = new Rover(new Position(1, 2, Direction.S));
            rover.Move();
            rover.Position.X.Should().Be(1);
            rover.Position.Y.Should().Be(1);
            rover.Position.Facing.Should().Be(Direction.S);
        }
        [Test]
        public void ShouldMoveWestTest()
        {
            var rover = new Rover(new Position(1, 2, Direction.W));
            rover.Move();
            rover.Position.X.Should().Be(0);
            rover.Position.Y.Should().Be(2);
            rover.Position.Facing.Should().Be(Direction.W);
        }
        [Test]
        public void ShouldNotMoveOffMapSouthTest()
        {
            var rover = new Rover(new Position(2, 0, Direction.S));
            Action act = () => rover.Move();
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("cannot drive off the plateau!");
        }
        [Test]
        public void ShouldNotMoveOffMapWestTest()
        {
            var rover = new Rover(new Position(0, 2, Direction.W));
            Action act = () => rover.Move();
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("cannot drive off the plateau!");
        }
        //[Test]
        //public void ShouldNotMoveOffPlateau()
        //{
        //    var plateau = new Plateau(2, 2);
        //    plateau.LandRover(new Position(2, 2, Direction.N));
        //    Action act = () => plateau.Rovers[0].Move();
        //    act.Should().Throw<InvalidOperationException>()
        //        .WithMessage("cannot drive off the plateau!");
        //}
    }
}
