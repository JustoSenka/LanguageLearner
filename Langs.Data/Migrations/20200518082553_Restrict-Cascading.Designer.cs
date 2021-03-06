﻿// <auto-generated />
using System;
using Langs.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Langs.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200518082553_Restrict-Cascading")]
    partial class RestrictCascading
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Langs.Data.Objects.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Langs.Data.Objects.BookWord", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("MasterWordId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "MasterWordId");

                    b.HasIndex("MasterWordId");

                    b.ToTable("BookWord");
                });

            modelBuilder.Entity("Langs.Data.Objects.Definition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Definitions");
                });

            modelBuilder.Entity("Langs.Data.Objects.Explanation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LanguageToID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("WordID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LanguageToID");

                    b.HasIndex("WordID");

                    b.ToTable("Explanations");
                });

            modelBuilder.Entity("Langs.Data.Objects.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Langs.Data.Objects.MasterWord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ID");

                    b.ToTable("MasterWords");
                });

            modelBuilder.Entity("Langs.Data.Objects.Word", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlternateSpelling")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Article")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int?>("DefinitionID")
                        .HasColumnType("int");

                    b.Property<int>("LanguageID")
                        .HasColumnType("int");

                    b.Property<int?>("MasterWordID")
                        .HasColumnType("int");

                    b.Property<string>("Pronunciation")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.HasIndex("DefinitionID");

                    b.HasIndex("LanguageID");

                    b.HasIndex("MasterWordID");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Langs.Data.Objects.BookWord", b =>
                {
                    b.HasOne("Langs.Data.Objects.Book", "Book")
                        .WithMany("_BookWordCollection")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Langs.Data.Objects.MasterWord", "MasterWord")
                        .WithMany("_BookWordCollection")
                        .HasForeignKey("MasterWordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Langs.Data.Objects.Explanation", b =>
                {
                    b.HasOne("Langs.Data.Objects.Language", "LanguageTo")
                        .WithMany()
                        .HasForeignKey("LanguageToID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Langs.Data.Objects.Word", null)
                        .WithMany("Explanations")
                        .HasForeignKey("WordID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Langs.Data.Objects.Word", b =>
                {
                    b.HasOne("Langs.Data.Objects.Definition", "Definition")
                        .WithMany()
                        .HasForeignKey("DefinitionID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Langs.Data.Objects.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Langs.Data.Objects.MasterWord", "MasterWord")
                        .WithMany("Words")
                        .HasForeignKey("MasterWordID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
