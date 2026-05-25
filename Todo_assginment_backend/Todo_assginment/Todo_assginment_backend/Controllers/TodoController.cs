using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Todo_assginment.Models;
using Todo_assginment.Service;

namespace Todo_assginment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> Getalltodo()
        {
            var todos = await _todoService.GetAllTodos();
            return Ok(todos);
        }
        [HttpGet("{title}")]
        public async Task<ActionResult<Todo>> Getbytitle(string title)
        {
            var todo = await _todoService.GetbyTitle(title);
            return Ok(todo);
        }
        [HttpPost]
        public async Task<ActionResult<Todo>> AddTodo([FromBody] Todo todo)
        {

            await _todoService.CreateTodo(todo);
            return CreatedAtAction(nameof(Getbytitle), new { title = todo.Title }, todo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            await _todoService.DeleteTodo(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodo(int id, [FromBody] Todo todo)
        {
            await _todoService.UpdateTodo(id, todo);
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable>> Search([FromQuery] string keyword)
        {
            var todos = await _todoService.SearchTodos(keyword);
            return Ok(todos);
        }

        [HttpGet("categorize/{categorize}")]
        public async Task<ActionResult<IEnumerable>> GetByCategorize([FromQuery] Categorize categorize)
        {
            var todos = await _todoService.GetByCategorize(categorize);
            return Ok(todos);
        }

        [HttpGet("priority/{priority}")]
        public async Task<ActionResult<IEnumerable>> GetByPriority([FromQuery] PriorityLevel priority)
        {
            var todos = await _todoService.GetByPrioroty(priority);
            return Ok(todos);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Todo>> GetById(int id)
        {
            var todo = await _todoService.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }
        [HttpGet("title/{title}")]
        public async Task<ActionResult<Todo>> GetByTitle(string title)
        {
            var todo = await _todoService.GetbyTitle(title);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }
    }
}