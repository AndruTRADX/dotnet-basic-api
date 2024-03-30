namespace apidotnet.Services;

public class TasksService(TasksContext tasksContext) : ITasksService
{
    readonly TasksContext dbContext = tasksContext;

    public IEnumerable<Models.Task> Get()
    {
        return dbContext.Tasks;
    }

    public async void Save(Models.Task task)
    {
        await dbContext.AddAsync(task);
        await dbContext.SaveChangesAsync();
    }

    public async void Update(Guid id, Models.Task task)
    {
        var currentTask = await dbContext.Tasks.FindAsync(id);

        if (currentTask != null)
        {
            currentTask.Title = task.Title;
            currentTask.Description = task.Description;

            await dbContext.SaveChangesAsync();
        }
    }

    public async void Delete(Guid id)
    {
        var currentTask = await dbContext.Tasks.FindAsync(id);

        if (currentTask != null)
        {
            dbContext.Remove(currentTask);
            await dbContext.SaveChangesAsync();
        }
    }
}

public interface ITasksService
{
    IEnumerable<Models.Task> Get();
    void Save(Models.Task task);
    void Update(Guid id, Models.Task task);
    void Delete(Guid id);
}