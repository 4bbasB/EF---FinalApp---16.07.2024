using LibraryManagmentApplication.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagmentApplication.Core.Configurations;

public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.HasOne(x => x.Book).WithMany(x => x.BookAuthors);
        builder.HasOne(x => x.Author).WithMany(x => x.BookAuthors);
    }
}
