using FluentAssertions;
using FluentAssertions.Specialized;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part2FlowControl.Ex1
{
	public class PlayWithSwitchStatementTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithSwitchStatementTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void WhatCountryIsYourCarFrom()
		{
			// define variable with car brand e.g. Izera :) 
			// create function that will return country name where the car brand owner has place
			// e.g for Izera function should return Poland

			var carBrand = string.Empty;
			var result = string.Empty;

			_outputHelper.WriteLine($"Car brand {carBrand} origins from {result}");

			result.Should().NotBeNullOrWhiteSpace();
		}
	}
}
