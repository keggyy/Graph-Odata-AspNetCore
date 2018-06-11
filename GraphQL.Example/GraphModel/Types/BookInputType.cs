using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Example.GraphModel.Types
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Name = "BookInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
