using Microsoft.AspNetCore.Mvc;
using PraticaCICD.Api.Data.Entities;
using PraticaCICD.Api.Data.Repositories;
using PraticaCICD.Api.DTOs;

namespace PraticaCICD.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoupaController : ControllerBase
    {
        private readonly IRoupaRepository _repository;
        public RoupaController(IRoupaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult> ObterTodos()
        {
            var roupas = await _repository.ObterTodos();

            var roupasDTO = roupas.Select(roupa => new RoupaDTO
            {
                Id = roupa.Id,
                Preco = roupa.Preco,
                Tamanho = roupa.Tamanho,
                Tipo = roupa.Tipo
            }).ToList();

            return Ok(roupasDTO);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Adicionar([FromBody] RoupaDTO roupaDTO)
        {
            if (roupaDTO == null)
            {
                return BadRequest();
            }

            var roupa = new Roupa();

            roupa.Id = roupaDTO.Id;
            roupa.Tamanho = roupaDTO.Tamanho;
            roupa.Preco = roupaDTO.Preco;
            roupa.Tipo = roupaDTO.Tipo;

            await _repository.Adicionar(roupa);

            return Created();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var roupa = await _repository.ObterPorId(id);
            if (roupa == null) return NotFound();
            return Ok(roupa);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Atualizar(int id, [FromBody] RoupaDTO roupaDTO)
        {
            var roupa = await _repository.ObterPorId(id);
            if (roupa == null) return NotFound();

            roupa.Tamanho = roupaDTO.Tamanho;
            roupa.Tipo = roupaDTO.Tipo;
            roupa.Preco = roupaDTO.Preco;

            await _repository.Atualizar(roupa);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Deletar(int id)
        {
            var roupa = await _repository.ObterPorId(id);
            if (roupa == null) return NotFound();

            await _repository.Deletar(roupa);
            return NoContent();
        }
    }
}
