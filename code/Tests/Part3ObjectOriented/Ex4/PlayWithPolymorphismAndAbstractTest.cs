using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part3ObjectOriented.Ex4
{
	public class PlayWithPolymorphismAndAbstractTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithPolymorphismAndAbstractTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CreateAbstractPersonClassWithAbstractMethod()
		{
			// 1. Create abstract class Person that will have following properties
			// - FirstName (string)
			// - LastName (string)
			// 2. Create abstract function GetFullName in Person class
			// 3. Create classes Student and Teacher that will inherit from Person class
			// 4. Add property Title (string) to class Teacher
			// 5. Override GetFullName method in Student class os it returns full name that consists of FirstName and Lastname
			// 6. Override GetFullName method in Teacher class os it returns full name that consists of Title FirstName and Lastname
			// 7. Create instance of these classes and assign some values to properties 
			// 8. Create variable to store full name for Student and for Teacher

			var student = new Student
			{
				FirstName = "Jan",
				LastName = "Kowalski"
			};
			var teacher = new Teacher
			{
				FirstName = "Ann",
				LastName = "Kowalski"
			};
			var studentFullName = student.GetFullName();
			var teacherFullName = teacher.GetFullName();

			_outputHelper.WriteLine($"Student full name is {studentFullName}");
			_outputHelper.WriteLine($"Teacher full name is {teacherFullName}");

			studentFullName.Should().NotBeNullOrWhiteSpace();
			teacherFullName.Should().NotBeNullOrWhiteSpace();
		}

		public class Student : Person
		{
			public override string GetFullName()
			{
				return $"{FirstName} {LastName}";
			}
		}

		public class Teacher : Person
		{
			public string Title { get; set; }
			public override string GetFullName()
			{
				return $"{Title} {FirstName} {LastName}";
			}
		}

		public abstract class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }

			public abstract string GetFullName();
		}
	}
}