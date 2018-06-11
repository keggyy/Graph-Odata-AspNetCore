using Example.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Example.Repository
{
    public class RepositoryContext
    {
        public BookRepository bookRepository { get; private set; }
        public AuthorRepository authorRepository { get; private set; }

        public RepositoryContext(BookContext context)
        {
            bookRepository = new BookRepository(context);
            authorRepository = new AuthorRepository(context);
        }

    }
}
