using Contracts;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BusinessLayer.Business
{
    public class GeneralSettingBusiness
    {
        public void UpdateSetting(string ContractText)
        {
            var settingCriterList = "Id='1'";
            var settingSetList = "ContractText='" + ContractText + "'";
            var settingUpdateResult = IoC.Castle.Resolve<IGeneralSettingRepository>().SpecialUpdate("GeneralSetting", settingSetList, settingCriterList);

            if (settingUpdateResult)
            {
                var userSetList = "SingUpContractStatus='false'";
                var userCriterList = "Rol!='1' and SingUpContractStatus='true'";
                var userUpdateResult = IoC.Castle.Resolve<IGeneralSettingRepository>().SpecialUpdate("User", userSetList, userCriterList);
            }
        }

        public GeneralSetting GetContractText()
        {
            var criterias = "Id='1'";

            var returnObjects = IoC.Castle.Resolve<IGeneralSettingRepository>().GetByCriterias("GeneralSetting", criterias);

            List<GeneralSetting> returnList = new List<GeneralSetting>();
            returnList = ConvertToList<GeneralSetting>(returnObjects);

            if (returnList.Count > 0)
            {
                var resultUsert = returnList.FirstOrDefault();

                return resultUsert;
            }
            else
            {
                return null;
            }
        }

        public User UpdateContractTextChecked(int Id)
        {
            var TableName = "User";
            var SetList = "SingUpContractStatus='True'";
            var CriterList = "Id='" + Id + "'";
            var resultUserUpdate = IoC.Castle.Resolve<IGeneralSettingRepository>().SpecialUpdate(TableName, SetList, CriterList);

            if (resultUserUpdate)
            {
                var UserTableName = "User";
                var UserCriterList = "Id='" + Id + "'";
                var resultUserObject = IoC.Castle.Resolve<IGeneralSettingRepository>().GetByCriterias(UserTableName, UserCriterList);
                List<User> returnList = new List<User>();
                returnList = ConvertToList<User>(resultUserObject);

                if (returnList.Count > 0)
                {
                    var resultUser = returnList.FirstOrDefault();
                    return resultUser;
                }
                else
                {
                    throw new NotSupportedException("Beklenmedik Bir Problem İle Karşılaşıldı");
                }
            }
            else
            {
                throw new NotSupportedException("Sözleşme Durum Güncellemesi Başarılı Bir Şekilde Gerçekleştirilemedi !");
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
