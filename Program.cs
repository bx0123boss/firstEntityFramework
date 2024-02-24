using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
//builder.Services.AddDbContext<TareasContext>(options => options.UseJet("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\platzi\\Database1.accdb"));

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Select
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    //return Results.Ok(dbContext.Tareas.Where(p=>p.PrioridadTarea == Prioridad.Media));
    //return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == Prioridad.Baja));
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
});


//Insert
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

//Update
app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);
    if (tareaActual != null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Desrcripcion = tarea.Desrcripcion;

        await dbContext.SaveChangesAsync();
        return Results.Ok();

    }
    return Results.NotFound();
});

//Delete
app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);
    if (tareaActual != null)
    {
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});
app.Run();
