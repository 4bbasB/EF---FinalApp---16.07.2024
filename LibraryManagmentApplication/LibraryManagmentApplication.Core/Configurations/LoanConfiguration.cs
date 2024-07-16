using LibraryManagmentApplication.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagmentApplication.Core.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.Property(x => x.LoanDate)
            .IsRequired()
            .HasColumnType("DateTime");

        builder.Property(x => x.MustReturnDate)
            .IsRequired()
            .HasColumnType("DateTime");

        builder.Property(x => x.ReturnDate)
            .IsRequired()
            .HasColumnType("DateTime");
    }
}
