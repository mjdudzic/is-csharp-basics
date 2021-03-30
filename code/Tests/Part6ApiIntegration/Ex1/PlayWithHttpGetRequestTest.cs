using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part6ApiIntegration.Ex1
{
	public class PlayWithHttpGetRequestTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithHttpGetRequestTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public async Task ValidateRequestCompletedSuccessfully()
		{
			var apiEndpoint = new Uri("https://jsonplaceholder.typicode.com/posts/1");

			var client = new HttpClient();

			var response = await client.GetAsync(apiEndpoint);

			_outputHelper.WriteLine($"response status code: {response.StatusCode}");

			var result = response.IsSuccessStatusCode;

			result.Should().BeTrue();
		}

		[Fact]
		public async Task GetResponseAsString()
		{
			var apiEndpoint = new Uri("https://jsonplaceholder.typicode.com/posts/1");

			var client = new HttpClient();

			var response = await client.GetStringAsync(apiEndpoint);

			_outputHelper.WriteLine($"response is: {response}");

			var result = response;

			result.Should().NotBeNullOrWhiteSpace();
		}

		[Fact]
		public async Task GetResponseAsStringButAllowResponseValidationFirst()
		{
			var apiEndpoint = new Uri("https://jsonplaceholder.typicode.com/posts/1");

			var client = new HttpClient();

			var response = await client.GetAsync(apiEndpoint);

			var content = await response.Content.ReadAsStringAsync();

			_outputHelper.WriteLine($"response status code: {response.StatusCode}");
			_outputHelper.WriteLine($"content is: {content}");

			var result = response.IsSuccessStatusCode;

			result.Should().BeTrue();
		}

		[Fact]
		public async Task GetResponseAsObject()
		{
			var apiEndpoint = new Uri("https://jsonplaceholder.typicode.com/posts/1");

			var client = new HttpClient();

			var response = await client.GetAsync(apiEndpoint);

			var content = await response.Content.ReadAsStringAsync();

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			var post = JsonSerializer.Deserialize<Post>(content, options);

			_outputHelper.WriteLine($"response status code: {response.StatusCode}");
			_outputHelper.WriteLine($"post body is: {post?.Body}");

			var result = response.IsSuccessStatusCode;

			result.Should().BeTrue();
		}

		[Fact]
		public async Task GetResponseAsObjectEasierWay()
		{
			var apiEndpoint = new Uri("https://jsonplaceholder.typicode.com/posts/1");

			var client = new HttpClient();

			var post = await client.GetFromJsonAsync<Post>(apiEndpoint);

			_outputHelper.WriteLine($"post body is: {post?.Body}");

			var result = post?.Body;

			result.Should().NotBeNullOrWhiteSpace();
		}
	}

	public class Post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public int UserId { get; set; }
	}
}
