using MeganMagoo.Business.DataAccess.NoSqlDbContext;
using System.Collections.Generic;
namespace MeganMagoo.Usage
{
    public class MySimpleUsage
    {
        public MySimpleUsage(BusinessModuleContext NoSqlDbContext)
        {
            // Sample Get
            List<BusinessModel_1> modellist1 = NoSqlDbContext.Model_1.GetAll();

            // Sample Add
            BusinessModel_2 sampleData = new BusinessModel_2();
            sampleData.BusinessModelName = "SampleName";
            var result = NoSqlDbContext.Model_2.Add(sampleData);
        }
    }
}
