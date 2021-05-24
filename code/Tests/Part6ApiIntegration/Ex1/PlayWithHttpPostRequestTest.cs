using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part6ApiIntegration.Ex1
{
	public class PlayWithHttpPostRequestTest
	{
		private readonly ITestOutputHelper _outputHelper;
		private Fixture _fixture = new Fixture();

		public PlayWithHttpPostRequestTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public async Task CallApiToAddNewBook()
		{
			var apiEndpoint = new Uri("https://is-mjd-books.azurewebsites.net/books");

			var client = new HttpClient();
			var request = new HttpRequestMessage();

			var book = _fixture.Create<Book>();
			var response = await client.PostAsync(
				apiEndpoint, 
				new StringContent(
					JsonSerializer.Serialize(book), 
					Encoding.UTF8, 
					"application/json"));

			var content = await response.Content.ReadAsStringAsync();

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			var post = JsonSerializer.Deserialize<Book>(content, options);

			_outputHelper.WriteLine($"response status code: {response.StatusCode}");
			_outputHelper.WriteLine($"new book isbn is: {post?.Isbn}");

			var result = response.IsSuccessStatusCode;

			result.Should().BeTrue();
		}

		[Fact]
		public async Task CallApiToAddNewBook2()
		{
			var apiEndpoint = new Uri("https://is-mjd-books.azurewebsites.net/books");

			var client = new HttpClient();

			var response = await client.PostAsJsonAsync(apiEndpoint, _fixture.Create<Book>());

			var content = await response.Content.ReadAsStringAsync();

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			var post = JsonSerializer.Deserialize<Book>(content, options);

			_outputHelper.WriteLine($"response status code: {response.StatusCode}");
			_outputHelper.WriteLine($"new book isbn is: {post?.Isbn}");

			var result = response.IsSuccessStatusCode;

			result.Should().BeTrue();
		}
	}

	public class Book
	{
		public string Isbn { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public DateTime PublishedAt { get; set; }
		public double ScoreAvg { get; set; }
	}
}
