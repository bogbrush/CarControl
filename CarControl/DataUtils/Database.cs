using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DataAccess
{
    public class Database
    {

        private static string SqlConnectionString = @"server=??;Initial Catalog=??;user=??; password=?????";

        /// <summary>
        /// Executes a Stored Procedure
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteQuery(string storedProcedureName)
        {
            return ExecuteQuery(storedProcedureName, new Dictionary<string, object>());
        }

        /// <summary>
        /// Executes a Stored Procedure
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteQuery(string storedProcedureName, Dictionary<string,object> parameters)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString);
            SqlCommand command = new SqlCommand(storedProcedureName, connection);
  
            SqlDataReader reader = null;

            command.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> parameter in parameters) 
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }
            try
            {
                connection.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                try
                {
                    connection.Close();
                }
                catch
                {

                }

                // TODO need to log this
                throw ex; 
            }
            return reader;
        }

        /// <summary>
        /// Executes a Stored Procedure with no results
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters"></param>
        public static void ExecuteNonQuery(string storedProcedureName, Dictionary<string, object> parameters)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString);
            SqlCommand command = new SqlCommand(storedProcedureName, connection);

            command.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, (parameter.Value == null)?DBNull.Value:parameter.Value);
            }
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (System.Exception ex)
            {
                // TODO need to log this
                throw ex; 
            }
      
        }




    }

}