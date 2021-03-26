﻿// <auto-generated />
using System;
using CursusOverzichtApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CursusOverzichtApi.Migrations
{
    [DbContext(typeof(CursusContext))]
    [Migration("20210323080819_Cursusinstantie-initial")]
    partial class Cursusinstantieinitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CursusOverzichtApi.Models.Cursus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CursusCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duur")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("cursussen");
                });

            modelBuilder.Entity("CursusOverzichtApi.Models.Cursusinstantie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Startdatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("cursusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cursusId");

                    b.ToTable("cursusinstanties");
                });

            modelBuilder.Entity("CursusOverzichtApi.Models.Cursusinstantie", b =>
                {
                    b.HasOne("CursusOverzichtApi.Models.Cursus", "cursus")
                        .WithMany("cursusinstanties")
                        .HasForeignKey("cursusId");
                });
#pragma warning restore 612, 618
        }
    }
}
