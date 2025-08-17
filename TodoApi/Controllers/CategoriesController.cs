using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApp.Shared.Data;
using TodoApp.Shared.Models;
using TodoApp.Shared.Services.CategoryService;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        try
        {
            var categories = _categoryService.GetCategories();
            var result = new ResultViewModel<List<Category>>
            {
                IsSuccess = true,
                Message = "Success",
                Data = categories
            };
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new ResultViewModel<List<Category>>
            {
                IsSuccess = false,
                Message = ex.Message
            });
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        try
        {
            var category = _categoryService.GetCategory(id);
            var result = new ResultViewModel<Category>
            {
                IsSuccess = category != null,
                Message = category != null ? "Success" : "Category not found",
                Data = category
            };
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
        catch (Exception e)
        {
            return BadRequest(new ResultViewModel<Category>
            {
                IsSuccess = false,
                Message = e.Message
            });
        }
    }

    [HttpPost]
    public IActionResult PostCategory([FromBody] CategoryDto model)
    {
        try
        {
            var insertedCategory = _categoryService.Add(model);
            if (insertedCategory != null)
            {
                return Ok(new ResultViewModel<Category>
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = insertedCategory
                });
            }

            return BadRequest(new ResultViewModel<Category>
            {
                IsSuccess = false,
                Message = "Category not inserted"
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ResultViewModel<Category>
            {
                IsSuccess = false,
                Message = e.Message
            });
        }
    }

    [HttpPut("{id}")]
    public IActionResult PutCategory([FromRoute] int id, [FromBody] CategoryDto model)
    {
        if (id == default)
        {
            return BadRequest(new ResultViewModel<Category>
            {
                IsSuccess = false,
                Message = "Category id is required"
            });
        }

        try
        {
            var updatedCategory = _categoryService.Update(id, model);
            if (updatedCategory != null)
            {
                return Ok(new ResultViewModel<Category>
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = updatedCategory
                });
            }

            return BadRequest(new ResultViewModel<Category>
            {
                IsSuccess = false,
                Message = "Category not updated"
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ResultViewModel<Category>
            {
                IsSuccess = false,
                Message = e.Message
            });
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteCategory([FromRoute] int id)
    {
        if (id == default)
        {
            return BadRequest(new ResultViewModel<Category>
            {
                IsSuccess = false,
                Message = "Category id is required"
            });
        }

        try
        {
            var updatedCategory = _categoryService.Delete(id);
            if (updatedCategory != null)
            {
                return Ok(new ResultViewModel<Category>
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = updatedCategory
                });
            }

            return BadRequest(new ResultViewModel<Category>
            {
                IsSuccess = false,
                Message = "Category not delete"
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ResultViewModel<Category>
            {
                IsSuccess = false,
                Message = e.Message
            });
        }
    }
}