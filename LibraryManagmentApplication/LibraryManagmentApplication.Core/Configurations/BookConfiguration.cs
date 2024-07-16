using LibraryManagmentApplication.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentApplication.Core.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(600);

        builder.Property(x => x.PublishedYear)
            .IsRequired()
            .HasColumnType("INT");


        builder.HasOne(x => x.Borrower)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.BorrowerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}