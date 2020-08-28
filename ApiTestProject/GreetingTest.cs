
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApiTestProject
{
    [TestFixture]
    public class GreetingTest
    {
        [Test]
        public void HelloWorldGreeting_HelloWorld_ShouldReturnHelloWorld()
        {
            //Arrange                      
            string result;

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                //Act
                ConsoleApp1.Program.Main();

                result = sw.ToString().Trim();
            }
            
            //Assert
            Assert.AreEqual("Hello World!", result);
        }
    }
}
