using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;


namespace DBMS.src
{
    class Mongo
    {
        private IMongoDatabase db;

        public Mongo(string database)
        {

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://olena:<password>@cluster0.fyfl3mr.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            db = client.GetDatabase(database);

        }
        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }
        public List<string> GetCollectionNames()
        {
            return db.ListCollectionNames().ToList();
        }
        public IMongoCollection<BsonDocument> GetCol(string tName)
        {
            return db.GetCollection<BsonDocument>(tName);
        }
    }
}
