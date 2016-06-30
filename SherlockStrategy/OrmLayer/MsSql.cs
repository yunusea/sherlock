using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OrmLayer
{
    public class MsSql<T> : IDbOrm<T> where T : class
    {
        SqlConnection conn = null;
        string _ConnectionString;

        public MsSql(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            conn = new SqlConnection(_ConnectionString);
        }

        public void Insert(T entity)
        {
            //SELECT * FROM table_name (column_name)values(parameter_name)

            var cmd = conn.CreateCommand();

            List<string> columnList = new List<string>();
            List<string> parameterList = new List<string>();
            foreach (var property in typeof(T).GetProperties())
            {
                columnList.Add(property.Name);

                var parameterName = string.Format("@{0}", property.Name);
                parameterList.Add(parameterName);

                cmd.Parameters.AddWithValue(parameterName, property.GetValue(entity));
            }

            string columnsPart = string.Join(", ", columnList);
            string parametersPart = string.Join(", ", parameterList);
            cmd.CommandText = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", typeof(T).Name, columnsPart, parametersPart);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();

        }

        public void Update(T entity, List<DataParameter> Criterias)
        {
            //UPDATE table_name SET column_name=@parameter_name WHERE criterias=@criter

            var cmd = conn.CreateCommand();

            List<string> setList = new List<string>();
            List<string> parameterList = new List<string>();
            foreach (var property in typeof(T).GetProperties())
            {
                var setName = string.Format("{0}=@{0}, ", property.Name);
                setList.Add(setName);
                var parameterName = string.Format("@{0}", property.Name);
                parameterList.Add(parameterName);

                cmd.Parameters.AddWithValue(parameterName, property.GetValue(entity));
            }

            List<string> criteriasList = new List<string>();
            foreach (var c in Criterias)
            {
                var criteriasName = string.Format("{0}=@{0}", c.Name);
                criteriasList.Add(criteriasName);
            }

            cmd.CommandText = string.Format("UPDATE {0} SET {1} WHERE {2}", typeof(T).Name, setList, criteriasList);
            cmd.ExecuteNonQuery();

        }

        public IEnumerable<T> SelectDataList()
        {
            //SELECT * FROM table_name

            var cmd = conn.CreateCommand();

            cmd.CommandText = string.Format("SELECT * FROM {0}",typeof(T).Name);
            return null;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
