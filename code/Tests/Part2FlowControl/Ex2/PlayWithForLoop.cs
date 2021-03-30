using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part2FlowControl.Ex2
{
	public class PlayWithForLoop
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithForLoop(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CalculateFactorialNumber()
		{
			// define variable e.g. 'n' with some integer
			// create function that will calculate n! (factorial number)
			// eg. 3! = 1 * 2 * 3 = 6

			var number = 3;
			var result = Calc(number);

			_outputHelper.WriteLine($"Factorial number for {number} is {result}");

			result.Should().BeGreaterThan(0);
		}

		public int Calc(int n)
		{
			var result = 1;
			for (var i = 1; i <= n; i++)
			{
				result = result * i;
			}

			return result;
		}
	}
}
