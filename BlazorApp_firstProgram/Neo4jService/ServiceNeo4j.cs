using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_firstProgram.Neo4jService
{
    public  class ServiceNeo4j
    {
         DALNeo4j graph;
         public ServiceNeo4j()
        {
            graph = new DALNeo4j();
        }
         public void LikeUserPostGraph(string userId, string postId)
        {
            graph.CreateRelation(userId, postId);
        }
         public void UnLikeUserPostGraph(string userId, string postId)
        {
            graph.DeleteRelation(userId, postId);
        }
         public int GetPathLength(string userId, string postId)
        {
            return (graph.PathLengthInOneDirection(userId, postId));
        }
    }
}
