﻿using MeganMagoo.MongoDb.Core;
namespace MeganMagoo.Business.DataAccess.NoSqlDbContext
{
    public class BusinessModel_1 : IMongoEntity
    {
        public string Id { get; set; }
        public string BusinessModelName { get; set; }
    }
}
