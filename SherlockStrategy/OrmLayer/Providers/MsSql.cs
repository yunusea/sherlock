using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrmLayer.Providers
{
    public class MsSql : IDbOrm
    {
        SqlConnection conn = null;
        string _ConnectionString;

        public MsSql(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            conn = new SqlConnection(_ConnectionString);
        }

        public void Insert(object entity)
        {
            //SELECT * FROM table_name (column_name)values(parameter_name)

            Type myType = entity.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            var cmd = conn.CreateCommand();

            List<string> columnList = new List<string>();
            List<string> parameterList = new List<string>();
            foreach (var property in props)
            {
                if (property.GetCustomAttributes(true).OfType<KeyAttribute>().Any())
                {
                    continue;
                }

                columnList.Add(property.Name);

                var parameterName = string.Format("@{0}", property.Name);
                parameterList.Add(parameterName);

                cmd.Parameters.AddWithValue(parameterName, property.GetValue(entity));
            }

            string columnsPart = string.Join(",", columnList);
            string parametersPart = string.Join(",", parameterList);
            cmd.CommandText = string.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", myType.Name, columnsPart, parametersPart);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.ExecuteNonQuery();
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public IEnumerable<object> AllList(object entity)
        {
            //SELECT * FROM table_name

            DataTable dt = new DataTable();

            List<object> list = new List<object>();
            try
            {
                Type myType = entity.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

                var cmd = conn.CreateCommand();

                conn.Open();

                cmd.CommandText = string.Format("SELECT * FROM [{0}]", myType.Name);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                list.Add(dt.AsEnumerable().ToList());


                conn.Close();
                conn.Dispose();

            }
            catch (Exception ex)
            {
                conn.Close();
                throw;
            }

            return list;

        }

        public void Delete(object entity)
        {
            throw new NotImplementedException();
        }

        public void Update(object entity, List<DataParameter> Criterias)
        {
            //UPDATE table_name SET column_name=@parameter_name WHERE criterias=@criter

            var cmd = conn.CreateCommand();

            List<string> setList = new List<string>();
            List<string> parameterList = new List<string>();
            foreach (var property in typeof(object).GetProperties())
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

            cmd.CommandText = string.Format("UPDATE {0} SET {1} WHERE {2}", typeof(object).Name, setList, criteriasList);
            cmd.ExecuteNonQuery();

        }

    }
}
