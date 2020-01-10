﻿using LangData.Objects;
using LangServices;
using LanguageLearner.Models;
using LanguageLearner.Models.Books;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace LanguageLearner.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService BookService;
        public BooksController(IBooksService BookService)
        {
            this.BookService = BookService;
        }

        public IActionResult Index()
        {
            try
            {
                var books = BookService.GetAll().ToArray();
                var bookModel = new BookIndexModel() { Books = books };

                return View(bookModel);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { Exception = e, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public IActionResult Book(int id)
        {
            var book = BookService.Get(id);
            /*if (book == default)
                return RedirectToAction("Error");*/

            var bookModel = new BookModel() { Book = book };
            return View(bookModel);
        }

        public IActionResult NewBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CompleteNewBook(string name, string description)
        {
            var book = new Book(name, description);
            book = BookService.Add(book);
            return RedirectToAction("Book", new { id = book.ID });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
