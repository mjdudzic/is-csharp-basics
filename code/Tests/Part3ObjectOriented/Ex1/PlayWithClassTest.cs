using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part3ObjectOriented.Ex1
{
	public class PlayWithClassTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithClassTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CreateInstanceOfStudentClass()
		{
			// 1. Create class Student that will have following properties
			// - FirstName (string)
			// - LastName (string)
			// 2. Create instance of this class and assign some values to properties 
			// 3. Create variable with full name from student instance (FirstName LastName)

			var result = string.Empty;

			_outputHelper.WriteLine($"Student full name is {result}");

			result.Should().NotBeNullOrWhiteSpace();
		}

		[Fact]
		public void BuildConstructorWithParametersForStudentClass()
		{
			// 1. Create class Student that will have following properties
			// - FirstName (string)
			// - LastName (string)
			// 2. Create class constructor that will accept parameters to set up properties FirstName and LastName
			// 3. Create instance of this class and assign some values to properties 
			// 4. Create variable with full name from student instance (FirstName LastName)

			var result = string.Empty;

			_outputHelper.WriteLine($"Student full name is {result}");

			result.Should().NotBeNullOrWhiteSpace();
		}
	}
}
