using System;
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
            connection = new SqlConnection(@"workstation id=belloapi.mssql.somee.com;packet size=4096;user id=hoangiao494041_SQLLogin_1;pwd=97y5uje1jc;data source=belloapi.mssql.somee.com;persist security info=False;initial catalog=belloapi");
        }
    }
}
