using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part3ObjectOriented.Ex2
{
	public class PlayWithClassBehaviorFeaturesTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithClassBehaviorFeaturesTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CreateInstanceOfStudentClassWithBehavior()
		{
			// 1. Create class Student that will have following properties
			// - FirstName (string)
			// - LastName (string)
			// 2. Add function in this class that will return student full name
			// 3. Create instance of this class and assign some values to properties 
			// 4. Create variable with full name from student instance (FirstName LastName)

			var result = string.Empty;

			_outputHelper.WriteLine($"Student full name is {result}");

			result.Should().NotBeNullOrWhiteSpace();
		}
	}
}
