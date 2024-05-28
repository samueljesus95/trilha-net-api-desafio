using System;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Services
{
    public interface ITarefaService
    {
        Tarefa ObterPorId(int id);
        List<Tarefa> ObterTodos();
        Tarefa ObterPorTitulo(string titulo);
        Tarefa ObterPorData(DateTime data);
        Tarefa ObterPorStatus(EnumStatusTarefa status);
        void Criar(Tarefa tarefa);
        void Atualizar(Tarefa tarefa);
        void Deletar(int id);
    }
}