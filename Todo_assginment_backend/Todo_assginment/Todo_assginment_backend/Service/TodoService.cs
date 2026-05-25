using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Todo_assginment.custom_exceptions;
using Todo_assginment.Models;
using Todo_assginment.Repository;

namespace Todo_assginment.Service
{
    public class TodoService : ITodoService
    {
        private readonly Appdbcontext context;
        public TodoService(Appdbcontext context)
        {
            this.context = context;
        }

        public async Task<Todo> CreateTodo(Todo todo)
        {
            var newTodo = todo;
            await context.AddAsync(newTodo);
            await context.SaveChangesAsync();
            return newTodo;
        }

        public async Task DeleteTodo(int id)
        {
            var todo =  await context.Todos.FindAsync(id);
            if (todo != null)
            {
                context.Remove(todo);
                 await context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("Todo not found");
            }
        }

        public async Task<List<Todo>> GetAllTodos()
        {
            var todos = await context.Todos.ToListAsync();
            if(todos.Count == 0)
            {
                throw new NotFoundException("No todos found");
            }
            return todos;
        }

        public async Task<List<Todo>> GetByCategorize(Categorize categorize)
        {
            var todos = await context.Todos.Where(t => t.Categorize == categorize).ToListAsync();
            if (todos.Count == 0)
            {
                throw new NotFoundException("No todos found with the specified categorize");
            }
            return todos;
        }

        public async Task<List<Todo>> GetByPrioroty(PriorityLevel priority)
        {
            var todos = await context.Todos.Where(t => t.Priority == priority).ToListAsync();
            if (todos.Count == 0)
            {
                throw new NotFoundException("No todos found with the specified priority");
            }
            return todos;
        }

        public async Task<Todo> GetbyTitle(string title)
        {
            var todo = await context.Todos.FirstOrDefaultAsync(t => t.Title == title);
            if (todo == null)
            {
                throw new NotFoundException("Todo not found");
            }
            return todo;
        }

        public async Task<Todo> GetTodoById(int id)
        {
            var to = await context.Todos.FindAsync(id);
            if (to == null)
            {
                throw new NotFoundException("dont have ");
            }
            return to;
        }

        public Task<List<Todo>> SearchTodos(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                throw new NotFoundException("Keyword cannot be null or empty");
            }
            string lowerKeyword = keyword.ToLower().Trim();
            var todos = context.Todos.Where(t => t.Title.Contains(lowerKeyword) || t.Description.Contains(lowerKeyword)).ToListAsync();
            if(todos == null || todos.Result.Count == 0)
            {
                throw new NotFoundException("No todos found matching the keyword");
            }
            return todos;


        }

        public async Task UpdateTodo(int id, Todo todo)
        {
            var existingTodo = await context.Todos.FindAsync(id);
            if (existingTodo != null)
            {
                existingTodo.Title = todo.Title;
                existingTodo.Description = todo.Description;
                existingTodo.Categorize = todo.Categorize;
                existingTodo.Priority = todo.Priority;
                await context.SaveChangesAsync();
            }
        }

    }
}
