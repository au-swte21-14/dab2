﻿// <auto-generated />
using System;
using EFCoreDab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreDab2.Migrations
{
    [DbContext(typeof(au653289Context))]
    partial class au653289ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreDab2.Models.Access", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DriverLicense")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Access");
                });

            modelBuilder.Entity("EFCoreDab2.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address");

                    b.Property<int>("Cpr")
                        .HasColumnType("int")
                        .HasColumnName("cpr");

                    b.Property<bool?>("IsChairman")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("isChairman")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.Property<int>("SocietyId")
                        .HasColumnType("int")
                        .HasColumnName("societyId");

                    b.HasKey("Id");

                    b.HasIndex("SocietyId");

                    b.ToTable("member");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Dyrevej 25",
                            Cpr = 105882521,
                            IsChairman = true,
                            Name = "Mark Marsvin",
                            SocietyId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Aldersrovej 26",
                            Cpr = 108002352,
                            IsChairman = true,
                            Name = "Lasse Hyldahl",
                            SocietyId = 2
                        },
                        new
                        {
                            Id = 3,
                            Address = "Park Allé 24",
                            Cpr = 2102772423,
                            IsChairman = false,
                            Name = "Gurli gris",
                            SocietyId = 1
                        });
                });

            modelBuilder.Entity("EFCoreDab2.Models.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cvr")
                        .HasColumnType("int")
                        .HasColumnName("cvr");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("municipality");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cvr = 42200011,
                            Name = "Magnus kommune"
                        },
                        new
                        {
                            Id = 2,
                            Cvr = 42200019,
                            Name = "Lasses kommune"
                        });
                });

            modelBuilder.Entity("EFCoreDab2.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("access");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address");

                    b.Property<int?>("Limit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("limit")
                        .HasDefaultValueSql("((-1))");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int")
                        .HasColumnName("municipalityId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("room");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Access = "Brækjern",
                            Address = "Rumallé 1",
                            Limit = 20,
                            MunicipalityId = 1,
                            Name = "Mødelokale"
                        },
                        new
                        {
                            Id = 2,
                            Access = "Åbent",
                            Address = "Rumallé 1",
                            Limit = 3,
                            MunicipalityId = 1,
                            Name = "Toilet"
                        },
                        new
                        {
                            Id = 3,
                            Access = "2426",
                            Address = "Motionsvej 24",
                            Limit = -1,
                            MunicipalityId = 2,
                            Name = "Sportshal"
                        });
                });

            modelBuilder.Entity("EFCoreDab2.Models.RoomProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("roomId");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("room_property");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "WiFi",
                            RoomId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Projektor",
                            RoomId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "10 Stole",
                            RoomId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Toilet",
                            RoomId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Håndvask",
                            RoomId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Fodboldmål",
                            RoomId = 3
                        });
                });

            modelBuilder.Entity("EFCoreDab2.Models.RoomReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime")
                        .HasColumnName("endTime");

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("memberId");

                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("roomId");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime")
                        .HasColumnName("startTime");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("RoomId");

                    b.ToTable("room_reservation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTime = new DateTime(2021, 9, 22, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            MemberId = 3,
                            RoomId = 1,
                            StartTime = new DateTime(2021, 9, 22, 16, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            EndTime = new DateTime(2021, 9, 21, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            MemberId = 2,
                            RoomId = 2,
                            StartTime = new DateTime(2021, 9, 21, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EFCoreDab2.Models.Society", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Activity")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("activity");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address");

                    b.Property<int>("Cvr")
                        .HasColumnType("int")
                        .HasColumnName("cvr");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int")
                        .HasColumnName("municipalityId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("society");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activity = "Internat",
                            Address = "Facebook app 1",
                            Cvr = 42200010,
                            MunicipalityId = 1,
                            Name = "Pet society"
                        },
                        new
                        {
                            Id = 2,
                            Activity = "Bofællesskab",
                            Address = "Aldersrovej 26",
                            Cvr = 42200018,
                            MunicipalityId = 2,
                            Name = "Hurlumhejhuset"
                        });
                });

            modelBuilder.Entity("EFCoreDab2.Models.Access", b =>
                {
                    b.HasOne("EFCoreDab2.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("EFCoreDab2.Models.Member", b =>
                {
                    b.HasOne("EFCoreDab2.Models.Society", "Society")
                        .WithMany("Members")
                        .HasForeignKey("SocietyId")
                        .HasConstraintName("FK__member__societyI__2EDAF651")
                        .IsRequired();

                    b.Navigation("Society");
                });

            modelBuilder.Entity("EFCoreDab2.Models.Room", b =>
                {
                    b.HasOne("EFCoreDab2.Models.Municipality", "Municipality")
                        .WithMany("Rooms")
                        .HasForeignKey("MunicipalityId")
                        .HasConstraintName("FK__room__municipali__32AB8735")
                        .IsRequired();

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("EFCoreDab2.Models.RoomProperty", b =>
                {
                    b.HasOne("EFCoreDab2.Models.Room", "Room")
                        .WithMany("RoomProperties")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK__room_prop__roomI__367C1819")
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("EFCoreDab2.Models.RoomReservation", b =>
                {
                    b.HasOne("EFCoreDab2.Models.Member", "Member")
                        .WithMany("RoomReservations")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK__room_rese__membe__3A4CA8FD")
                        .IsRequired();

                    b.HasOne("EFCoreDab2.Models.Room", "Room")
                        .WithMany("RoomReservations")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK__room_rese__roomI__395884C4")
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("EFCoreDab2.Models.Society", b =>
                {
                    b.HasOne("EFCoreDab2.Models.Municipality", "Municipality")
                        .WithMany("Societies")
                        .HasForeignKey("MunicipalityId")
                        .HasConstraintName("FK__society__municip__2BFE89A6")
                        .IsRequired();

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("EFCoreDab2.Models.Member", b =>
                {
                    b.Navigation("RoomReservations");
                });

            modelBuilder.Entity("EFCoreDab2.Models.Municipality", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("Societies");
                });

            modelBuilder.Entity("EFCoreDab2.Models.Room", b =>
                {
                    b.Navigation("RoomProperties");

                    b.Navigation("RoomReservations");
                });

            modelBuilder.Entity("EFCoreDab2.Models.Society", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
