using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part3ObjectOriented.Ex5
{
	public class PlayWithContactInterfaceTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithContactInterfaceTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CreateInstanceForClassesThatInheritsFromPersonClass()
		{
			// 1. Create interface IEmailContact with method
			// - string GetEmailAddress()
			// 2.  Create interface IMobilePhoneContact with method
			// - string GetMobilePhoneNumber()
			// 3. Make Student and Teacher class to implement IEmailContact interface
			// 4. Make Teacher class to implement IMobilePhoneContact interface
			// 5. Create variables as instances for Student and Teacher classes
			// 6. Run function SendEmail for Student and Teacher instances
			//    SendSms(IMobilePhoneContact contact, string message)
			// 7. Run function SendSms for Teacher instances
			//    SendEmail(IEmailContact contact, string message)

			var student = new Student();
			var teacher = new Teacher();

			var studentEmail = string.Empty;
			var teacherEmail = string.Empty;
			var teacherPhoneNumber = string.Empty;

			studentEmail.Should().NotBeNullOrWhiteSpace();
			teacherEmail.Should().NotBeNullOrWhiteSpace();
			teacherPhoneNumber.Should().NotBeNullOrWhiteSpace();
		}

		public class Student : Person
		{
		}

		public class Teacher : Person
		{
		}

		public class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
		}
	}
}
