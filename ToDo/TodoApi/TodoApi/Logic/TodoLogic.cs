using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Logic
{
    public class TodoLogic
    {
        private readonly AppDbContext _context;

        public TodoLogic(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetTodosAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<TodoItem?> GetTodoByIdAsync(Guid id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<TodoItem> CreateTodoAsync(TodoItem todo)
        {
            todo.Id = Guid.NewGuid(); 
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> UpdateTodoAsync(Guid id, TodoItem updatedTodo)
        {
            var existingTodo = await _context.Todos.FindAsync(id);
            if (existingTodo == null) 
            {
                return false;
            }

            existingTodo.Title = updatedTodo.Title;
            existingTodo.Completed = updatedTodo.Completed;

            await _context.SaveChangesAsync(); 
            return true;
        }


        public async Task<bool> DeleteTodoAsync(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) 
            {
                return false;
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync(); 
            return true;
        }


    }
}
