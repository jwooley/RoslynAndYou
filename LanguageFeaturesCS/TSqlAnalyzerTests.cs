using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeaturesCS
{
    class TSqlAnalyzerTests
    {
        public void TestSqlCommand()
        {
            using (var cmd = new SqlCommand())
            {

                cmd.CommandText = "Select * from MyTable";
                cmd.CommandText = "This should not compile";

                var injectedValue = "' OR 1=1; --";
                cmd.CommandText = "Select * from SomeTable Where Field='" + injectedValue + "'";
            }
        }
    }
}
