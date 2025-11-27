using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Exercice2.DAO
{
    internal class DataConnection
    {
        private static readonly string connectionString = "Data Source=(localdb)\\CoursSQL;Initial Catalog=CoursSQL;Integrated Security=True";

        public static SqlConnection GetConnection => new(connectionString);
    }
}
