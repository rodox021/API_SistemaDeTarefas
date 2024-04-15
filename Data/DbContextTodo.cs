using API_SistemaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_SistemaDeTarefas.Data
{
    public class DbContextTodo: DbContext
    {
        public DbContextTodo(DbContextOptions<DbContextTodo> options):base (options) 
        {
            Database.EnsureCreated(); 
        }

        public DbSet<UserModel> Usuarios { get; set; }
        public DbSet<TodoModel> Tarefas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
