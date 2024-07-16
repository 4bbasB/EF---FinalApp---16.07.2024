using LibraryManagmentApplication.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentApplication.Core.Configurations;

public class LoanItemConfiguration : IEntityTypeConfiguration<LoanItem>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LoanItem> builder)
    {
        builder.HasOne(x => x.Book).WithMany(x => x.LoanItems);
        builder.HasOne(x => x.Loan).WithMany(x => x.LoanItems);
    }
}
