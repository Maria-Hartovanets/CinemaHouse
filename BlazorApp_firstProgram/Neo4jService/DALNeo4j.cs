using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neo4jClient;
using Neo4jClient.Cypher;
using Newtonsoft.Json;

namespace BlazorApp_firstProgram.Neo4jService
{
    public class Person
    {

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }
    }
    public class PostNeo4j
    {
        [JsonProperty(PropertyName = "postId")]
        public string PostId { get; set; }
    }
    public class DALNeo4j
    {

        public GraphClient client;
        public DALNeo4j()
        {
            client = new GraphClient(new Uri("http://localhost:7474/db/data/"), "Maria", "12345");

            client.ConnectAsync();
        }

        public void CreateRelation(string userId, string postId)
        {
            client.Cypher
              .Match("(user:Person {userId: {userId}})", "(post:PostNeo4j {postId: {postId}})")
              .WithParam("userId", userId)
              .WithParam("postId", postId)
              .Create("(user)-[:Like]->(post)")
              .ExecuteWithoutResultsAsync();
        }

        public int PathLengthInOneDirection(string userId, string postId)
        {

            try
            {
                var path = client.Cypher
           .Match("(user:Person {userId:{userId}} )",
                  "(post:PostNeo4j { postId:{postId}})",
                  "p = shortestPath((user) -[:Like *]->(post))")
           .WithParam("userId", userId)
           .WithParam("postId", postId)
           .Return(p => Return.As<int>("length(p)"))
           .ResultsAsync;
                int p = Convert.ToInt32(path.Result);
                return p;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public void DeleteRelation(string userId, string postId)
        {

            client.Cypher
            .Match("(user:Person{userId:{userId}})-[l:Like]->(post:PostNeo4j{postId:{postId}})")
            .WithParam("userId", userId)
            .WithParam("postId", postId)
            .Delete("l")
            .ExecuteWithoutResultsAsync();
        }
    }
}
