using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part3ObjectOriented.Ex3
{
	public class PlayWithPrivateAccessModifiersTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithPrivateAccessModifiersTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CreateInstanceOfStudentClassWithPrivateField()
		{
			// 1. Create class Student that will have no public properties but a private field _fullName
			// 2. Create parametrized constructor that accepts parameters firstName and lastName
			// 3. Field _fullName should be set in constructor by using passed arguments firstName and lastName
			// 4. Add public function that will return value stored in filed _fullName

			var student = new Student("Jan", "Kowalski");
			var result = student.GetFullName();

			_outputHelper.WriteLine($"Student full name is {result}");

			result.Should().NotBeNullOrWhiteSpace();
		}

		public class Student
		{
			private string _fullName;

			public string FirstName { get; }
			public string LastName { get; }

			public Student(string firstName, string lastName)
			{
				FirstName = firstName;
				LastName = lastName;

				_fullName = $"Hello, {FirstName} {LastName}";
			}

			public string GetFullName()
			{
				return _fullName;
			}
		}
	}
}
