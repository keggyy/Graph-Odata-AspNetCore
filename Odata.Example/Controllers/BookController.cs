using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Example.DAL.Models;
using Example.DAL;

namespace Odata.Example.Controllers
{
    [Produces("application/json")]
    public class BookController : ODataController
    {
        private readonly BookContext context;

        public BookController(BookContext context) => this.context = context;

        // GET: odata/Book
        [EnableQuery]
        public IQueryable<Book> Get() => context.Books.AsQueryable();
    }
}