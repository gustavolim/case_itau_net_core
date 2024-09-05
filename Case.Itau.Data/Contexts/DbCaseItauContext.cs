using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Itau.Data.Contexts
{
    public class DbCaseItauContext : DataConnection
    {
        public DbCaseItauContext(string connectionString) : base(connectionString)
        {
        }
    }
}