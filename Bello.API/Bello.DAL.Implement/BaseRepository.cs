﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Bello.DAL.Implement
{
    public class BaseRepository
    {
        protected IDbConnection connection;
        public BaseRepository()
        {
            connection = new SqlConnection(@"Data Source=tri\sqlexpress;Initial Catalog=BelloAPIDb;Integrated Security=True");
        }
    }
}
