using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using PraticaCICD.Api.Controllers;
using PraticaCICD.Api.Data.Context;
using PraticaCICD.Api.Data.Entities;
using PraticaCICD.Api.Data.Repositories;
using System.Net;

namespace PraticaCICD.Tests.Api
{
    public class RoupaControllerTests
    {
        [Fact]
        public async Task ObterTodosRetornaOk()
        {

            // PARA TESTE DE INTEGRAÇÃO

            //var options = new DbContextOptionsBuilder<BancoContext>()
            //    .UseInMemoryDatabase(databaseName: "PraticaCICD").Options;
            //using var context = new BancoContext(options);

            // ============================================================ //

            var repositoryMoq = new Mock<IRoupaRepository>();

            var listaRoupas = new List<Roupa>();

            repositoryMoq.Setup(x => x.ObterTodos().Result).Returns(listaRoupas);

            var controller = new RoupaController(repositoryMoq.Object);

            var response = (OkObjectResult)await controller.ObterTodos();

            Assert.Equal(200, response.StatusCode);
            //Assert.Equal(200, 200);

            //Assert.IsType<OkObjectResult>(response.StatusCode);
        }
    }
}
