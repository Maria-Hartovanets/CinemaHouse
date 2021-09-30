using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp_firstProgram.Data;
using BlazorApp_firstProgram.IService;
using MongoDB.Driver;

namespace BlazorApp_firstProgram.Service
{
    public class ServiceStaff:IServiceObj<Staff>
    {
        private MongoClient _mongoClient = null;
        private IMongoCollection<Staff> _staffTable = null;
        private IMongoDatabase _database = null;

        public ServiceStaff()
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
            _database = _mongoClient.GetDatabase("CinemaDB");
            _staffTable = _database.GetCollection<Staff>("staff");
        }

        public string Delete(string userId)
        {
            _staffTable.DeleteOne(x => x.Id == userId);
            return "Succsesfull deleted!";
        }

        public Staff GetUser(string userId)
        {
            return _staffTable.Find(x => x.Id == userId).FirstOrDefault();
        }

        public List<Staff> GetUsers()
        {
            return _staffTable.Find(FilterDefinition<Staff>.Empty).ToList();
        }

       
        public void SaveOrUpdate(Staff person)
        {
            var userObj = _staffTable.Find(x => x.Id == person.Id).FirstOrDefault();
            if (userObj == null)
            {
                _staffTable.InsertOne(person);
            }
            else
            {
                _staffTable.ReplaceOne(x => x.Id == person.Id, person);
            }
        }
    }
}
