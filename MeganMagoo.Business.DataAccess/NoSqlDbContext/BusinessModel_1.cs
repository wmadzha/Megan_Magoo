using MeganMagoo.MongoDb.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MeganMagoo.Business.DataAccess.NoSqlDbContext
{
    public class BusinessModel_1 : IMongoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string BusinessModelName { get; set; }
    }
}
