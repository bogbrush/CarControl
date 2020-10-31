using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CommandData : Data<Command>
    {
        protected override Command Populate(SqlDataReader reader)
        {
            var command = new Command();

            command.Id = Convert.ToInt32(reader["ID"]);

            if (reader["PayLoad"] != DBNull.Value)
                command.PayLoad = Convert.ToString(reader["PayLoad"]);

            if (reader["RequestDate"] != DBNull.Value) 
                command.RequestDate = Convert.ToDateTime(reader["RequestDate"]);

            if (reader["CompleteDate"] != DBNull.Value)
                command.CompleteDate = Convert.ToDateTime(reader["CompleteDate"]);

            return command;
        }

        public void Create(Command command)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@PayLoad", command.PayLoad);
            parameters.Add("@RequestDate", command.RequestDate);
            parameters.Add("@CompleteDate", command.CompleteDate);
            Database.ExecuteNonQuery("usp_" + ClassName() + "Insert", parameters);
        }

        public void Update(Command command)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@Id", command.Id);
            parameters.Add("@PayLoad", command.PayLoad);
            parameters.Add("@RequestDate", command.RequestDate);
            parameters.Add("@CompleteDate", command.CompleteDate);
            Database.ExecuteNonQuery("usp_" + ClassName() + "Update", parameters);
        }
    }
}