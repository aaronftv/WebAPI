using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Console.WriteLine("Connection String: " + builder.Configuration.GetConnectionString("cnTasksDb"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTasksDb"));
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService());
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITaskService, TaskService>();
//builder.Services.AddScoped<ICategoryService>(p => new CategoryService());
//builder.Services.AddScoped<ITaskService>(p => new TaskService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Custom Middlewares go between Authorization and Map
//This middleware is to configure security
//app.UseCors();

//For some reason this started overriding Controller calls when active
//TODO: investigate why that is happening
//app.UseWelcomePage();

//Custom middleware
app.UseTimeMiddleware();

app.MapControllers();

app.Run();
