using Microsoft.Extensions.DependencyInjection;
using MeganMagoo.MongoDb.Core;
using MeganMagoo.Business.DataAccess.NoSqlDbContext;

namespace MeganMagoo.Usage
{
    public static class Builder
    {
        public static IServiceCollection SetupMongoEntities(this IServiceCollection svc, string ConnectionString, string DatabaseName)
        {
            MongoDBProperties noSqlDb = new MongoDBProperties(ConnectionString, DatabaseName);
            svc.AddScoped(noSqldb => new BusinessModuleContext(noSqlDb));
            return svc;
        }
    }
}
