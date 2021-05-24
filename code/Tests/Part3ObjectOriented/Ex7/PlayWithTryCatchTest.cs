using System;
using Castle.Core.Logging;
using FluentAssertions;
using FluentAssertions.Specialized;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part3ObjectOriented.Ex7
{
	public class PlayWithTryCatchTest
	{
		private readonly ITestOutputHelper _outputHelper;
		private readonly ILogger _logger;

		public PlayWithTryCatchTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CreateUniversitySystemNamespaces()
		{
			// 1. Create function that on run throws NotImplementedException
			// 2. Write a code to catch exceptions in following way
			// - On NotImplementedException write a line to test output (_outputHelper)
			//   and set exceptionHandled variable to true
			// - On Other type of exceptions write a line to test output and throw the same exception further
			// - At final write a line wit a message operation has been completed

			var exceptionHandled = false;
			//DoSomething();

			try
			{
				DoSomething();
			}
			catch (NotImplementedException e)
			{
				exceptionHandled = true;
				_outputHelper.WriteLine($"NotImplementedException {e.Message}");
			}
			catch (MyException e)
			{
				exceptionHandled = true;
				_outputHelper.WriteLine($"MyException {e.Message}");

				//throw;
			}
			catch (Exception e)
			{
				_outputHelper.WriteLine($"Exception {e.Message}");
			}
			finally
			{
				_outputHelper.WriteLine("Run final block");
			}
			
			exceptionHandled.Should().BeTrue();
		}

		private void DoSomething()
		{
			throw new MyException("Coœ posz³o nie tak");
		}

		private class MyException : Exception
		{
			public MyException(string message)
				: base(message)
			{
			}
		}
	}
}
