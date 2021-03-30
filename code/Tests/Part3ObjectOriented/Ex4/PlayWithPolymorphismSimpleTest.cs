using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part3ObjectOriented.Ex4
{
	public class PlayWithPolymorphismSimpleTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithPolymorphismSimpleTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CreateInstanceForClassesThatInheritsFromPersonClass()
		{
			// 1. Create class Person that will have following properties
			// - FirstName (string)
			// - LastName (string)
			// 2. Add function in this class that will return student full name
			// 3. Create classes Student and Teacher that will inherit from Person class
			// 4. Create instance of these classes and assign some values to properties 
			// 5. Create variable to store full name for Student and for Teacher

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

			public virtual string GetFullName()
			{
				return $"{FirstName} {LastName}";
			}
		}
	}
}
