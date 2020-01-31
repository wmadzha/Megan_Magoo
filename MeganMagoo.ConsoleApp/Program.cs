using System;
using MeganMagoo.MongoDb.Core;
using MeganMagoo.Business.DataAccess.NoSqlDbContext;
namespace MeganMagoo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Create Instance Mongodb Properties
            MongoDBProperties noSqlDb = new MongoDBProperties("mongodb://localhost:27017", "MeganMagooDb");
            // Instantiate Our Designed Context
            BusinessModuleContext dbContext = new BusinessModuleContext(noSqlDb);
            // Sample Business Model Object
            BusinessModel_1 sampleModel = new BusinessModel_1();
            sampleModel.BusinessModelName = "SampleName";
            // Add Them
            dbContext.Model_1.Add(sampleModel);
            var dataList = dbContext.Model_1.GetAll();
            foreach(var a in dataList)
            {
                Console.WriteLine(a.BusinessModelName);
            }

            BusinessModel_2 sampleModel2 = new BusinessModel_2();
            sampleModel2.BusinessModelName = "Name2";
            dbContext.Model_2.Add(sampleModel2);
            var dataList2 = dbContext.Model_1.GetAll();
            foreach (var a in dataList2)
            {
                Console.WriteLine(a.BusinessModelName);
            }


            Console.ReadLine();
        }
    }
}
