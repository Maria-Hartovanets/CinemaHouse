using BlazorApp_firstProgram.Data;
using BlazorApp_firstProgram.IService;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_firstProgram.Service
{
    public class ServiceActor:IServiceObj<Actor>
    {
        private MongoClient _mongoClient = null;
        private IMongoCollection<Actor> _actorTable = null;
        private IMongoDatabase _database = null;

        public ServiceActor()
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
            _database = _mongoClient.GetDatabase("CinemaDB");
            _actorTable = _database.GetCollection<Actor>("actors");
        }

        public string Delete(string userId)
        {
            _actorTable.DeleteOne(x => x.Id == userId);
            return "Succsesfull deleted!";
        }

        public Actor GetUser(string userId)
        {
            return _actorTable.Find(x => x.Id == userId).FirstOrDefault();
        }

        public List<Actor> GetUsers()
        {
            return _actorTable.Find(FilterDefinition<Actor>.Empty).ToList();
        }

        public void SaveOrUpdate(Actor actor)
        {
            var userObj = _actorTable.Find(x => x.Id == actor.Id).FirstOrDefault();
            if (userObj == null)
            {
                _actorTable.InsertOne(actor);
            }
            else
            {
                _actorTable.ReplaceOne(x => x.Id == actor.Id, actor);
            }
        }
    }
}
