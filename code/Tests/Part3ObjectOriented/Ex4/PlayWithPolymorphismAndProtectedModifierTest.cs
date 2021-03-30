using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part3ObjectOriented.Ex4
{
	public class PlayWithPolymorphismAndProtectedModifierTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithPolymorphismAndProtectedModifierTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CreateAbstractPersonClassWithProtectedPropertiesMethod()
		{
			// 1. Create abstract class Person that will have following properties with protected access modifier
			// - FirstName (string)
			// - LastName (string)
			// 2. Create virtual function GetFullName in Person class.
			//    Function should return full name that consists of FirstName and LastName.
			// 3. Create classes Student and Teacher that will inherit from Person class
			// 4. Create constructor for Student and Teacher classes.
			//    Constructor should allow to setup protected properties. 
			// 5. Add private field _title (string) to class Teacher and set it up from constructor
			// 6. Override GetFullName method in Teacher class os it returns full name that consists of Title FirstName and Lastname
			// 7. Create instance of these classes and assign some values to properties 
			// 8. Create variable to store full name for Student and for Teacher


			var student = new Student("Jan", "Kowalski");
			var teacher = new Teacher("Ann", "Kowalski", "Dr");

			var studentFullName = student.GetFullName();
			var teacherFullName = teacher.GetFullName();

			_outputHelper.WriteLine($"Student full name is {studentFullName}");
			_outputHelper.WriteLine($"Teacher full name is {teacherFullName}");

			studentFullName.Should().NotBeNullOrWhiteSpace();
			teacherFullName.Should().NotBeNullOrWhiteSpace();
		}

		public class Student : Person
		{
			public Student(string firstName, string lastName)
			{
				FirstName = firstName;
				LastName = lastName;
			}
		}

		public class Teacher : Person
		{
			private readonly string _title;

			public Teacher(string firstName, string lastName, string title)
			{
				_title = title;
				FirstName = firstName;
				LastName = lastName;
			}

			public override string GetFullName()
			{
				return $"{_title} {FirstName} {LastName}";
			}
		}

		public abstract class Person
		{
			protected string FirstName { get; set; }
			protected string LastName { get; set; }

			public virtual string GetFullName()
			{
				return $"{FirstName} {LastName}";
			}
		}
	}
}
