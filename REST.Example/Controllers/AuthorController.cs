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
    [Route("api/Author")]
    public class AuthorController : Controller
    {
        private readonly BookContext context;

        public AuthorController(BookContext context) => this.context = context;

        // GET: api/Author
        [HttpGet]
        public IEnumerable<Author> Get() => context.Authors.Include(r => r.Books).ThenInclude(b => b.Publisher);
    }
}