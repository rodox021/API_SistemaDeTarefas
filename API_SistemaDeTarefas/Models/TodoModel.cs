using API_SistemaDeTarefas.Enums;

namespace API_SistemaDeTarefas.Models
{
    public class TodoModel
    {
        public long Id  { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTodo Status { get; set; }
        public long? UsuarioId { get; set; }

        public virtual UserModel? Usuario { get; set; }


    }
}
