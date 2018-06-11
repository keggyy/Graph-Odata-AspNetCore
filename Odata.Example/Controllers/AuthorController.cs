using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example.DAL.Models;
using Microsoft.AspNet.OData;
using Example.DAL;

namespace Odata.Example.Controllers
{
    [Produces("application/json")]
    public class AuthorController : ODataController
    {
        private readonly BookContext context;

        public AuthorController(BookContext context) => this.context = context;

        // GET: odata/Author
        [EnableQuery]
        public IQueryable<Author> Get() => context.Authors.AsQueryable();
    }
}