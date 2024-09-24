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

            repositoryMoq.Setup(x => x.ObterTodos()).ReturnsAsync(listaRoupas);

            var controller = new RoupaController(repositoryMoq.Object);

            var response = (OkObjectResult)await controller.ObterTodos();

            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async Task ObterPorIdRetornaOk()
        {
            var repositoryMoq = new Mock<IRoupaRepository>();

            var roupa = new Roupa();

            repositoryMoq.Setup(x => x.ObterPorId(It.IsAny<int>())).ReturnsAsync(roupa);

            var controller = new RoupaController(repositoryMoq.Object);

            var res = (OkObjectResult)await controller.ObterPorId(1);

            Assert.NotNull(res);
            Assert.Equal(200, res.StatusCode);
            Assert.NotNull(res.Value);
            Assert.Equal(roupa, res.Value);
            Assert.IsType<Roupa>(res.Value);
        }

        [Fact]
        public async Task ObterPorIdRetornaNotFound()
        {

            var options = new DbContextOptionsBuilder<BancoContext>()
                .UseInMemoryDatabase(databaseName: "PraticaCICD").Options;

            using var context = new BancoContext(options);
            context.Roupas.AddRange(
                new Roupa() { Id = 1, Preco = 10, Tamanho = "G", Tipo = "Camiseta" },
                new Roupa() { Id = 2, Preco = 10, Tamanho = "G", Tipo = "Camiseta" },
                new Roupa() { Id = 3, Preco = 10, Tamanho = "G", Tipo = "Camiseta" },
                new Roupa() { Id = 4, Preco = 10, Tamanho = "G", Tipo = "Camiseta" }
            );
            context.SaveChanges();

            var repository = new RoupaRepository(context);

            var controller = new RoupaController(repository);

            var res = await controller.ObterPorId(5);

            Assert.IsType<NotFoundResult>(res);

        }

        [Fact]
        public async Task DeletarRoupaRetornaNoContent()
        {
            var repositoryMoq = new Mock<IRoupaRepository>();

            var roupa = new Roupa()
            {
                Id = 1,
                Preco = 10,
                Tamanho = "G",
                Tipo = "Camisa"
            };

            repositoryMoq.Setup(x => x.ObterPorId(1)).ReturnsAsync(roupa);

            repositoryMoq.Setup(x => x.Deletar(roupa));

            var controller = new RoupaController(repositoryMoq.Object);

            var res = await controller.Deletar(1) as NoContentResult;

            Assert.IsType<NoContentResult>(res);
            Assert.Equal(204, res.StatusCode);
        }
    }
}
