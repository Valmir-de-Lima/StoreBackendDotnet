using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Tabela
        builder.ToTable("User");

        // Chave Primária
        builder.HasKey(x => x.Id);

        // Propriedades
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Email.Address)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);

        builder.Property(x => x.PasswordHash).IsRequired()
            .HasColumnName("PasswordHash")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.Link)
            .IsRequired()
            .HasColumnName("Link")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Type)
            .IsRequired()
            .HasColumnName("Type")
            .HasColumnType("INTEGER");

        // Índices
        builder
            .HasIndex(x => x.Link, "IX_User_Link")
            .IsUnique();

    }
}