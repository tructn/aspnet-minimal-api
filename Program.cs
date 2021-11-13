using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("bookstore") ?? "Data Source=bookstore.db";
builder.Services.AddSqlite<BookStoreDB>(connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/books", async (BookStoreDB dbContext) => Results.Ok(await dbContext.Books.AsNoTracking().ToListAsync()));

app.MapGet("/books/{id}", async (int id, BookStoreDB dbContext) => Results.Ok(await dbContext.Books.FirstOrDefaultAsync(b => b.ID == id)));

app.MapPost("/books", async (BookStoreDB dbContext, Book model) =>
{
    dbContext.Books.Add(model);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapDelete("/books/{id}", async (int id, BookStoreDB dbContext) =>
{
    var book = await dbContext.Books.FirstOrDefaultAsync(b => b.ID == id);
    if (book == null)
    {
        return Results.BadRequest();
    }
    dbContext.Books.Remove(book);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/books/{id}", async (int id, Book model, BookStoreDB dbContext) =>
{
    var book = await dbContext.Books.FirstOrDefaultAsync(b => b.ID == id);
    if (book == null)
    {
        return Results.BadRequest();
    }
    book.Title = model.Title;
    book.ISBN = model.ISBN;
    book.Author = model.Author;
    book.Price = model.Price;
    dbContext.Books.Update(book);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.Run();