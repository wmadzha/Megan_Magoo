using System;
using System.Collections.Generic;
using System.Text;

namespace MeganMagoo.MongoDb.Core
{
    public class MongoDBProperties
    {
        public MongoDBProperties(string ConnectionString, string DatabaseName)
        {
            this.ConnectionString = ConnectionString;
            this.DatabaseName = DatabaseName;
        }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
