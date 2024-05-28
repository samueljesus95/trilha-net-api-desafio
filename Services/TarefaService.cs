using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Repositories;

namespace TrilhaApiDesafio.Services
{
    public class TarefaService(ITarefaRepository tarefaRepository) : ITarefaService
    {
        public void Atualizar(Tarefa tarefa)
        {
            tarefaRepository.Atualizar(tarefa);
        }

        public void Criar(Tarefa tarefa)
        {
            tarefaRepository.Criar(tarefa);
        }

        public void Deletar(int id)
        {
            tarefaRepository.Deletar(id);
        }

        public Tarefa ObterPorData(DateTime data)
        {
            return tarefaRepository.ObterPorData(data);
        }

        public Tarefa ObterPorId(int id)
        {
            return tarefaRepository.ObterPorId(id);
        }

        public Tarefa ObterPorStatus(EnumStatusTarefa status)
        {
            return tarefaRepository.ObterPorStatus(status);
        }

        public Tarefa ObterPorTitulo(string titulo)
        {
            return tarefaRepository.ObterPorTitulo(titulo);
        }

        public List<Tarefa> ObterTodos()
        {
            return tarefaRepository.ObterTodos();
        }
    }
}