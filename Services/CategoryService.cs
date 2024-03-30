using apidotnet.Models;

namespace apidotnet.Services;

public class CategoryService(TasksContext tasksContext) : ICategoryService
{
    readonly TasksContext dbContext = tasksContext;

    public IEnumerable<Category> Get()
    {
        return dbContext.Categories;
    }

    public async void Save(Category category)
    {
        await dbContext.AddAsync(category);
        await dbContext.SaveChangesAsync();
    }

    public async void Update(Guid id, Category category)
    {
        var currentCategory = await dbContext.Categories.FindAsync(id);

        if (currentCategory != null)
        {
            currentCategory.Name = category.Name;
            currentCategory.Description = category.Description;
            currentCategory.Weight = category.Weight;

            await dbContext.SaveChangesAsync();
        }
    }

    public async void Delete(Guid id)
    {
        var currentCategory = await dbContext.Categories.FindAsync(id);

        if (currentCategory != null)
        {
            dbContext.Remove(currentCategory);
            await dbContext.SaveChangesAsync();
        }
    }
}

public interface ICategoryService
{
    IEnumerable<Category> Get();
    void Save(Category category);
    void Update(Guid id, Category category);
    void Delete(Guid id);
}