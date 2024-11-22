using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM = System.Configuration.ConfigurationManager;

namespace GamesCollectionManagment
{
    public static class DataAccess
    {
        private static string connectionString = CM.ConnectionStrings["Default"].ConnectionString;

        /// <summary>
        /// Gets a DataTable filled with the result of the query provided by the sql statement
        /// </summary>
        /// <param name="sql">The select statment to execute</param>
        /// <returns>DataTable of the results</returns>
        public static DataTable GetData(string sql)
        {
            DataTable dt = new();

            using (SqlConnection conn = new(connectionString))
            {
                using (SqlCommand cmd = new(sql, conn))
                {
                    using (SqlDataAdapter da = new(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }// Close and Dispose of the SQL Connection

            return dt;
        }

        /// <summary>
        /// Gets a DataSet of DataTables for each supplied query
        /// </summary>
        /// <param name="sqlStatements">The sql statements to execute</param>
        /// <returns>A DataSet of DataTables for each supplied query</returns>
        public static DataSet GetData(string[] sqlStatements)
        {
            DataSet ds = new();

            using (SqlConnection conn = new(connectionString))
            {
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = string.Join(";", sqlStatements);

                    using (SqlDataAdapter da = new(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }

            return ds;
        }

        /// <summary>
        /// Execure Scalar. Returns the first column of the first row of the provided query
        /// 
        /// Useful for aggregate queries or a single column for a single record
        /// </summary>
        /// <param name="sql">The sql statement to execute</param>
        /// <returns>Scalar always returns an object</returns>
        public static object GetValue(string sql)
        {
            object returnValue = null;

            using (SqlConnection conn = new(connectionString))
            {
                using (SqlCommand cmd = new(sql, conn))
                {
                    conn.Open();
                    returnValue = cmd.ExecuteScalar();
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Support for execute non-query sql statements (DML or DDL)
        /// </summary>
        /// <param name="sql">The Non-query sql statement to execute</param>
        /// <returns>Number of rows affected by the statement execution</returns>
        public static int ExecuteNonQuery(string sql)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new(connectionString))
            {
                using (SqlCommand cmd = new(sql, conn))
                {
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
    }
}
