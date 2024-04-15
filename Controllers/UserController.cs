using API_SistemaDeTarefas.Models;
using API_SistemaDeTarefas.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //========================================================================


        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> BuscarTodosUsuarios()
        {

            List<UserModel> users= await _userRepository.BuscarTodosUsuarios() ;
            return Ok(users);
        } 
        
        //------------------------------------------------------------------------------------------------------------
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> BuscarPorId(long id)
        {

            UserModel users= await _userRepository.BuscarPorId(id) ;
            return Ok(users);
        }


        //------------------------------------------------------------------------------------------------------------

        [HttpPost]
        public async Task<ActionResult<UserModel>> Cadastrar([FromBody] UserModel user)
        {
            var newUser = await _userRepository.Adicionar(user); 
            return Ok(newUser);
        }

        //------------------------------------------------------------------------------------------------------------

        [HttpPut]
        public async Task<ActionResult<UserModel>> Atualizar([FromBody] UserModel user)
        {
            

            if (user == null) 
            {
                return BadRequest();
            }
            var newUser = await _userRepository.Atualizar(user, user.Id);
            return Ok(newUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>>Apagar(long id)
        {
            var user = _userRepository.BuscarPorId(id);
            if (user == null)
            {
                return BadRequest();
            }
           
            return Ok(await _userRepository.Apagar(id));
        }





    }//------------------------END COntroller----------------------------------------------------------------------
}
