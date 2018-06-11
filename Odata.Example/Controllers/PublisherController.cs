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
    public class PublisherController : ODataController
    {
        private readonly BookContext context;

        public PublisherController(BookContext context) => this.context = context;

        // GET: odata/Publisher
        [EnableQuery]
        public IQueryable<Publisher> Get() => context.Publishers.AsQueryable();
    }
}