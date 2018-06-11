using Example.DAL;
using Example.DAL.Models;
using GraphQL.Example.Repository;
using GraphQL.Example.Repository.Interface;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Example.GraphModel.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(RepositoryContext repository)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.AuthorId);
            Field<AuthorType>("Author",
                description: "Author of book",
                resolve: context => repository.authorRepository.Get(context.Source.AuthorId)
                );
        }
    }
}
