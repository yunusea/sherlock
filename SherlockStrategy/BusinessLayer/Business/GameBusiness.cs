using Contracts;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLayer.Business
{
    public class GameBusiness
    {
        static string[,] board = new string[3, 3];

        public List<Game> GetAllGameList()
        {
            var entity = new Game();
            var returnEntities = IoC.Castle.Resolve<IGameRepository>().List(entity);

            List<Game> userList = new List<Game>();
            userList = ConvertToList<Game>(returnEntities);

            return userList;
        }

        public string GetBoard()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<div class=\"xoxGameContent\">");
            for (int i = 0; i < 3; i++)
            {
                builder.Append("<div class=\"xoxGameRow\">");
                for (int j = 0; j < 3; j++)
                {
                    builder.Append("<input type=\"submit\" class=\"xoxCell\" ng-click=\"fillCell(" + i + "," + j + ")\" name=\"cell" + i + "," + j + "\" value=\"" + board[i,j] + "\"  />");
                }
                builder.Append("</div>");
            }
            builder.Append("</div>");

            string innerString = builder.ToString();

            return innerString;
        }

        public bool CellControl(int x1, int x2)
        {
            var control = board[x1, x2];
            if (control == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CellSet(int playerType, int x1, int x2)
        {
            if (playerType == 1)
            {
                board[x1, x2] = "X";
            }
            else
            {
                board[x1, x2] = "O";
            }
        }

        public List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        pro.SetValue(objT, row[pro.Name]);
                    }
                }
                return objT;
            }).ToList();
        }
    }
}
