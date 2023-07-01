using webapi.Models;
namespace webapi.Services;

public class TaskService : ITaskService
{
    TareasContext context;

    public TaskService(TareasContext dbcontext)
    {
        context = dbcontext;
        context.Database.EnsureCreated();
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }
    
    public async Task Add(Tarea task)
    {
            context.Tareas.Add(task);
            await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea task)
    {
        var currentTask = context.Tareas.Find(id);
        if(currentTask != null)
        {
            currentTask.CategoriaId = task.CategoriaId;
            currentTask.Titulo = task.Titulo;
            currentTask.Descripcion = task.Descripcion;
            currentTask.PrioridadTarea = task.PrioridadTarea;
            currentTask.FechaCreacion = task.FechaCreacion;

            await context.SaveChangesAsync();
        }            
    }

    public async Task Delete(Guid id)
    {
        var currentTask = context.Tareas.Find(id);
        if(currentTask != null)
        {
            context.Tareas.Remove(currentTask);
            await context.SaveChangesAsync();
        }            
    }
}

public interface ITaskService
{
    IEnumerable<Tarea> Get();
    Task Add(Tarea category);
    Task Update(Guid id, Tarea category);
    Task Delete(Guid id);
}