using System;
using System.Collections.Generic;
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

        private string _optionsString = Environment.GetEnvironmentVariable("DATABASE");

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
        public virtual DbSet<Access> Access { get; set; }

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
                
                entity.HasData(new Member
                {
                    Id = 1, SocietyId = 1, IsChairman = true, Name = "Mark Marsvin",
                    Cpr = 0105882521, Address = "Dyrevej 25"
                });
                entity.HasData(new Member
                {
                    Id = 2, SocietyId = 2, IsChairman = true, Name = "Lasse Hyldahl", 
                    Cpr = 0108002352, Address = "Aldersrovej 26"
                });
                entity.HasData(new Member
                {
                    Id = 3, SocietyId = 1, IsChairman = false, Name = "Gurli gris",
                    Cpr = 2102772423, Address = "Park Allé 24"
                });
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
                
                entity.HasData(new Municipality
                {
                    Id = 1, Name = "Magnus kommune", Cvr = 42200011
                });
                entity.HasData(new Municipality
                {
                    Id = 2, Name = "Lasses kommune", Cvr = 42200019
                });
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
                
                entity.HasData(new Room
                {
                    Id = 1, Limit = 20, MunicipalityId = 1, Name = "Mødelokale",
                    Address = "Rumallé 1", Access = "Brækjern"
                });
                entity.HasData(new Room
                {
                    Id = 2, Limit = 3, MunicipalityId = 1, Name = "Toilet",
                    Address = "Rumallé 1", Access = "Åbent"
                });
                entity.HasData(new Room
                {
                    Id = 3, Limit = -1, MunicipalityId = 2, Name = "Sportshal",
                    Address = "Motionsvej 24", Access = "2426"
                });
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

                entity.HasData(new RoomProperty
                {
                    Id = 1, RoomId = 1, Name = "WiFi"
                });
                entity.HasData(new RoomProperty
                {
                    Id = 2, RoomId = 1, Name = "Projektor"
                });
                entity.HasData(new RoomProperty
                {
                    Id = 3, RoomId = 1, Name = "10 Stole"
                });
                entity.HasData(new RoomProperty
                {
                    Id = 4, RoomId = 2, Name = "Toilet"
                });
                entity.HasData(new RoomProperty
                {
                    Id = 5, RoomId = 2, Name = "Håndvask"
                });
                entity.HasData(new RoomProperty
                {
                    Id = 6, RoomId = 3, Name = "Fodboldmål"
                });
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

                entity.HasData(new RoomReservation
                {
                    Id = 1, RoomId = 1, MemberId = 3, 
                    StartTime = new DateTime(2021, 09, 22, 16, 0, 0, 0),
                    EndTime = new DateTime(2021, 09, 22, 20, 0, 0, 0)
                });
                entity.HasData(new RoomReservation
                {
                    Id = 2, RoomId = 2, MemberId = 2,
                    StartTime = new DateTime(2021, 09, 21, 10, 0, 0, 0),
                    EndTime = new DateTime(2021, 09, 21, 12, 0, 0, 0)
                });
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

                entity.HasData(new Society
                {
                    Id = 1, Name = "Pet society", MunicipalityId = 1, Cvr = 42200010,
                    Address = "Facebook app 1", Activity = "Internat"
                });
                entity.HasData(new Society
                {
                    Id = 2, Name = "Hurlumhejhuset", MunicipalityId = 2, Cvr = 42200018,
                    Address = "Aldersrovej 26", Activity = "Bofællesskab"
                });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}