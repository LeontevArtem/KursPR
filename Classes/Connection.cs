using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Classes
{
    public  class Connection
    {
        public static MySqlDataReader Query(string querySQL, MySqlConnection mySqlConnection)
        {

            MySqlCommand mySqlCommand = new MySqlCommand(querySQL, mySqlConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            return mySqlDataReader;
        }
    }
}
