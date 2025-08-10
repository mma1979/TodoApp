using TodoApp.Shared.Data;
using TodoApp.Shared.Models;

namespace TodoApp.Shared.Services.CategoryService;

public interface ICategoryService
{
    List<Category> GetCategories();
    Category? GetCategory(int id);
    Category Add(CategoryDto dto);
    Category? Update(int id, CategoryDto dto);
}

public partial class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;
   

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public List<Category> GetCategories()
    {


        return _context.Categories.ToList();
    }

    public Category? GetCategory(int id)
    {
       return _context.Categories
            .FirstOrDefault(c=>c.Id==id);
    }

    public Category Add(CategoryDto dto)
    {
        var category = new Category(dto);
        
        var savedCategory = _context.Categories.Add(category);
        _context.SaveChanges();

        return savedCategory.Entity;

        
    }

    public Category? Update(int id, CategoryDto dto)
    {
        var current = _context.Categories
        .FirstOrDefault(c=>c.Id==id);
        
        current?.Update(dto);

        _context.SaveChanges();

        return current;
    }
}
