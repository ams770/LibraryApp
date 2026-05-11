using LibraryApp.Members.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Members.Infrastructure.Persistence.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.FullName)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(item => item.Email)
            .HasMaxLength(256)
            .IsRequired();
    }
}