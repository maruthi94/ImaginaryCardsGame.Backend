using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Net.Http;

namespace ImaginaryCardsGame.Backend.iTest
{
    public class CustomTestBase
    {
        private WebApplicationFactory<Program> applicationFactory;
        protected HttpClient httpClient;

        [OneTimeSetUp]
        public void Init()
        {
            applicationFactory = new WebApplicationFactory<Program>();
            httpClient = applicationFactory.CreateClient();
        }
    }
}