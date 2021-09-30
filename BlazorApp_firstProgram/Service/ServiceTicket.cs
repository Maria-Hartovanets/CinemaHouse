using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp_firstProgram.Data;
using BlazorApp_firstProgram.IService;
using MongoDB.Driver;

namespace BlazorApp_firstProgram.Service
{
    public class ServiceTicket:IServiceObj<Ticket>
    {
        private MongoClient _mongoClient = null;
        private IMongoCollection<Ticket> _ticketTable = null;
        private IMongoDatabase _database = null;

        public ServiceTicket()
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
            _database = _mongoClient.GetDatabase("CinemaDB");
            _ticketTable = _database.GetCollection<Ticket>("ticket");
        }

        public string Delete(string userId)
        {
            _ticketTable.DeleteOne(x => x.Id == userId);
            return "Succsesfull deleted!";
        }

        public Ticket GetUser(string userId)
        {
            return _ticketTable.Find(x => x.Id == userId).FirstOrDefault();
        }

        public List<Ticket> GetUsers()
        {
            return _ticketTable.Find(FilterDefinition<Ticket>.Empty).ToList();
        }

      

        public void SaveOrUpdate(Ticket tickt)
        {
            var userObj = _ticketTable.Find(x => x.Id == tickt.Id).FirstOrDefault();
            if (userObj == null)
            {
                _ticketTable.InsertOne(tickt);
            }
            else
            {
                _ticketTable.ReplaceOne(x => x.Id == tickt.Id, tickt);
            }
        }
    }
}
