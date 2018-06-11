using GraphQL.Types;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Example.GraphModel
{
    public class GraphSchema : Schema
    {
        public GraphSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<GraphQuery>();
            Mutation = dependencyResolver.Resolve<GraphMutation>();
        }
    }
}
