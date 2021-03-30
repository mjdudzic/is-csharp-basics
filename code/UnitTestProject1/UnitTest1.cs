using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			//Arrange
			int liczba1 = 10;
			int liczba2 = 11;
			int expected = 21;

			//Act
			var result = liczba1 + liczba2;

			//Assert
			Assert.AreEqual(expected, result);
		}
	}
}
