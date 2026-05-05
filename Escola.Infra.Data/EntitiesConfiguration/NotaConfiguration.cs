using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.EntitiesConfiguration
{
    public class NotaConfiguration : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.ValorNota)
                .IsRequired();
            builder.Property(m => m.MatriculaId)
                .IsRequired();

            builder.HasOne(m => m.Matricula)
                .WithMany(m => m.Notas)
                .HasForeignKey(m => m.MatriculaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
