using BlazorApp_firstProgram.Data;
using MongoDB.Driver;
using Neo4jClient;
using Neo4jClient.Cypher;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_firstProgram.Neo4jService
{
    public class Person1
    {

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }
    }

    public class ServiceUserNeo4j
    {
        //private MongoClient _mongoClient = null;
        //private IMongoCollection<User> _userTable = null;
        //private IMongoDatabase _database = null;
        GraphClient client = null;
        IServiceUserNeo4j graph = null;

        public ServiceUserNeo4j()
        {
            //_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
            //_database = _mongoClient.GetDatabase("CinemaDB");
            //_userTable = _database.GetCollection<User>("users");
            client = new GraphClient(new Uri("http://localhost:7874/GraphDB/dataUser/"), "User", "Password");
            graph = new IServiceUserNeo4j();
            client.ConnectAsync();
        }

        public void Add()
        {
            int a = graph.PathLength("6156dcfb04479cf81e4c9662", "6154ccec9904cf027a0729d2");
            var path = client.Cypher
                            .Match("(u1:Person1 {userId: '6156dcfb04479cf81e4c9662'} )",
                                    "(u2: Person1 { userId: '6154ccec9904cf027a0729d2'})",
                                    "p = shortestPath((u1) -[:Following *]->(u2))")
                            .Return(p => new
                            {
                                length = Return.As<int>("length(p)")
                            }).ResultsAsync;

        }
    }
}
