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
    [Migration("20200519070231_Account")]
    partial class Account
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Langs.Data.Objects.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdditionalLanguageID")
                        .HasColumnType("int");

                    b.Property<int?>("LearningLanguageID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<int?>("NativeLanguageID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AdditionalLanguageID");

                    b.HasIndex("LearningLanguageID");

                    b.HasIndex("NativeLanguageID");

                    b.ToTable("Accounts");
                });

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

                    b.HasIndex("LanguageID");

                    b.HasIndex("MasterWordID");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Langs.Data.Objects.Account", b =>
                {
                    b.HasOne("Langs.Data.Objects.Language", "AdditionalLanguage")
                        .WithMany()
                        .HasForeignKey("AdditionalLanguageID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Langs.Data.Objects.Language", "LearningLanguage")
                        .WithMany()
                        .HasForeignKey("LearningLanguageID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Langs.Data.Objects.Language", "NativeLanguage")
                        .WithMany()
                        .HasForeignKey("NativeLanguageID")
                        .OnDelete(DeleteBehavior.Restrict);
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

            modelBuilder.Entity("Langs.Data.Objects.Word", b =>
                {
                    b.HasOne("Langs.Data.Objects.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Langs.Data.Objects.MasterWord", "MasterWord")
                        .WithMany("Words")
                        .HasForeignKey("MasterWordID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("Langs.Data.Objects.Definition", "Definition", b1 =>
                        {
                            b1.Property<int>("WordID")
                                .HasColumnType("int");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("WordID");

                            b1.ToTable("Definitions");

                            b1.WithOwner()
                                .HasForeignKey("WordID");
                        });

                    b.OwnsMany("Langs.Data.Objects.Explanation", "Explanations", b1 =>
                        {
                            b1.Property<int>("WordID")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("LanguageToID")
                                .HasColumnType("int");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.HasKey("WordID", "Id");

                            b1.HasIndex("LanguageToID");

                            b1.ToTable("Explanations");

                            b1.HasOne("Langs.Data.Objects.Language", "LanguageTo")
                                .WithMany()
                                .HasForeignKey("LanguageToID")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("WordID");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
