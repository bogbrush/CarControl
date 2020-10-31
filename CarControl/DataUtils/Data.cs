using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Data<T>
    {
        protected virtual T Populate(SqlDataReader reader)
        {
            return default(T);
        }

        protected string ClassName()
        {
            var className = typeof(T).Name;
            return className;
        }

        public List<T> SelectAll()
        {
 
            List<T> list = new List<T>();
            var reader = Database.ExecuteQuery("usp_" + ClassName() + "Select");

            while (reader.Read())
            {
                list.Add(Populate(reader));
            }
            reader.Close();
            return list;
        }

        public T SelectByID(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ID", id }
            };

            var reader = Database.ExecuteQuery("usp_" + ClassName() + "Select", parameters);

            if (reader.Read())
            {
                var x = Populate(reader);
                reader.Close();
                return x;
            }

            else
                return default(T);
        }

        public void DeleteByID(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ID", id }
            };

            Database.ExecuteNonQuery("usp_" + ClassName() + "Delete", parameters);
        }
    }
}
