﻿using Langs.Data.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Langs.Data.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        private readonly DbContextOptions m_Options;

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            m_Options = options;
        }

        public DbContext Context => this;

        public DbSet<Book> Books { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<MasterWord> MasterWords { get; set; }
        public DbSet<Language> Languages { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Remove cascading on all foreign keys, since in most cases we don't want it.
            // Re-Add later manually for join tables
            foreach (var relationship in builder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            // Book - Word : Many To Many
            builder.Entity<BookWord>().HasKey(e => new { e.BookId, e.MasterWordId });
            builder.Entity<BookWord>()
                .HasOne(e => e.MasterWord)
                .WithMany(e => e._BookWordCollection)
                .HasForeignKey(e => e.MasterWordId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BookWord>()
                .HasOne(e => e.Book)
                .WithMany(e => e._BookWordCollection)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Word Owned types
            builder.Entity<Word>().OwnsMany(e => e.Explanations).ToTable("Explanations");
            builder.Entity<Word>().OwnsOne(e => e.Definition).ToTable("Definitions");
        }

        public void RefreshDatabaseContext()
        {
            throw new NotSupportedException("Cannot ReplaceDatabaseContext on IDatabaseContext which is not a proxy object.");
        }

        public IDatabaseContext Clone()
        {
            var db = new DatabaseContext(m_Options);
            this.DisposeAsync();
            return db;
        }

        void IDatabaseContext.SaveChanges() => SaveChanges();
    }
}
