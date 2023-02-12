using API_SistemaDeTarefas.Models;

namespace API_SistemaDeTarefas.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> BuscarTodosUsuarios();
        Task<UserModel> BuscarPorId(long id);
        Task<UserModel> Adicionar(UserModel usuario);
        Task<UserModel> Atualizar(UserModel usuario, long id);
        Task<bool> Apagar(long id);
    }
}
