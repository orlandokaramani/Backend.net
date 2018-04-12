
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
       public virtual DbSet<Bashkia> Bashkia { get; set; }
        public virtual DbSet<Njesia> Njesia { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Qarku> Qarku { get; set; }
        public virtual DbSet<Qv> Qv { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Values> Values { get; set; }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Bashkia>(entity =>
            {
                entity.Property(e => e.Bashkia1)
                    .IsRequired()
                    .HasColumnName("Bashkia")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdQarkuNavigation)
                    .WithMany(p => p.Bashkia)
                    .HasForeignKey(d => d.IdQarku)
                    .HasConstraintName("FK_Bashkia_Qarku");
            });

            modelBuilder.Entity<Njesia>(entity =>
            {
                entity.Property(e => e.Njesia1)
                    .HasColumnName("Njesia")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdBashkiaNavigation)
                    .WithMany(p => p.Njesia)
                    .HasForeignKey(d => d.IdBashkia)
                    .HasConstraintName("FK_Njesia_Bashkia");
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Qarku>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Qarku1)
                    .IsRequired()
                    .HasColumnName("Qarku")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Qv>(entity =>
            {
                entity.ToTable("QV");

                entity.Property(e => e.Qv1)
                    .HasColumnName("Qv")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdnjaNavigation)
                    .WithMany(p => p.Qv)
                    .HasForeignKey(d => d.Idnja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QV_Njesia");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Datelindja).HasDefaultValueSql("('0001-01-01T00:00:00.000')");

                entity.Property(e => e.IdNjesia).HasColumnName("idNjesia");

                entity.Property(e => e.IdQv).HasColumnName("idQv");

                entity.Property(e => e.LastActive).HasDefaultValueSql("('0001-01-01T00:00:00.000')");

                entity.HasOne(d => d.IdBashkiaNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdBashkia)
                    .HasConstraintName("FK_Users_Bashkia");

                entity.HasOne(d => d.IdNjesiaNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdNjesia)
                    .HasConstraintName("FK_Users_Njesia");

                entity.HasOne(d => d.IdQarkuNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdQarku)
                    .HasConstraintName("FK_Users_Qarku");

                entity.HasOne(d => d.IdQvNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdQv)
                    .HasConstraintName("FK_Users_QV");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_Roles");
            });

            modelBuilder.Entity<Values>(entity =>
            {
                entity.Property(e => e.Values1).HasColumnName("Values");
            });
        }
        }
    }
