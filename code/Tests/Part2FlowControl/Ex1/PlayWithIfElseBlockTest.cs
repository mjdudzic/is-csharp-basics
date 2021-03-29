using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part2FlowControl.Ex1
{
	public class PlayWithIfElseBlockTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithIfElseBlockTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void WhatDoesYourAgeMean()
		{
			// define variable with your or someone's age
			// create function that returns
			// - text "child" if age is below 13
			// - text "teenage" if age is between 13 and 17
			// - text "adult" if age is 18 or more

			var result = string.Empty;

			_outputHelper.WriteLine($"Provided age means you are a(n) {result}");

			result.Should().NotBeNullOrWhiteSpace();
		}
	}
}
