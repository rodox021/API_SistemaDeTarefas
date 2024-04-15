using API_SistemaDeTarefas.Models;
using API_SistemaDeTarefas.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository userRepository)
        {
            _todoRepository = userRepository;
        }
        //========================================================================


        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> BuscarTodosUsuarios()
        {

            List<TodoModel> todo= await _todoRepository.BuscarTodastarefas() ;
            return Ok(todo);
        } 
        
        //------------------------------------------------------------------------------------------------------------
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> BuscarPorId(long id)
        {

            TodoModel todo= await _todoRepository.BuscarPorId(id) ;
            return Ok(todo);
        }


        //------------------------------------------------------------------------------------------------------------

        [HttpPost]
        public async Task<ActionResult<TodoModel>> Cadastrar([FromBody] TodoModel todo)
        {
            var newTodo = await _todoRepository.Adicionar(todo); 
            return Ok(newTodo);
        }

        //------------------------------------------------------------------------------------------------------------

        [HttpPut]
        public async Task<ActionResult<TodoModel>> Atualizar([FromBody] TodoModel todo)
        {
            

            if (todo == null) 
            {
                return BadRequest();
            }
            var newTodo = await _todoRepository.Atualizar(todo, todo.Id);
            return Ok(newTodo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoModel>>Apagar(long id)
        {
            var todo = _todoRepository.BuscarPorId(id);
            if (todo == null)
            {
                return BadRequest();
            }
           
            return Ok(await _todoRepository.Apagar(id));
        }





    }//------------------------END COntroller----------------------------------------------------------------------
}
