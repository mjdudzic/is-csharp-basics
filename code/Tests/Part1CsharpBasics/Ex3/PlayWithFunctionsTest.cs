using ExercisesLibrary;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part1CsharpBasics.Ex3
{
	public class PlayWithFunctionsTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithFunctionsTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void RunFunctionToCalculateRectangleArea()
		{
			// define variable 'a' and 'b' that represent rectangle side size
			var sideA = 10d;
			var sideB = 11d;

			var result = GetRectangleArea(sideA, sideB); // rectangle area

			_outputHelper.WriteLine($"Rectangle area is {result}");

			result.Should().BeGreaterThan(0);
		}

		public double GetRectangleArea(double sideA, double sideB)
		{
			return sideA * sideB;
		}
	}
}
