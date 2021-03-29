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

			var result = 0; // rectangle area

			_outputHelper.WriteLine($"Rectangle area is {result}");

			result.Should().BeGreaterThan(0);
		}
	}
}
