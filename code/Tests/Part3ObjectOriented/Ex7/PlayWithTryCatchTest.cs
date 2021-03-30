using System;
using FluentAssertions;
using FluentAssertions.Specialized;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part3ObjectOriented.Ex7
{
	public class PlayWithTryCatchTest
	{
		private readonly ITestOutputHelper _outputHelper;

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

			try
			{
				DoSomething();
			}
			catch (NotImplementedException e)
			{
				exceptionHandled = true;
				_outputHelper.WriteLine($"{e.Message}");
			}
			catch (Exception e)
			{
				_outputHelper.WriteLine($"{e.Message}");
			}
			finally
			{
				_outputHelper.WriteLine("Run final block");
			}
			

			exceptionHandled.Should().BeTrue();
		}

		private void DoSomething()
		{
			throw new NotImplementedException();
		}
	}
}