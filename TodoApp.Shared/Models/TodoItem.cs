namespace TodoApp.Shared.Models;

public record TodoItemDto(int Id, string Title, string Description, int CategoryId, TodoItemStatus Status = TodoItemStatus.New);

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public TodoItemStatus Status { get; set; }

    public Category Category { get; set; }
    public int CategoryId { get; set; }

    private TodoItem()
    {
        
    }

    public TodoItem(TodoItemDto dto)
    {
        Id = dto.Id;
        Title = dto.Title;
        Description = dto.Description;
        Status = dto.Status;
        CategoryId = dto.CategoryId;

        CreatedDate = DateTime.Now;
    }

    public void Update(TodoItemDto dto)
    {
        Title = dto.Title;
        Description = dto.Description;
        Status = dto.Status;
        CategoryId = dto.CategoryId;

        UpdatedDate = DateTime.Now;

    }

    public void ChangeStatus(TodoItemStatus status)
    {
        Status = status;
        UpdatedDate = DateTime.Now;
    }
}
