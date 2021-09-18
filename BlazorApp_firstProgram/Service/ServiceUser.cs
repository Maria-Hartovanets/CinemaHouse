using BlazorApp_firstProgram.Data;
using BlazorApp_firstProgram.IService;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_firstProgram.Service
{
    public class ServiceUser : IServiceObj<User>
    {
        private MongoClient _mongoClient = null;
        private IMongoCollection<User> _userTable = null;
        private IMongoDatabase _database = null;

        public ServiceUser()
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
            _database = _mongoClient.GetDatabase("CinemaDB");
            _userTable = _database.GetCollection<User>("users");
        }

        public string Delete(string userId)
        {
            _userTable.DeleteOne(x=>x.Id==userId);
            return "Succsesfull deleted!";
        }

        public User GetUser(string userId)
        {
            return _userTable.Find(x => x.Id == userId).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _userTable.Find(FilterDefinition<User>.Empty).ToList();
        }

        public void SaveOrUpdate(User user)
        {
            var userObj = _userTable.Find(x => x.Id == user.Id).FirstOrDefault();
            if (userObj == null)
            {
                _userTable.InsertOne(user);
            }
            else
            {
                _userTable.ReplaceOne(x => x.Id == user.Id, user);
            }
        }
    }
}
