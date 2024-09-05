using FluentAssertions;
using MarsRover.InputLayer;
using MarsRover.InputLayer.Parsers;

namespace MarsRoverTests
{
    public class ParserTests
    {
        [Test]
        public void PlateauTest()
        {
            string input = "2 3";
            Plateau actual = Parser.Plateau(input);
            actual.MaxXCoord.Should().Be(2);
            actual.MaxYCoord.Should().Be(3);
        }
        [Test]
        public void PlateauMissingHeightOrWidthTest()
        {
            string input = "2";
            Action actual = () => Parser.Plateau(input);
            actual.Should().Throw<IndexOutOfRangeException>();
        }
        public void PlateauInvalidInputTest()
        {
            string input = "2 N";
            Action actual = () => Parser.Plateau(input);
            actual.Should().Throw<ArgumentException>();
        }
        [Test]
        public void LandPositionTest()
        {
            string input = "1 2 N";
            Position actual = Parser.LandPosition(input);
            actual.X.Should().Be(1);
            actual.Y.Should().Be(2);
            actual.Facing.Should().Be(Direction.N);
        }
        [Test]
        public void LandPositionInvalidInputTest()
        {
            string input = "1 2 1";
            Action actual = () => Parser.LandPosition(input);
            actual.Should().Throw<ArgumentException>()
                .WithMessage("Not a valid input*")
                .And.ParamName.Should().Be("facing");
        }
        public void LandPositionMissingXOrYCoordTest()
        {
            string input = "2 N";
            Action actual = () => Parser.LandPosition(input);
            actual.Should().Throw<ArgumentException>();
        }
        [Test]
        public void InstructionsTest()
        {
            string input = "MRMRLM";
            List<Instruction> actual = Parser.Instructions(input);
            actual.Should().BeEquivalentTo(new List<Instruction>()
            {
                Instruction.M,
                Instruction.R,
                Instruction.M,
                Instruction.R,
                Instruction.L,
                Instruction.M
            });
        }
        [Test]
        public void InstructionsInvalidInputTest()
        {
            string input = "MRM2LM";
            Action actual = () => Parser.Instructions(input);
            actual.Should().Throw<ArgumentException>()
                .WithMessage("Not a valid instruction*")
                .And.ParamName.Should().Be("instruction");
        }
        public void InstructionsEmptyInputTest()
        {
            string input = "";
            Action actual = () => Parser.Instructions(input);
            actual.Should().Throw<ArgumentException>();
        }
    }
}