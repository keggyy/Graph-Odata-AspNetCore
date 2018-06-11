using Example.DAL.Models;
using GraphQL.Example.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Example.GraphModel.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(RepositoryContext repo)
        {
            Field(x => x.Id);
            Field(x => x.Name);
//            Field<ListGraphType<BookType>>("Books", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }), resolve: context => repo.authorRepository.GetAll() );
        }
    }
}