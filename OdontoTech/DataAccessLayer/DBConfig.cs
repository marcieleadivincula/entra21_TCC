﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DBConfig
    {
        public const string CONNECTION_STRING = @"server=localhost;user id=root;database=sorrisempre";
        public static SqlCommand Cmd;
        public static SqlDataReader Reader;
    }
}
