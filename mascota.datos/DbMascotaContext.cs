using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using mascota.entidades;

#nullable disable

namespace mascota.datos
{
    public partial class DbMascotaContext : DbContext
    {
        public DbMascotaContext()
        {
        }

        public DbMascotaContext(DbContextOptions<DbMascotaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mascota> Mascota { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(e => e.IdMascota);

                entity.ToTable("mascota");

                entity.Property(e => e.IdMascota).HasColumnName("id_mascota");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
