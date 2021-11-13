using Microsoft.EntityFrameworkCore;

internal class BookStoreDB : DbContext
{
    public BookStoreDB(DbContextOptions<BookStoreDB> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}