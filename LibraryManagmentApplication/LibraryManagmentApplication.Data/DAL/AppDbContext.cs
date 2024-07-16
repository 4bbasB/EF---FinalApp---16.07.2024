using LibraryManagmentApplication.Core.Configurations;
using LibraryManagmentApplication.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentApplication.Data.DAL;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Borrower> Borrowers { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<LoanItem> LoanItems { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=ABBAS\\SQLEXPRESS;Database=LibraryManagmentDB;Trusted_Connection=True;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }
}
