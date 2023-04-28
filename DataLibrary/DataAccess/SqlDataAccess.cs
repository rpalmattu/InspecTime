using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "NCPR_PROG1")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(String sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(String sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public static int GetMax(string sqlMax)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                List<string> maxQuery = cnn.Query<string>(sqlMax).ToList();

                foreach (string Row in maxQuery)
                {
                    return int.Parse(Row);
                }
                return 0;

            }
        }


        public static int ReturnTool<T>(String sqlDelete, String sqlInsert, T data)
        {

            ////Get max ID
            //string sqlMax = @"SELECT Max(ID) AS ID FROM dbo.Tool_Move;";

            //using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            //{
            //    List<T> maxQuery = cnn.Query<T>(sqlMax).ToList();
            //    int max = maxQuery<;


            //}



            int returnStatus = 0;
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                returnStatus = cnn.Execute(sqlDelete, data);
            }



            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return returnStatus & cnn.Execute(sqlInsert, data);
            }


        }




    }
}
