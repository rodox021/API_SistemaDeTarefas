using API_SistemaDeTarefas.Models.Enums;

namespace API_SistemaDeTarefas.Models
{
    public class TodoModel
    {
        public long Id  { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }


    }
}
