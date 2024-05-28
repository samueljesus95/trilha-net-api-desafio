using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Context;
using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Services;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController(ITarefaService tarefaService) : ControllerBase
    {
        private readonly ITarefaService _tarefaService = tarefaService;

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _tarefaService.ObterPorId(id);
            return Ok(tarefa);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var tarefa = _tarefaService.ObterTodos();
            return Ok(tarefa);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefa = _tarefaService.ObterPorTitulo(titulo);
            return Ok(tarefa);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _tarefaService.ObterPorData(data);
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefa = _tarefaService.ObterPorStatus(status);
            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa == null)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _tarefaService.Criar(tarefa);
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {

            if (tarefa == null)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            var tarefaExistente = _tarefaService.ObterPorId(id);
            if (tarefaExistente == null)
                return NotFound();

            _tarefaService.Atualizar(tarefa);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaExistente = _tarefaService.ObterPorId(id);
            if (tarefaExistente == null)
                return NotFound();

            _tarefaService.Deletar(id);
            return NoContent();
        }
    }
}
