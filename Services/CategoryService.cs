using webapi.Models;
namespace webapi.Services;

public class CategoryService : ICategoryService
{
    TareasContext context;

    public CategoryService(TareasContext dbcontext)
    {
        context = dbcontext;
        context.Database.EnsureCreated();
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public async Task Add(Categoria category)
    {
            context.Categorias.Add(category);
            await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categoria category)
    {
        var currentCategory = context.Categorias.Find(id);
        if(currentCategory != null)
        {
            currentCategory.Nombre = category.Nombre;
            currentCategory.Descripcion = category.Descripcion;
            currentCategory.Peso = category.Peso;
            await context.SaveChangesAsync();
        }            
    }

    public async Task Delete(Guid id)
    {
        var currentCategory = context.Categorias.Find(id);
        if(currentCategory != null)
        {
            context.Categorias.Remove(currentCategory);
            await context.SaveChangesAsync();
        }            
    }
}

public interface ICategoryService
{
    IEnumerable<Categoria> Get();
    Task Add(Categoria category);
    Task Update(Guid id, Categoria category);
    Task Delete(Guid id);
}