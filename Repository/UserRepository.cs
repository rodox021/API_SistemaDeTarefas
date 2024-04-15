using API_SistemaDeTarefas.Data;
using API_SistemaDeTarefas.Models;
using API_SistemaDeTarefas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_SistemaDeTarefas.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextTodo _dbContext;

        public UserRepository(DbContextTodo dbContext)
        {
            _dbContext = dbContext;
        }
        //---------------------------------------------------------------------------
        public async Task<UserModel> Adicionar(UserModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;

        }
        //---------------------------------------------------------------------------
        public async Task<bool> Apagar(long id)
        {
            UserModel user = await BuscarPorId(id);

            if (user == null)
            {
                throw new Exception($"Usuario eferente ao ID: {id} não foi encontrato");
            }

            _dbContext.Usuarios.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;

        }
        //---------------------------------------------------------------------------
        public async Task<UserModel> Atualizar(UserModel usuario, long id)
        {
            UserModel user = await BuscarPorId(id);

            if (user == null) 
            {
                throw new Exception($"Usuario eferente ao ID: {id} não foi encontrato");
            }

            user.Name= usuario.Name;
            user.Email= usuario.Email;

            _dbContext.Usuarios.Update(user);
           await _dbContext.SaveChangesAsync();
            return user;


        }
        //---------------------------------------------------------------------------
        public async Task<UserModel> BuscarPorId(long id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }
        //---------------------------------------------------------------------------
        public async Task<List<UserModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
    }
}
