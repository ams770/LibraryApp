using LibraryApp.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Catalog.Infrastructure.Persistence.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.Navigation(a => a.Books)
            .HasField("_books")
            .UsePropertyAccessMode(PropertyAccessMode.Field);


        builder.Property(a => a.FullName)
            .IsRequired()
            .HasMaxLength(120);
    }
}