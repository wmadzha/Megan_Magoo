using MongoDB.Driver;
using System.Collections.Generic;
namespace MeganMagoo.MongoDb.Core
{
    public abstract class MongoDBContext
    {
        protected abstract void SetupEntites();

        private MongoClient _Client { get; set; }
        private IMongoDatabase _Database { get; set; }
        public MongoDBContext(MongoDBProperties prop) : this(prop.ConnectionString, prop.DatabaseName)
        {

        }
        public MongoDBContext(string ConnectionString, string DatabaseName)
        {
            _Client = new MongoClient(ConnectionString);
            _Database = _Client.GetDatabase(DatabaseName);
        }
        protected IMongoDatabase Database()
        {
            return _Database;
        }
    }

    public interface IMongoEntity
    {
        string Id { get; set; }
    }
    public interface IMongoEntitySet<T> where T : IMongoEntity
    {
        T GetById(string entityId);
        List<T> GetAll();
        T Add(T entity);
        bool AddOrReplace(T entity);
        bool Delete(T entity);
        bool Delete(string entityId);
        bool Edit(T entity);
    }
    public class MongoEntitySet<T> : IMongoEntitySet<T> where T : IMongoEntity
    {
        private string _CollectionName { get; set; }
        private IMongoCollection<T> _Collection { get; set; }
        private IMongoDatabase _Database { get; set; }
        public MongoEntitySet(IMongoDatabase Database)
        {
            this._Database = Database;
            this._CollectionName = typeof(T).Name;
            _Collection = _Database.GetCollection<T>(this._CollectionName);
            if (_Collection == null)
            {
                _Database.CreateCollection(_CollectionName);
                _Collection = _Database.GetCollection<T>(this._CollectionName);
            }
        }
        public T Add(T entity)
        {
            _Collection.InsertOne(entity);
            return entity;
        }
        public bool AddOrReplace(T entity)
        {
            var check = _Collection.Find<T>(x => x.Id == entity.Id);
            if (check == null)
                _Collection.InsertOne(entity);
            else
                _Collection.ReplaceOne(x => x.Id == entity.Id, entity);
            return true;
        }
        public bool Delete(T entity)
        {
            _Collection.DeleteOne(x => x.Id == entity.Id);
            return true;
        }
        public bool Delete(string entityId)
        {
            _Collection.DeleteOne(x => x.Id == entityId);
            return true;
        }
        public bool Edit(T entity)
        {
            _Collection.ReplaceOne(x => x.Id == entity.Id, entity);
            return true;
        }
        public List<T> GetAll()
        {
            return _Collection.Find(x => true).ToList();
        }
        public T GetById(string entityId)
        {
            return _Collection.Find<T>(x => x.Id == entityId).FirstOrDefault();
        }
    }
}
