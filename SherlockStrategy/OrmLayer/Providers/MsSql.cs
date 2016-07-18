using Models.Model;
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
        }

        public void Insert(object entity)
        {
            //SELECT * FROM table_name (column_name)values(parameter_name)

            conn = new SqlConnection(_ConnectionString);
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
            }
        }

        public DataTable AllList(object entity)
        {
            //SELECT * FROM table_name

            conn = new SqlConnection(_ConnectionString);
            DataTable dt = new DataTable();

            try
            {
                Type myType = entity.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

                var cmd = conn.CreateCommand();

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.CommandText = string.Format("SELECT * FROM [{0}]", myType.Name);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                throw;
            }

            return dt;

        }

        public void Delete(object entity)
        {
            //DELETE FROM table_name WHERE col_name=entityvalue

            conn = new SqlConnection(_ConnectionString);
            Type myType = entity.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            var cmd = conn.CreateCommand();

            List<string> columnList = new List<string>();
            List<object> ValuesList = new List<object>();
            foreach (var property in props)
            {
                if (property.GetCustomAttributes(true).OfType<KeyAttribute>().Any())
                {
                    columnList.Add(property.Name);
                    ValuesList.Add(property.GetValue(entity));
                }

            }

            string columnsPart = string.Join(",", columnList);
            string parametersPart = string.Join(",", ValuesList);
            cmd.CommandText = string.Format("DELETE FROM [{0}] WHERE {1}={2}", myType.Name, columnsPart, parametersPart);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.ExecuteNonQuery();
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public void Update(object entity, string Criterias)
        {
            //UPDATE table_name SET column_name=@parameter_name WHERE criterias=@criter

            conn = new SqlConnection(_ConnectionString);
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


            cmd.CommandText = string.Format("UPDATE {0} SET {1} WHERE {2}", typeof(object).Name, setList, Criterias);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.ExecuteNonQuery();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }

        }

        public void SpecialUpdate(string TableName, string SetList, string CriterList)
        {
            //UPDATE table_name SET column_name=@parameter_name WHERE criterias=@criter

            conn = new SqlConnection(_ConnectionString);
            var cmd = conn.CreateCommand();

            cmd.CommandText = string.Format("UPDATE [{0}] SET {1} WHERE {2}", TableName, SetList, CriterList);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.ExecuteNonQuery();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public DataTable GetByCriterias(string TableName, string CriteriasText)
        {
            //SELECT * FROM table_name WHERE col_name=entityvalue

            conn = new SqlConnection(_ConnectionString);
            DataTable dt = new DataTable();

            try
            {
                var cmd = conn.CreateCommand();

                cmd.CommandText = string.Format("SELECT * FROM [{0}] WHERE {1}", TableName, CriteriasText);


                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                throw;
            }

            return dt;
        }
    }
}
