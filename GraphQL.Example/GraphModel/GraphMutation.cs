using Example.DAL.Models;
using GraphQL.Example.GraphModel.Types;
using GraphQL.Example.Repository.Interface;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Example.GraphModel
{
    public class GraphMutation : ObjectGraphType
    {
        public GraphMutation(IRepository<Book> repository)
        {
            Name = "Mutation";

            Field<BookType>(
                "AddBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "Book" }
                ),
                resolve: context =>
                {
                    var book = context.GetArgument<Book>("Book");
                    return repository.Add(book);
                });
        }
    }
}
