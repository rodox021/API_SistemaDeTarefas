using System.ComponentModel;

namespace API_SistemaDeTarefas.Enums
{
    public enum StatusTodo
    {
        [Description("A fazer")]
        Todo = 1,
        [Description("Em andamento")]
        InProgress = 2,
        [Description("Concluído")]
        Coclued = 3,

    }
}
