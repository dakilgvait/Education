﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Person.DAL.Context;

namespace Person.DAL.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20190917184811_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Person.DAL.Entity.GenderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 0,
                            Name = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Code = 1,
                            Name = "Female"
                        });
                });

            modelBuilder.Entity("Person.DAL.Entity.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasMaxLength(25);

                    b.Property<int>("GenderId");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("PersonNumber")
                        .HasMaxLength(11);

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("PersonNumber")
                        .IsUnique()
                        .HasFilter("[PersonNumber] IS NOT NULL");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthdate = new DateTime(1963, 9, 25, 12, 7, 23, 0, DateTimeKind.Local),
                            FirstName = "vera",
                            GenderId = 2,
                            LastName = "wood",
                            PersonNumber = "00001175132",
                            Salary = 3203626m
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(1976, 1, 26, 8, 54, 51, 0, DateTimeKind.Local),
                            FirstName = "marion",
                            GenderId = 2,
                            LastName = "graves",
                            PersonNumber = "00002517114",
                            Salary = 9878052m
                        },
                        new
                        {
                            Id = 3,
                            Birthdate = new DateTime(1955, 6, 16, 21, 56, 15, 0, DateTimeKind.Local),
                            FirstName = "maureen",
                            GenderId = 2,
                            LastName = "hudson",
                            PersonNumber = "00000131068",
                            Salary = 842228m
                        },
                        new
                        {
                            Id = 4,
                            Birthdate = new DateTime(1973, 1, 20, 6, 31, 26, 0, DateTimeKind.Local),
                            FirstName = "jeffrey",
                            GenderId = 1,
                            LastName = "stephens",
                            PersonNumber = "00000965393",
                            Salary = 9989429m
                        },
                        new
                        {
                            Id = 5,
                            Birthdate = new DateTime(1946, 6, 12, 15, 29, 56, 0, DateTimeKind.Local),
                            FirstName = "bella",
                            GenderId = 2,
                            LastName = "welch",
                            PersonNumber = "00005594189",
                            Salary = 5967764m
                        },
                        new
                        {
                            Id = 6,
                            Birthdate = new DateTime(1973, 12, 22, 16, 32, 54, 0, DateTimeKind.Local),
                            FirstName = "erika",
                            GenderId = 2,
                            LastName = "gonzalez",
                            PersonNumber = "00005222962",
                            Salary = 5706540m
                        },
                        new
                        {
                            Id = 7,
                            Birthdate = new DateTime(1957, 1, 24, 1, 49, 16, 0, DateTimeKind.Local),
                            FirstName = "shelly",
                            GenderId = 2,
                            LastName = "phillips",
                            PersonNumber = "00007507760",
                            Salary = 8141896m
                        },
                        new
                        {
                            Id = 8,
                            Birthdate = new DateTime(1946, 10, 21, 8, 58, 0, 0, DateTimeKind.Local),
                            FirstName = "roberto",
                            GenderId = 1,
                            LastName = "garza",
                            PersonNumber = "00005356822",
                            Salary = 2223593m
                        },
                        new
                        {
                            Id = 9,
                            Birthdate = new DateTime(1984, 2, 21, 2, 47, 7, 0, DateTimeKind.Local),
                            FirstName = "steven",
                            GenderId = 1,
                            LastName = "walker",
                            PersonNumber = "00003917882",
                            Salary = 5407150m
                        },
                        new
                        {
                            Id = 10,
                            Birthdate = new DateTime(1975, 11, 8, 23, 35, 0, 0, DateTimeKind.Local),
                            FirstName = "emma",
                            GenderId = 2,
                            LastName = "banks",
                            PersonNumber = "00001960560",
                            Salary = 7092748m
                        },
                        new
                        {
                            Id = 11,
                            Birthdate = new DateTime(1960, 11, 6, 11, 0, 38, 0, DateTimeKind.Local),
                            FirstName = "ana",
                            GenderId = 2,
                            LastName = "weaver",
                            PersonNumber = "00001948908",
                            Salary = 562748m
                        },
                        new
                        {
                            Id = 12,
                            Birthdate = new DateTime(1960, 5, 27, 16, 46, 31, 0, DateTimeKind.Local),
                            FirstName = "elmer",
                            GenderId = 1,
                            LastName = "hart",
                            PersonNumber = "00000331136",
                            Salary = 7402702m
                        },
                        new
                        {
                            Id = 13,
                            Birthdate = new DateTime(1962, 3, 14, 22, 25, 2, 0, DateTimeKind.Local),
                            FirstName = "esther",
                            GenderId = 2,
                            LastName = "peterson",
                            PersonNumber = "00001517833",
                            Salary = 2368608m
                        },
                        new
                        {
                            Id = 14,
                            Birthdate = new DateTime(1967, 12, 31, 17, 32, 13, 0, DateTimeKind.Local),
                            FirstName = "morris",
                            GenderId = 1,
                            LastName = "chambers",
                            PersonNumber = "00003723263",
                            Salary = 5438711m
                        },
                        new
                        {
                            Id = 15,
                            Birthdate = new DateTime(1991, 6, 10, 16, 36, 34, 0, DateTimeKind.Local),
                            FirstName = "noah",
                            GenderId = 1,
                            LastName = "gutierrez",
                            PersonNumber = "00008931824",
                            Salary = 5241941m
                        },
                        new
                        {
                            Id = 16,
                            Birthdate = new DateTime(1996, 2, 28, 0, 55, 1, 0, DateTimeKind.Local),
                            FirstName = "hazel",
                            GenderId = 2,
                            LastName = "shaw",
                            PersonNumber = "00002099017",
                            Salary = 4045863m
                        },
                        new
                        {
                            Id = 17,
                            Birthdate = new DateTime(1961, 7, 5, 6, 38, 35, 0, DateTimeKind.Local),
                            FirstName = "sara",
                            GenderId = 2,
                            LastName = "castillo",
                            PersonNumber = "00002810928",
                            Salary = 7248822m
                        },
                        new
                        {
                            Id = 18,
                            Birthdate = new DateTime(1990, 4, 16, 19, 14, 48, 0, DateTimeKind.Local),
                            FirstName = "dora",
                            GenderId = 2,
                            LastName = "peterson",
                            PersonNumber = "00008051052",
                            Salary = 48839m
                        },
                        new
                        {
                            Id = 19,
                            Birthdate = new DateTime(1981, 2, 2, 5, 43, 9, 0, DateTimeKind.Local),
                            FirstName = "jason",
                            GenderId = 1,
                            LastName = "walker",
                            PersonNumber = "00005073131",
                            Salary = 9201081m
                        },
                        new
                        {
                            Id = 20,
                            Birthdate = new DateTime(1969, 10, 27, 8, 58, 13, 0, DateTimeKind.Local),
                            FirstName = "alvin",
                            GenderId = 1,
                            LastName = "edwards",
                            PersonNumber = "00004557549",
                            Salary = 8401437m
                        },
                        new
                        {
                            Id = 21,
                            Birthdate = new DateTime(1974, 12, 15, 15, 41, 28, 0, DateTimeKind.Local),
                            FirstName = "kurt",
                            GenderId = 1,
                            LastName = "moore",
                            PersonNumber = "00003201802",
                            Salary = 1279011m
                        },
                        new
                        {
                            Id = 22,
                            Birthdate = new DateTime(1992, 11, 25, 12, 2, 2, 0, DateTimeKind.Local),
                            FirstName = "gilbert",
                            GenderId = 1,
                            LastName = "miller",
                            PersonNumber = "00001602811",
                            Salary = 9158945m
                        },
                        new
                        {
                            Id = 23,
                            Birthdate = new DateTime(1955, 2, 8, 17, 0, 15, 0, DateTimeKind.Local),
                            FirstName = "brad",
                            GenderId = 1,
                            LastName = "cook",
                            PersonNumber = "00000141526",
                            Salary = 4717208m
                        },
                        new
                        {
                            Id = 24,
                            Birthdate = new DateTime(1989, 4, 20, 8, 50, 49, 0, DateTimeKind.Local),
                            FirstName = "jennifer",
                            GenderId = 2,
                            LastName = "bennett",
                            PersonNumber = "00004753410",
                            Salary = 9503051m
                        },
                        new
                        {
                            Id = 25,
                            Birthdate = new DateTime(1981, 8, 17, 1, 47, 14, 0, DateTimeKind.Local),
                            FirstName = "ruby",
                            GenderId = 2,
                            LastName = "herrera",
                            PersonNumber = "00007504400",
                            Salary = 5120060m
                        });
                });

            modelBuilder.Entity("Person.DAL.Entity.PersonEntity", b =>
                {
                    b.HasOne("Person.DAL.Entity.GenderEntity", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
