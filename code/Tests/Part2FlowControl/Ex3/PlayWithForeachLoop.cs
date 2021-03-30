using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part2FlowControl.Ex3
{
	public class PlayWithForeachLoop
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithForeachLoop(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void FindMaxInNumberCollection()
		{
			// define collection (e.g. array or list) of some integers
			// create function that will return maximum value from provided collection
			// eg. (1,10,2) => max is 10

			var list = new[] {1,2,3,4,5};
			var result = Max(list);

			_outputHelper.WriteLine($"Maximum number in collection is {result}");

			result.Should().BeGreaterThan(0);
		}

		public int Max(int[] numbers)
		{
			var result = numbers[0];
			foreach (var number in numbers)
			{
				if (number > result)
				{
					result = number;
				}
			}

			return result;
		}
	}
}
