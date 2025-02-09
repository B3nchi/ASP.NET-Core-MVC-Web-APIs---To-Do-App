using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Logic;
using TodoApi.Models;

namespace TodoApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoLogic _todoLogic;

        public TodoController(TodoLogic todoLogic)
        {
            _todoLogic = todoLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
        {

            return Ok(await _todoLogic.GetTodosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoById(Guid todoId)
        {
            var todo = await _todoLogic.GetTodoByIdAsync(todoId);
            if (todo == null)
            {
                return BadRequest();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodo(TodoItem todo)
        {
            var newTodo = await _todoLogic.CreateTodoAsync(todo);

            return newTodo;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodo(Guid id, TodoItem updateTodo)
        {
            var success = await _todoLogic.UpdateTodoAsync(id, updateTodo);
            if(success == false)
            {
                return BadRequest();
            }

            return Ok(success);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var success = await _todoLogic.DeleteTodoAsync(id);
            if (success == false)
            {
                return NotFound();
            }

            return Ok(success);
        }

    }
}
