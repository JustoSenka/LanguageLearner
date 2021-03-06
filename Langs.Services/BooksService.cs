﻿using Langs.Data.Context;
using Langs.Data.Objects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Langs.Services
{
    public class BooksService : BaseService<Book>, IBooksService
    {
        protected override DbSet<Book> EntitiesProxy => m_Context.Books;
        public BooksService(IDatabaseContext context) : base(context) { }

        public override Book Get(int id) => GetAllWithData().SingleOrDefault(e => e.ID == id);

        public IEnumerable<Book> GetAllWithLanguage() => m_Context.Books
            .Include(p => p.Language);

        public IEnumerable<Book> GetAllWithWordCount() => m_Context.Books
            .Include(p => p.Language)
            .Include(p => p._BookWordCollection);

        public IEnumerable<Book> GetAllWithMasterWords() => m_Context.Books
            .Include(p => p.Language)
            .Include(p => p._BookWordCollection)
                .ThenInclude(c => c.MasterWord);

        public IEnumerable<Book> GetAllWithData() => m_Context.Books
            .Include(p => p.Language)
            .Include(p => p._BookWordCollection)
                .ThenInclude(c => c.MasterWord)
                    .ThenInclude(c => c.Words)
                        .ThenInclude(t => t.Explanations)
                            .ThenInclude(t => t.LanguageTo)
            .Include(p => p._BookWordCollection)
                .ThenInclude(c => c.MasterWord)
                    .ThenInclude(c => c.Words)
                        .ThenInclude(t => t.Definition)
            .Include(p => p._BookWordCollection)
                .ThenInclude(c => c.MasterWord)
                    .ThenInclude(c => c.Words)
                        .ThenInclude(t => t.Language);
    }
}
