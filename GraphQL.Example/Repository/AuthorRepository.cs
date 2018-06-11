using Example.DAL;
using Example.DAL.Models;
using GraphQL.Example.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Example.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly BookContext _db;
        public AuthorRepository(BookContext db)
        {
            _db = db;
        }
        public Author Add(Author entity)
        {
            throw new NotImplementedException();
        }

        public Author Get(int id)
        {
            return _db.Authors.Where(x => x.Id == id).FirstOrDefault();
        }

        public Author Get(string name)
        {
            return _db.Authors.Where(x => x.Name.Contains(name)).FirstOrDefault();
        }

        public List<Author> GetAll()
        {
            return _db.Authors.ToList();
        }
    }
}
