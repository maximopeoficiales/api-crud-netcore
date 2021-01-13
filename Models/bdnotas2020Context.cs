using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiTest.Models
{
    public partial class bdnotas2020Context : DbContext
    {
        public bdnotas2020Context()
        {
        }

        public bdnotas2020Context(DbContextOptions<bdnotas2020Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Notas> Notas { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=bdnotas2020;uid=sa;password=yourStrong(!)Password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.Codalumno);

                entity.ToTable("ALUMNOS");

                entity.Property(e => e.Codalumno)
                    .HasColumnName("codalumno")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Apealumno)
                    .IsRequired()
                    .HasColumnName("apealumno")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Codesp)
                    .IsRequired()
                    .HasColumnName("codesp")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Colegio)
                    .HasColumnName("colegio")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Sin Nombre')");

                entity.Property(e => e.Eliminado)
                    .HasColumnName("eliminado")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No')");

                entity.Property(e => e.Nomalumno)
                    .IsRequired()
                    .HasColumnName("nomalumno")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodespNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.Codesp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ALUMNOS__codesp__38996AB5");
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.Codcurso);

                entity.ToTable("CURSOS");

                entity.Property(e => e.Codcurso)
                    .HasColumnName("codcurso")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Eliminado)
                    .HasColumnName("eliminado")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No')");

                entity.Property(e => e.Nhoras).HasColumnName("nhoras");

                entity.Property(e => e.Nomcurso)
                    .IsRequired()
                    .HasColumnName("nomcurso")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('P')");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Coddesp);

                entity.ToTable("ESPECIALIDAD");

                entity.Property(e => e.Coddesp)
                    .HasColumnName("coddesp")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.Nomesp)
                    .IsRequired()
                    .HasColumnName("nomesp")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Notas>(entity =>
            {
                entity.HasKey(e => e.Nroreg);

                entity.ToTable("NOTAS");

                entity.HasIndex(e => new { e.Codalumno, e.Codcurso, e.Semestre })
                    .HasName("unique_Notas")
                    .IsUnique();

                entity.Property(e => e.Nroreg).HasColumnName("nroreg");

                entity.Property(e => e.Codalumno)
                    .IsRequired()
                    .HasColumnName("codalumno")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Codcurso)
                    .IsRequired()
                    .HasColumnName("codcurso")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Eliminado)
                    .HasColumnName("eliminado")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No')");

                entity.Property(e => e.Nfinal).HasColumnName("nfinal");

                entity.Property(e => e.Nparcial).HasColumnName("nparcial");

                entity.Property(e => e.Ntrabajo).HasColumnName("ntrabajo");

                entity.Property(e => e.Semestre)
                    .IsRequired()
                    .HasColumnName("semestre")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodalumnoNavigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.Codalumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NOTAS__codalumno__46E78A0C");

                entity.HasOne(d => d.CodcursoNavigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.Codcurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NOTAS__codcurso__47DBAE45");
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.HasKey(e => e.Codpago);

                entity.ToTable("PAGOS");

                entity.HasIndex(e => new { e.Codalumno, e.Semestre, e.Ncuota })
                    .HasName("unique_Pagos")
                    .IsUnique();

                entity.Property(e => e.Codpago).HasColumnName("codpago");

                entity.Property(e => e.Codalumno)
                    .IsRequired()
                    .HasColumnName("codalumno")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Ncuota).HasColumnName("ncuota");

                entity.Property(e => e.Pagado)
                    .HasColumnName("pagado")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No')");

                entity.Property(e => e.Semestre)
                    .IsRequired()
                    .HasColumnName("semestre")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodalumnoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.Codalumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PAGOS__codalumno__3E52440B");
            });
        }
    }
}
