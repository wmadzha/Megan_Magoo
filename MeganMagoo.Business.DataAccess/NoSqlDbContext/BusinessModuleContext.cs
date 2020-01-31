using MeganMagoo.MongoDb.Core;

namespace MeganMagoo.Business.DataAccess.NoSqlDbContext
{

    public class BusinessModuleContext : MongoDBContext
    {
        public BusinessModuleContext(MongoDBProperties prop) : base(prop)
        {
        }
        public IMongoEntitySet<BusinessModel_1> Model_1 { get; set; }
        public IMongoEntitySet<BusinessModel_2> Model_2 { get; set; }
        protected override void SetupEntites()
        {
            this.Model_1 = new MongoEntitySet<BusinessModel_1>(this.Database());
            this.Model_2 = new MongoEntitySet<BusinessModel_2>(this.Database());
        }
    }
}
