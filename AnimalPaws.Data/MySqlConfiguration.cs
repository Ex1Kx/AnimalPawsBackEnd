using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPaws.Data
{
    public class MySqlConfiguration
    {
    public MySqlConfiguration(string connectionString) => ConnectionString = connectionString;
    public string ConnectionString { get; set; }
    }
}
