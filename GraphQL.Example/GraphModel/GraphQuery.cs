using Example.DAL;
using Example.DAL.Models;
using Example.DAL.Models.Interfaces;
using GraphQL.Example.GraphModel.Types;
using GraphQL.Example.Repository;
using GraphQL.Example.Repository.Interface;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Example.GraphModel
{
    public class GraphQuery : ObjectGraphType
    {
        public GraphQuery(RepositoryContext repo)
        {
            Name = "Query";

            Field<BookType>(
                name: "Book",
                description: "Books query",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }, new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context => context.HasArgument("id") ?  repo.bookRepository.Get(context.GetArgument<int>("id")) : repo.bookRepository.Get(context.GetArgument<string>("name"))
                );

            Field<ListGraphType<BookType>>(
                name: "Books",
                description: "Books query",
                resolve: context => repo.bookRepository.GetAll()
                );
        }
    }
}
