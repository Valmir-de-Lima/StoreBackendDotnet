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

        // É necessário ignorar a propriedade Notifications para nao ser mapeada
        builder.Ignore(x => x.Notifications);

        // Chave Primária
        builder.HasKey(x => x.Id);

        // Propriedades
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.OwnsOne(x => x.Email)
           .Property(x => x.Address)
           .HasColumnName("Email")
           .IsRequired(true);

        // É necessário ignorar a propriedade Notifications de Email para nao ser mapeada
        builder.OwnsOne(x => x.Email)
            .Ignore(x => x.Notifications);

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasColumnName("PasswordHash")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.RecoveryPasswordHash)
            .IsRequired()
            .HasColumnName("RecoveryPasswordHash")
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