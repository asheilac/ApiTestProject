using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace ApiTestProject
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public async Task GeTRequestFromApiReturns200Async()
        {
            //url
            var url = "https://jsonplaceholder.typicode.com/posts/1";

            //httpClient
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            //response is ok
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public async Task GetRequestFromApiReturnsBody()
        {
            //url
            var url = "https://jsonplaceholder.typicode.com/posts/1";

            JsonPlaceHolder json = new JsonPlaceHolder
            {
                userId = 1,
                id = 1,
                title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
            };

            var expectedBody = JsonConvert.SerializeObject(json, Formatting.None);
            
            //httpClient
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            var messageBody = await response.Content.ReadAsStringAsync();
            messageBody = messageBody.Replace(" ", "").Replace("\n", "");

            //response
            Assert.AreEqual(expectedBody, messageBody);
        }
        [Test]
        public async Task GetRequestFromApiReturnsTitle()
        {
            var url = "https://jsonplaceholder.typicode.com/posts/1";

            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var responseTitle = JsonConvert.DeserializeObject<JsonPlaceHolder>(json);

            responseTitle.title.Should()
                .Be("sunt aut facere repellat provident occaecati excepturi optio reprehenderit");
        }
        [Test]
        public async Task PostRequestFromApiReturnsBody()
        {
            //url
            var url = "https://jsonplaceholder.typicode.com/posts";

            JsonPlaceHolder json = new JsonPlaceHolder
            {
                userId = 5,
                id = 5,
                title = "bloop",
                body = "bleepbloop bleepblopp bloop"
            };
            
            var expectedBody = JsonConvert.SerializeObject(json, Formatting.None);
            var content = new StringContent(expectedBody, Encoding.UTF8, "application/json");
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
           
            //httpclient
            using var client = new HttpClient();

            var responsePost = await client.PostAsync(url, content);
           
            //assert on response code
            responsePost.StatusCode.Should().Be(HttpStatusCode.Created);
        }

    }
}