using TodoApp.Shared.Services.CategoryService;

namespace TodoApp.Shared.Models;

public record CategoryDto(int Id, string Name, bool IsActive=true, string Description="");

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;

    public List<TodoItem> Items { get; set; }

    private Category()
    {
        
    }

    public Category(CategoryDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        IsActive = dto.IsActive;
        Description = dto.Description;

    }

    public void Update(CategoryDto dto)
    {
        Name = dto.Name;
        IsActive = dto.IsActive;
        Description += dto.Description;
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
