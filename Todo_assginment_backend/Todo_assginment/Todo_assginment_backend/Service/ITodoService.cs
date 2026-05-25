using Todo_assginment.Models;

namespace Todo_assginment.Service
{
    public interface ITodoService
    {
        public Task<Todo> GetbyTitle(string title);

        public Task<List<Todo>> GetByCategorize(Categorize categorize);

        public Task<List<Todo>> GetByPrioroty(PriorityLevel priority);
        public Task<List<Todo>> GetAllTodos();
        Task<List<Todo>> SearchTodos(string keyword);

        public Task<Todo> GetTodoById(int id);

        public Task<Todo> CreateTodo(Todo todo);
        public Task UpdateTodo(int id, Todo todo);

        public Task DeleteTodo(int id);


    }
}
