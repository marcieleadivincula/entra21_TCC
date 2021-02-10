using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class DBConfig
    {
        //public const string CONNECTION_STRING = @"server=localhost;user id=root;database=sorrisempre";

        //public const string CONNECTION_STRING = @"server=localhost;user id=root;persistsecurityinfo=True;database=odontotech;pwd=Lookaa123";

        public const string CONNECTION_STRING = @"server=localhost;user id=root;persistsecurityinfo=True;database=sorrisempre;pwd=";


        public static MySqlCommand Cmd;
        public static MySqlDataReader Reader;
    }
}
