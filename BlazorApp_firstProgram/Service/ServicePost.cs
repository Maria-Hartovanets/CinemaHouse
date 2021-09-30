using BlazorApp_firstProgram.Data;
using BlazorApp_firstProgram.IService;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_firstProgram.Service
{
    public class ServicePost : IServiceObj<Post>
    {
        private MongoClient _mongoClient = null;
        private IMongoCollection<Post> _postTable = null;
        private IMongoDatabase _database = null;
        public ServicePost()
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
            _database = _mongoClient.GetDatabase("CinemaDB");
            _postTable = _database.GetCollection<Post>("posts");
        }
        public string Delete(string userId)
        {
            _postTable.DeleteOne(x => x.Id == userId);
            return "Succsesfull deleted!";
        }

        public Post GetUser(string userId)
        {
            return _postTable.Find(x => x.Id == userId).FirstOrDefault();
           
        }
        
        public List<Post> GetUsers()
        {
            return _postTable.Find(FilterDefinition<Post>.Empty).ToList();
        }

        public void SaveOrUpdate(Post post)
        {
            var userObj = _postTable.Find(x => x.Id == post.Id).FirstOrDefault();
            if (userObj == null)
            {
                _postTable.InsertOne(post);
            }
            else
            {
                _postTable.ReplaceOne(x => x.Id == post.Id, post);
            }
        }
       
    }
}
