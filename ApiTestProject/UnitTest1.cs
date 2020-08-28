using NUnit.Framework;
using System.Net.Http;

namespace ApiTestProject
{
    public class Tests
    {
        [Test]
        public async void GETRequestFromAPIReturns200Async()
        {
            //url
            var url = "https://jsonplaceholder.typicode.com/posts/1";

            //httpClient
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
           
            //resonse is ok
            Assert.AreEqual(200, response.StatusCode);
            
        }
    }
}