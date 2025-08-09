using TodoApp.Shared.Models;

namespace TodoApp.Shared.Services.CategoryService;

public interface ICategoryService
{
    List<CategoryReadModel> GetCategories();
    CategoryReadModel? GetCategory(int id);
    CategoryReadModel Add(CategoryDto dto);
    CategoryReadModel? Update(CategoryDto dto);
}

public partial class CategoryService : ICategoryService
{
    public List<CategoryReadModel> GetCategories()
    {

      
        return new List<Category>()
        {
            new(new(1, "Personal")),
            new Category(new CategoryDto(2, "Work")),
            new Category(new CategoryDto(3, "Other"))
        }.Select(c=>c.ToReadModel()).ToList();
    }

    public CategoryReadModel? GetCategory(int id)
    {
       return GetCategories()
            .FirstOrDefault(c=>c.Id==id);
    }

    public CategoryReadModel Add(CategoryDto dto)
    {
       
        // database logic
        return new Category(dto).ToReadModel();
    }

    public CategoryReadModel? Update(CategoryDto dto)
    {
        var current = GetCategories()
        .FirstOrDefault(c=>c.Id==dto.Id);

        //current?.Update(dto);

        return current;
    }
}
