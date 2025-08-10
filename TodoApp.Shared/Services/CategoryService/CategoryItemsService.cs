using TodoApp.Shared.Data;
using TodoApp.Shared.Models;

namespace TodoApp.Shared.Services.CategoryService;


public interface ITodoListService
{
    List<TodoItem> GetAll();
    List<TodoItem> GetAll(int categoryId);
    TodoItem? GetById(int category, int id);
    TodoItem Add(TodoItemDto item);
    TodoItem Update(int id, TodoItemDto item);
    bool UpdateStat(int id, TodoItemStatus status);
}
public partial class CategoryService: ITodoListService
{
    
    public List<TodoItem> GetAll()
    {
        return _context.TodoItems.ToList();
    }

    public List<TodoItem> GetAll(int categoryId)
    {
        return _context.TodoItems
            .Where(c=>c.CategoryId == categoryId).ToList();
    }

    public TodoItem? GetById(int categoryId, int id)
    {
         return _context.TodoItems
            .FirstOrDefault(c => c.CategoryId == categoryId && c.Id == id);
    }

    public TodoItem Add(TodoItemDto item)
    {
        var newTodo = new TodoItem(item);
        var savedItem = _context.TodoItems.Add(newTodo);
        _context.SaveChanges();
        return savedItem.Entity;
    }

    public TodoItem Update(int id, TodoItemDto item)
    {
        var current = _context.TodoItems
            .FirstOrDefault(e=>e.Id == id);
        current?.Update(item);

        _context.SaveChanges();

        return current;
    }

    public bool UpdateStat(int id, TodoItemStatus status)
    {

        var current = _context.TodoItems
            .FirstOrDefault(e => e.Id == id);
        current?.ChangeStatus(status);


        return _context.SaveChanges() > 0;
    }
}
