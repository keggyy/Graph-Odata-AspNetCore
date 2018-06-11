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
    [Route("api/Publisher")]
    public class PublisherController : Controller
    {
        private readonly BookContext context;

        public PublisherController(BookContext context) => this.context = context;

        // GET: api/Publisher
        [HttpGet]
        public IEnumerable<Publisher> Get() => context.Publishers.Include(r => r.Books).ThenInclude(b => b.Author);
    }
}