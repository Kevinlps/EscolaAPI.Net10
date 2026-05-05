using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.EntitiesConfiguration
{
    public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(m => m.Descricao)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(m => m.CursoId)
                .IsRequired();

            builder.HasOne(t => t.Curso)
                .WithMany(c => c.Turmas)
                .HasForeignKey(t => t.CursoId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
