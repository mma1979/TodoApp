using TodoApp.Shared.Services.CategoryService;

namespace TodoApp.Shared.Models;

public record CategoryDto(string Name, bool IsActive=true, string Description="");

public class Category
{
    private readonly List<string> _prohobitedCategores = ["sex", "not", "class"];

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsActive { get; private set; } = true;

    public List<TodoItem> Items { get; private set; }

    private Category()
    {
        
    }

    public Category(CategoryDto dto)
    {
        if (string.IsNullOrEmpty(dto.Name) || _prohobitedCategores.IndexOf(dto.Name) >= 0)
        {
            throw new ArgumentException("Cateory name is invalid");
        }
        
        Name = dto.Name;
        IsActive = dto.IsActive;
        Description = dto.Description;

    }

    public void Update(CategoryDto dto)
    {
        if (string.IsNullOrEmpty(dto.Name) || _prohobitedCategores.IndexOf(dto.Name) >= 0)
        {
            throw new ArgumentException("Cateory name is invalid");
        }

        Name = dto.Name;
        IsActive = dto.IsActive;
        Description = dto.Description;
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
