using Frota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frota.Repository.Configuration
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Chassi).IsRequired().HasMaxLength(20);

            builder.Property(u => u.NumeroPassageiro).IsRequired();

            builder.Property(u => u.Tipo).IsRequired();

            builder.Property(u => u.Cor).IsRequired().HasMaxLength(50);
        }
    }
}
