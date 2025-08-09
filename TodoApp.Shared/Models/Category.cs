using TodoApp.Shared.Services.CategoryService;

namespace TodoApp.Shared.Models;

public record CategoryDto(int Id, string Name, bool IsActive=true);

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;

    public List<TodoItem> Items { get; set; }

    public Category(CategoryDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        IsActive = dto.IsActive;

    }

    public void Update(CategoryDto dto)
    {
        Name = dto.Name;
        IsActive = dto.IsActive;

    }

    public CategoryReadModel ToReadModel()
    {
        return new CategoryReadModel
        {
            Id = Id,
            Name = Name,
            IsActive = IsActive
        };
    }


}
