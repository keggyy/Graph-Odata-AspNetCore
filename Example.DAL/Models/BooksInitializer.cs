using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.DAL.Models
{
    public class BooksInitializer
    {
        private static bool _initialized = false;
        private static object _lock = new object();
        private static List<Author> authors;
        private static List<Book> books;
        private static List<Publisher> publishers;

        public static void Seed(BookContext context)
        {
            AddPublishers(context);
            AddAuthors(context);
            AddBooks(context);
        }

        public static void Initialize(BookContext context)
        {
            if (!_initialized)
            {
                lock (_lock)
                {
                    if (_initialized)
                        return;

                    InitializeData(context);
                }
            }
        }

        private static void AddAuthors(BookContext context)
        {
            authors = new List<Author>
            {
                new Author
                {
                    Name = "Giovanni Pascoli",
                },
                new Author
                {
                    Name = "Giuseppe Ungaretti",
                }
            };
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(authors);
                context.SaveChanges();
            }
        }

        private static void AddBooks(BookContext context)
        {
            books = new List<Book>
            {
                new Book
                {
                    AuthorId = 1,
                    Name = "Myricae",
                    PublisherId = 1
                },
                new Book
                {
                    AuthorId = 1,
                    Name = "Il fanciullino",
                    PublisherId = 2
                },
                new Book
                {
                    AuthorId = 1,
                    Name = "Canti di Castelvecchio",
                    PublisherId = 1
                },
                new Book
                {
                    AuthorId = 1,
                    Name = "Primi poemetti ",
                    PublisherId = 2
                },
                new Book
                {
                    AuthorId = 1,
                    Name = "Poemi conviviali",
                    PublisherId = 1
                },
                new Book
                {
                    AuthorId = 2,
                    Name = "II Porto Sepolto",
                    PublisherId = 1
                },
                new Book
                {
                    AuthorId = 2,
                    Name = "Natale",
                    PublisherId = 2
                },
                new Book
                {
                    AuthorId = 2,
                    Name = "Le Guerre",
                    PublisherId = 2
                }
            };

            if (!context.Books.Any())
            {
                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }

        private static void AddPublishers(BookContext context)
        {
            publishers = new List<Publisher>
            {
                new Publisher
                {
                    Name = "RCI"
                }, new Publisher
                {
                    Name = "Mondadori"
                }
            };
            if (!context.Publishers.Any())
            {
                context.Publishers.AddRange(publishers);
                context.SaveChanges();
            }
        }

        private static void InitializeData(BookContext context)
        {
            context.Database.Migrate();
            Seed(context);
        }
    }
}
