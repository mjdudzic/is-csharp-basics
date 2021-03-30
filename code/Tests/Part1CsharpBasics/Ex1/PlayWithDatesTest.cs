using System;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part1CsharpBasics.Ex1
{
	public class PlayWithDatesTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithDatesTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void HowOldAreYou()
		{
			// define yourBirthday variable e.g. 1985-01-01
			// subtract today's year with your birthday year 
			var yourBirthday = new DateTime(1985, 11, 13);

			//TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
			//DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(yourBirthday, cstZone);

			var result = DateTime.Now.Year - yourBirthday.Year;

			_outputHelper.WriteLine($"You are about {result} years old");

			result.Should().BeGreaterThan(0);
		}
	}
}
