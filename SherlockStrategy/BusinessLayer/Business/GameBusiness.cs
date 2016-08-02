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

        public Game GetGameInfo(int Id)
        {

            var criterias = "Id='" + Id + "'";

            var returnObjects = IoC.Castle.Resolve<IGameRepository>().GetByCriterias("Game", criterias);

            List<Game> returnList = new List<Game>();
            returnList = ConvertToList<Game>(returnObjects);

            if (returnList.Count > 0)
            {
                var resultGame = returnList.FirstOrDefault();

                return resultGame;
            }
            else
            {
                return null;
            }
        }

        public EncounterArchive GetEncounterByPlayerId(int playerId, int GameId)
        {
            var criterias = "PlayerId='" + playerId + "' and GameId='" + GameId + "'";


            var returnObjects = IoC.Castle.Resolve<IGameRepository>().GetByCriterias("EncounterArchive", criterias);

            List<EncounterArchive> returnList = new List<EncounterArchive>();
            returnList = ConvertToList<EncounterArchive>(returnObjects);

            if (returnList.Count > 0)
            {
                var resultGame = returnList.LastOrDefault();

                return resultGame;
            }
            else
            {
                return null;
            }
        }

        public EncounterArchive GetEncounterById(int eId)
        {
            var criterias = "Id='" + eId + "'";


            var returnObjects = IoC.Castle.Resolve<IGameRepository>().GetByCriterias("EncounterArchive", criterias);

            List<EncounterArchive> returnList = new List<EncounterArchive>();
            returnList = ConvertToList<EncounterArchive>(returnObjects);

            if (returnList.Count > 0)
            {
                var resultGame = returnList.FirstOrDefault();

                return resultGame;
            }
            else
            {
                return null;
            }
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

        public List<EncounterArchive> OngoingGameList(int pId)
        {
            var criterias = "PlayerId='" + pId + "'";

            var returnObjects = IoC.Castle.Resolve<IGameRepository>().GetByCriterias("EncounterArchive", criterias);

            List<EncounterArchive> returnList = new List<EncounterArchive>();
            returnList = ConvertToList<EncounterArchive>(returnObjects);

            if (returnList.Count > 0)
            {
                return returnList.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<MoveArchive> GetMoveListByEncounter(int eId)
        {
            var criterias = "EncounterId='" + eId + "'";

            var returnObjects = IoC.Castle.Resolve<IGameRepository>().GetByCriterias("MoveArchive", criterias);

            List<MoveArchive> returnList = new List<MoveArchive>();
            returnList = ConvertToList<MoveArchive>(returnObjects);

            if (returnList.Count > 0)
            {
                return returnList.ToList();
            }
            else
            {
                return null;
            }
        }

        public void SaveEncounter(int PlayerId, int EncounterType, int Id)
        {

            var EncounterArchive = new EncounterArchive()
            {
                GameId = Id,
                EncounterType = EncounterType,
                MoveCount = 0,
                StartDate = DateTime.Now,
                PlayerId = PlayerId
            };

            IoC.Castle.Resolve<IGameRepository>().Insert(EncounterArchive);

        }

        public bool SaveMove(int eId, int MoveCellx, int MoveCelly, string CellValue)
        {
            try
            {
                var MoveArchive = new MoveArchive()
                {
                    EncounterId = eId,
                    MoveCellx = MoveCellx,
                    MoveCelly = MoveCelly,
                    CellValue = CellValue
                };

                var returnInsert = IoC.Castle.Resolve<IGameRepository>().Insert(MoveArchive);
                return returnInsert;
            }
            catch (Exception ex)
            {
                return false;
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
