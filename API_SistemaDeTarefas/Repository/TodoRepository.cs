using API_SistemaDeTarefas.Data;
using API_SistemaDeTarefas.Models;
using API_SistemaDeTarefas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_SistemaDeTarefas.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DbContextTodo _dbContext;

        public TodoRepository(DbContextTodo dbContext)
        {
            _dbContext = dbContext;
        }
        //---------------------------------------------------------------------------
        public async Task<TodoModel> Adicionar(TodoModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;

        }
        //---------------------------------------------------------------------------
        public async Task<bool> Apagar(long id)
        {
            TodoModel todo = await BuscarPorId(id);

            if (todo == null)
            {
                throw new Exception($"tarefa eferente ao ID: {id} não foi encontrato");
            }

            _dbContext.Tarefas.Remove(todo);
            await _dbContext.SaveChangesAsync();
            return true;

        }
        //---------------------------------------------------------------------------
        public async Task<TodoModel> Atualizar(TodoModel tarefa, long id)
        {
            TodoModel todo = await BuscarPorId(id);

            if (todo == null)
            {
                throw new Exception($"tarefa referente ao ID: {id} não foi encontrato");
            }

            todo.Name = tarefa.Name;
            todo.Description = tarefa.Description;
            todo.Status = tarefa.Status;
            todo.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(todo);
            await _dbContext.SaveChangesAsync();
            return todo;


        }
        //---------------------------------------------------------------------------
        public async Task<TodoModel> BuscarPorId(long id)
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        //---------------------------------------------------------------------------
        public async Task<List<TodoModel>> BuscarTodastarefas()
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

    }
}
