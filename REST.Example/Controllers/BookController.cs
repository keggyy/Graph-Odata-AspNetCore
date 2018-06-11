using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example.DAL;
using Example.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace REST.Example.Controllers
{
    [Produces("application/json")]
    [Route("api/Book")]
    public class BookController : Controller
    {
        private readonly BookContext context;

        public BookController(BookContext context) => this.context = context;

        // GET: api/book
        [HttpGet]
        public IEnumerable<Book> Get() => context.Books.Include(b => b.Author).Include(b => b.Publisher);
    }
}