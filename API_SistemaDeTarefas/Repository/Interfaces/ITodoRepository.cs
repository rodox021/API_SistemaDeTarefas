using API_SistemaDeTarefas.Models;

namespace API_SistemaDeTarefas.Repository.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<TodoModel>> BuscarTodastarefas();
        Task<TodoModel> BuscarPorId(long id);
        Task<TodoModel> Adicionar(TodoModel tarefa);
        Task<TodoModel> Atualizar(TodoModel tarefa, long id);
        Task<bool> Apagar(long id);
    }
}

