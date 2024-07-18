using System;
using System.Collections.Generic;
using DoubleVPartnersRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace DoubleVPartnersRepository.ContextDB;

public partial class DoubleVPartnersDB : DbContext
{
    public DoubleVPartnersDB()
    {
    }

    public DoubleVPartnersDB(DbContextOptions<DoubleVPartnersDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK__Personas__F2374EB1E6144A19");

            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.NombresApellidosConcatenados)
                .HasMaxLength(101)
                .HasComputedColumnSql("(([Nombres]+' ')+[Apellidos])", true);
            entity.Property(e => e.NumeroIdentificacion).HasMaxLength(20);
            entity.Property(e => e.NumeroIdentificacionConcatenado)
                .HasMaxLength(41)
                .HasComputedColumnSql("(([TipoIdentificacion]+' ')+[NumeroIdentificacion])", true);
            entity.Property(e => e.TipoIdentificacion).HasMaxLength(20);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Personas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Personas__Usuari__66603565");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK__Usuario__F2374EB1AC599DF2");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Usuario1, "UQ__Usuario__E3237CF73DE59071").IsUnique();

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Pass).HasMaxLength(200);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .HasColumnName("Usuario");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
