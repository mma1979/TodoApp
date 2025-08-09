using TodoApp.Shared.Models;

namespace TodoApp.Shared.Services.CategoryService;


public interface ITodoListService
{
    List<TodoItem> GetAll();
    List<TodoItem> GetAll(int categoryId);
    TodoItem? GetById(int category, int id);
    TodoItem Add(TodoItemDto item);
    TodoItem Update(TodoItemDto item);
    void UpdateStat(int id, TodoItemStatus status);
}
public partial class CategoryService: ITodoListService
{
    public List<TodoItem> GetAll()
    {
        return new List<TodoItem>
       {
           new TodoItem(new TodoItemDto(1, "Item 1", "", 1)),
           new TodoItem(new TodoItemDto(2, "Item 2", "", 1)),
           new TodoItem(new TodoItemDto(3, "Item 3", "", 2)),
           new TodoItem(new TodoItemDto(4, "Item 4", "", 2)),
           new TodoItem(new TodoItemDto(5, "Item 5", "", 3)),
           new TodoItem(new TodoItemDto(6, "Item 6", "", 3))
       };
    }

    public List<TodoItem> GetAll(int categoryId)
    {
        return GetAll().Where(c=>c.CategoryId == categoryId).ToList();
    }

    public TodoItem? GetById(int category, int id)
    {
        return GetAll(category).FirstOrDefault(i=>i.Id==id);
    }

    public TodoItem Add(TodoItemDto item)
    {
        return new TodoItem(item);
    }

    public TodoItem Update(TodoItemDto item)
    {
        var current = GetById(item.CategoryId, item.Id);
        current?.Update(item);

        return current;
    }

    public void UpdateStat(int id, TodoItemStatus status)
    {

        var current = GetAll().FirstOrDefault(i=>i.Id==id);
        current?.ChangeStatus(status);
    }
}
