using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part1CsharpBasics.Ex2
{
	public class PlayWithListsTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithListsTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void FindYourName()
		{
			// Create list of some names (but not your name)
			// Add your name to created list
			// Define at what index int he list is your name

			var result = 0; //result = index value

			_outputHelper.WriteLine($"Your name is at {result} index");

			result.Should().BeGreaterThan(0);
		}
	}
}
