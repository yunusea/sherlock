using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmLayer
{
    public class MsSql<T> : IDbOrm<T> where T : class
    {
        SqlConnection Conn = null;
        string _ConnectionString;

        public MsSql(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            Conn = new SqlConnection(_ConnectionString);
        }

        public IEnumerable<T> SelectDataList()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            var cmd = Conn.CreateCommand();

            List<string> columnList = new List<string>();
            List<string> parameterList = new List<string>();
            int i = 0;
            foreach (var property in typeof(T).GetProperties())
            {
                columnList.Add(property.Name);

                var parameterName = string.Format("@param{0}", i++);
                parameterList.Add(parameterName);

                cmd.Parameters.AddWithValue(parameterName, property.GetValue(entity));
            }

            string columnsPart = string.Join(", ", columnList);
            string parametersPart = string.Join(", ", parameterList);
            cmd.CommandText = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", typeof(T).Name, columnsPart, parametersPart);

        }

        public void Update(T entity, List<DataParameter> Criterias)
        {
            var cmd = Conn.CreateCommand();

            List<string> columnList = new List<string>();
            List<string> parameterList = new List<string>();
            int i = 0;
            foreach (var property in typeof(T).GetProperties())
            {
                columnList.Add(property.Name);

                var parameterName = string.Format("@param{0}", i++);
                parameterList.Add(parameterName);

                cmd.Parameters.AddWithValue(parameterName, property.GetValue(entity));
            }

            string columnsPart = string.Join(",", columnList);
            string parametersPart = string.Join(", ", parameterList);

        

            cmd.CommandText = string.Format("UPDATE {0} SET {1}@={2}", typeof(T).Name, columnsPart, parametersPart);

            foreach (var property in typeof(T).GetProperties())
            {
                columnList.Add(property.Name);

                var parameterName = string.Format("@param{0}", i++);
                parameterList.Add(parameterName);

                cmd.Parameters.AddWithValue(parameterName, property.GetValue(entity));
            }
            List<DataParameter> props;
            foreach (var p in typeof(T).GetProperties())
            {
                props.Add(new DataParameter {Name = p, Value= p, Type = p.GetType() });
            }

            foreach (DataParameter p in )
            {
                Command += p.Name + " = @" + p.Name + ", ";
            }
            Command = Command.Trim().TrimEnd(',');
            Command += " WHERE ";
            foreach (DataParameter c in Criterias)
            {
                Command += c.Name + "= @" + c.Name + ", ";
            }
            Command = Command.Trim().TrimEnd(',');
            using (Conn)
            {
                SqlCommand _COMMAND = new SqlCommand(Command, Conn);
                foreach (DataParameter item in typeof(T).GetProperties())
                {
                    _COMMAND.Parameters.Add(new SqlParameter() { Value = item.Value, ParameterName = item.Name, DbType = item.Type });
                }
                foreach (DataParameter item in Criterias)
                {
                    _COMMAND.Parameters.Add(new SqlParameter() { Value = item.Value, ParameterName = item.Name, DbType = item.Type });
                }
                Conn.Open();
                _COMMAND.ExecuteNonQuery();
            }
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
