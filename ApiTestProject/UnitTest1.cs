using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTestProject
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public async Task GETRequestFromAPIReturns200Async()
        {
            //url
            var url = "https://jsonplaceholder.typicode.com/posts/1";

            //httpClient
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
           
            //resonse is ok
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);            
        }
        [Test]
        public async Task GetRequestFromApiReturnsBody()
        {
            //url
            var url = "https://jsonplaceholder.typicode.com/posts/1";
            var expectedBody = "{\"userId\": 1,\"id\": 1,\"title\":\"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\",\"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";
            expectedBody = expectedBody.Replace(" ", "").Replace("\n","");

            //httpClient
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            var messageBody = await response.Content.ReadAsStringAsync();
            messageBody = messageBody.Replace(" ", "").Replace("\n", "");

            //response
            Assert.AreEqual(expectedBody, messageBody);
        }

    }
}