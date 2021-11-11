using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCoreDab2.Models
{
    public partial class au653289Context : DbContext
    {
        public au653289Context()
        {
        }

        public au653289Context(DbContextOptions<au653289Context> options)
            : base(options)
        {
        }

        private string _optionsString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_optionsString);
            
        }

        public au653289Context(string server, string database, string user, string password)
        {
            _optionsString = $"Server={server};Database={database};User ID={user};Password={password}";
        }

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomProperty> RoomProperties { get; set; }
        public virtual DbSet<RoomReservation> RoomReservations { get; set; }
        public virtual DbSet<Society> Societies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Cpr).HasColumnName("cpr");

                entity.Property(e => e.IsChairman)
                    .HasColumnName("isChairman")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.SocietyId).HasColumnName("societyId");

                entity.HasOne(d => d.Society)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.SocietyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__member__societyI__2EDAF651");
            });

            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.ToTable("municipality");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cvr).HasColumnName("cvr");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Access)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("access");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Limit)
                    .HasColumnName("limit")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.MunicipalityId).HasColumnName("municipalityId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.MunicipalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__room__municipali__32AB8735");
            });

            modelBuilder.Entity<RoomProperty>(entity =>
            {
                entity.ToTable("room_property");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.RoomId).HasColumnName("roomId");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomProperties)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__room_prop__roomI__367C1819");
            });

            modelBuilder.Entity<RoomReservation>(entity =>
            {
                entity.ToTable("room_reservation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("endTime");

                entity.Property(e => e.MemberId).HasColumnName("memberId");

                entity.Property(e => e.RoomId).HasColumnName("roomId");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.RoomReservations)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__room_rese__membe__3A4CA8FD");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomReservations)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__room_rese__roomI__395884C4");
            });

            modelBuilder.Entity<Society>(entity =>
            {
                entity.ToTable("society");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("activity");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Cvr).HasColumnName("cvr");

                entity.Property(e => e.MunicipalityId).HasColumnName("municipalityId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Societies)
                    .HasForeignKey(d => d.MunicipalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__society__municip__2BFE89A6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
