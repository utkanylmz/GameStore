﻿// <auto-generated />
using System;
using GameStore.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameStore.Persistance.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameStore.Domain.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameDeveleporId")
                        .HasColumnType("int")
                        .HasColumnName("GameDeveleporId");

                    b.Property<int?>("GameDeveloperId")
                        .HasColumnType("int");

                    b.Property<int>("GameTypeId")
                        .HasColumnType("int")
                        .HasColumnName("GameTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Platform");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ReleaseDate");

                    b.HasKey("Id");

                    b.HasIndex("GameDeveloperId");

                    b.HasIndex("GameTypeId");

                    b.ToTable("Games", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameDeveleporId = 1,
                            GameTypeId = 1,
                            Name = "Cs Go",
                            Platform = "Pc",
                            Price = 120m,
                            ReleaseDate = new DateTime(2023, 4, 18, 14, 0, 20, 424, DateTimeKind.Local).AddTicks(5125)
                        },
                        new
                        {
                            Id = 2,
                            GameDeveleporId = 2,
                            GameTypeId = 2,
                            Name = "Fifa",
                            Platform = "Pc/Console",
                            Price = 600m,
                            ReleaseDate = new DateTime(2023, 4, 18, 14, 0, 20, 424, DateTimeKind.Local).AddTicks(5143)
                        });
                });

            modelBuilder.Entity("GameStore.Domain.Entities.GameDeveloper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeveloperCompanyCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DeveloperCompanyCountry");

                    b.Property<string>("DeveloperCompanyMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DeveloperCompanyMail");

                    b.Property<string>("DeveloperCompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DeveloperCompanyName");

                    b.HasKey("Id");

                    b.ToTable("GameDevelopers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeveloperCompanyCountry = "Abd",
                            DeveloperCompanyMail = "Valve@valve.com",
                            DeveloperCompanyName = "Valve"
                        },
                        new
                        {
                            Id = 2,
                            DeveloperCompanyCountry = "Canada",
                            DeveloperCompanyMail = "EaSport@EaSport.com",
                            DeveloperCompanyName = "EA Sport"
                        });
                });

            modelBuilder.Entity("GameStore.Domain.Entities.GameType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TypeDescription");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TypeName");

                    b.HasKey("Id");

                    b.ToTable("GameTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeDescription = "It is a type of video game in which the player tries to shoot down enemies using a gun from a first-person perspective.",
                            TypeName = "Fps"
                        },
                        new
                        {
                            Id = 2,
                            TypeDescription = "Sports games are video games that aim to give players the rules and experience of related sports by simulating various sports.",
                            TypeName = "Sport Game"
                        });
                });

            modelBuilder.Entity("GameStore.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NickNames");

                    b.Property<string>("TelNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TelNumber");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2023, 4, 18, 14, 0, 20, 424, DateTimeKind.Local).AddTicks(5159),
                            Email = "Utkan@utkan.gmail.com",
                            FirstName = "Utkan",
                            IsActive = true,
                            LastName = "Yılmaz",
                            NickName = "utkanylmz",
                            TelNumber = "0545545545"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2023, 4, 18, 14, 0, 20, 424, DateTimeKind.Local).AddTicks(5168),
                            Email = "Hasan@sanık.gmail.com",
                            FirstName = "Hasan",
                            IsActive = true,
                            LastName = "Sanık",
                            NickName = "HsnSnk",
                            TelNumber = "0532532532"
                        });
                });

            modelBuilder.Entity("GameUser", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GameUser");
                });

            modelBuilder.Entity("GameStore.Domain.Entities.Game", b =>
                {
                    b.HasOne("GameStore.Domain.Entities.GameDeveloper", "GameDeveloper")
                        .WithMany("Games")
                        .HasForeignKey("GameDeveloperId");

                    b.HasOne("GameStore.Domain.Entities.GameType", "GameType")
                        .WithMany("Games")
                        .HasForeignKey("GameTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameDeveloper");

                    b.Navigation("GameType");
                });

            modelBuilder.Entity("GameUser", b =>
                {
                    b.HasOne("GameStore.Domain.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameStore.Domain.Entities.GameDeveloper", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GameStore.Domain.Entities.GameType", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
