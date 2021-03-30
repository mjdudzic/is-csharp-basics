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
			var worker = new Worker();
			
			SendEmail(student, "Hello");
			SendEmail(teacher, "Hello");
			SendEmail(worker, "Hello");
			
			SendSms(teacher, "Hello");

			var studentEmail = student.GetEmailAddress();
			var teacherEmail = teacher.GetEmailAddress();
			var teacherPhoneNumber = teacher.GetMobilePhoneNumber();

			studentEmail.Should().NotBeNullOrWhiteSpace();
			teacherEmail.Should().NotBeNullOrWhiteSpace();
			teacherPhoneNumber.Should().NotBeNullOrWhiteSpace();
		}

		public class Student : Person, IEmailContact
		{
			public string GetEmailAddress()
			{
				return "email@com";
			}
		}

		public class Worker : IEmailContact, IMobilePhoneContact
		{
			public string GetEmailAddress()
			{
				return "email@com";
			}

			public string GetMobilePhoneNumber()
			{
				return "1234";
			}
		}

		public class Teacher : Person, IEmailContact, IMobilePhoneContact
		{
			public string PhoneNumber { get; set; }
			public string GetMobilePhoneNumber()
			{
				return "1234";
			}

			public string GetEmailAddress()
			{
				return "email@com";
			}
		}

		public class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
		}

		public interface IEmailContact
		{
			string GetEmailAddress();
		}

		public interface IMobilePhoneContact
		{
			string GetMobilePhoneNumber();
		}

		public void SendSms(IMobilePhoneContact contact, string message)
		{
			
			_outputHelper.WriteLine($"SMS message '{message}' sent to {contact.GetMobilePhoneNumber()}");
		}

		public void SendEmail(IEmailContact contact, string message)
		{
			_outputHelper.WriteLine($"Email message '{message}' sent to {contact.GetEmailAddress()}");
		}
	}
}
