using FIAP.FCG.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.FCG.Infrastructure.Repository.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("User");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnType("bigint")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Password)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.AccessLevel)
        .HasConversion<int>();

        builder.HasData(
            new UserEntity
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Name = "Admin",
                Email = "admin@fiap.com.br",
                Password = "4Dm1n@Fiap",
                AccessLevel = Domain.Enums.User.AccessLevelEnum.ADMIN
            });
    }
}
