using Example.DAL;
using Example.DAL.Models;
using GraphQL.Example.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Example.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private readonly BookContext _db;

        public BookRepository(BookContext db)
        {
            _db = db;
        }

        public Book Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            return _db.Books.Where(x => x.Id == id).FirstOrDefault();
        }

        public Book Get(string name)
        {
            return _db.Books.Where(x => x.Name.Equals(name)).FirstOrDefault();
        }

        public List<Book> GetAll()
        {
            return _db.Books.ToList();
        }
    }
}
