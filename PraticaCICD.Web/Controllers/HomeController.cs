using Microsoft.AspNetCore.Mvc;
using PraticaCICD.Web.DTOs;
using PraticaCICD.Web.Models;
using PraticaCICD.Web.Services;
using System.Diagnostics;

namespace PraticaCICD.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoupaService _service;

        public HomeController(IRoupaService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var response = _service.ObterTodos()
                .GetAwaiter()
                .GetResult();

            var model = response.Select(x => new RoupaViewModel
            {
                Id = x.Id,
                Preco = x.Preco,
                Tamanho = x.Tamanho,
                Tipo = x.Tipo
            }).ToList();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoupaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roupaDTO = new RoupaDTO();
                roupaDTO.Tipo = model.Tipo;
                roupaDTO.Tamanho = model.Tamanho;
                roupaDTO.Preco = model.Preco;
                

                var response = _service.Adicionar(roupaDTO)
                    .GetAwaiter()
                    .GetResult();

                if (response) return RedirectToAction("Index");

                return View(model);
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
