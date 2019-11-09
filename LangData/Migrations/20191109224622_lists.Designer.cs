﻿// <auto-generated />
using System;
using LangData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LangData.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20191109224622_lists")]
    partial class lists
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LangData.Objects.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LangData.Objects.Definition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Examples");

                    b.Property<int?>("LanguageID");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("LanguageID");

                    b.ToTable("Definitions");
                });

            modelBuilder.Entity("LangData.Objects.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("LangData.Objects.Translation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DefinitionID");

                    b.Property<int?>("WordID");

                    b.HasKey("ID");

                    b.HasIndex("DefinitionID");

                    b.HasIndex("WordID");

                    b.ToTable("Translation");
                });

            modelBuilder.Entity("LangData.Objects.Word", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookID");

                    b.Property<int?>("LanguageID");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.HasIndex("LanguageID");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("LangData.Objects.Definition", b =>
                {
                    b.HasOne("LangData.Objects.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID");
                });

            modelBuilder.Entity("LangData.Objects.Translation", b =>
                {
                    b.HasOne("LangData.Objects.Definition", "Definition")
                        .WithMany("Translations")
                        .HasForeignKey("DefinitionID");

                    b.HasOne("LangData.Objects.Word", "Word")
                        .WithMany("Translations")
                        .HasForeignKey("WordID");
                });

            modelBuilder.Entity("LangData.Objects.Word", b =>
                {
                    b.HasOne("LangData.Objects.Book")
                        .WithMany("Words")
                        .HasForeignKey("BookID");

                    b.HasOne("LangData.Objects.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID");
                });
#pragma warning restore 612, 618
        }
    }
}
