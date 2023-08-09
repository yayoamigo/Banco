using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Banco.WebApi.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Banco.WebApi.Infrastructure;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BancoTest.IntegrationTest
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                // Replace 'UseSqlServer' with 'UseInMemoryDatabase' to use an in-memory database for testing
                services.AddDbContext<BancoDbContext>(options =>
                    options.UseInMemoryDatabase("TestDb"));

                // Add any other test-specific services
            });
        }
    }

    public class PersonaIntegrationTests : IClassFixture<WebApplicationFactory<Program>> // Just use 'Program' without a specific namespace
    {
        private readonly HttpClient _client;

        public PersonaIntegrationTests(WebApplicationFactory<Program> factory) // Just use 'Program' without a specific namespace
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AddPersona_Success()
        {
            // Arrange
            var requestContent = new StringContent(JsonConvert.SerializeObject(new PersonaAddRequest
            {
                Identificacion = 123456774,
                Nombre= "david234",
                
            }), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Personas", requestContent);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error response: {errorContent}");
            }

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var personaResponse = JsonConvert.DeserializeObject<PersonaResponse>(responseContent);
            Assert.Equal(123456774, personaResponse.Identificacion);
            
        }
    }
}
