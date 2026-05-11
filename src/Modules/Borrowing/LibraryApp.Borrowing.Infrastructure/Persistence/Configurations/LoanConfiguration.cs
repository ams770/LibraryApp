using LibraryApp.Borrowing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Borrowing.Infrastructure.Persistence.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.BookId)
            .IsRequired();
        builder.Property(a => a.MemberId)
            .IsRequired();
        builder.Property(a => a.BorrowedAt)
            .IsRequired();
        builder.Property(a => a.ReturnedAt)
            .IsRequired();
        builder.Property(a => a.DueDate)
            .IsRequired();
        builder.Property(a => a.Status)
            .IsRequired();
    }
}