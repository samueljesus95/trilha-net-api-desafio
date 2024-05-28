using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TrilhaApiDesafio.Repositories
{
    public class TarefaRepository(OrganizadorContext organizadorContext) : ITarefaRepository
    {
        private readonly OrganizadorContext _organizadorContext = organizadorContext;
        public void Atualizar(Tarefa tarefa)
        {
            ArgumentNullException.ThrowIfNull(tarefa);

            _organizadorContext.Entry(tarefa).State = EntityState.Modified;
            _organizadorContext.SaveChanges();
        }

        public void Criar(Tarefa tarefa)
        {
            ArgumentNullException.ThrowIfNull(tarefa);

            _organizadorContext.Tarefas.Add(tarefa);
            _organizadorContext.SaveChanges();

        }

        public void Deletar(int id)
        {
            var tarefa = _organizadorContext.Tarefas.Find(id);
            ArgumentNullException.ThrowIfNull(tarefa);

            _organizadorContext.Tarefas.Remove(tarefa);
            _organizadorContext.SaveChanges();
        }

        public Tarefa ObterPorData(DateTime data)
        {
            return _organizadorContext.Tarefas.FirstOrDefault(x => x.Data == data);
        }

        public Tarefa ObterPorId(int id)
        {
            return _organizadorContext.Tarefas.FirstOrDefault(x => x.Id == id);
        }

        public Tarefa ObterPorStatus(EnumStatusTarefa status)
        {
            return _organizadorContext.Tarefas.FirstOrDefault(x => x.Status == status);
        }

        public Tarefa ObterPorTitulo(string titulo)
        {
            return _organizadorContext.Tarefas.FirstOrDefault(x => x.Titulo == titulo);
        }

        public List<Tarefa> ObterTodos()
        {
            return _organizadorContext.Tarefas.ToList();
        }
    }
}