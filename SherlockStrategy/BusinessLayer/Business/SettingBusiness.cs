using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Business
{
    public class SettingBusiness
    {
        public void UpdateSetting(string ContractText)
        {
            var settingCriterList = "Id='1'";
            var settingSetList = "ContractText='" + ContractText + "'";
            var settingUpdateResult = IoC.Castle.Resolve<IUserRepository>().SpecialUpdate("GeneralSetting", settingSetList, settingCriterList);

            if (settingUpdateResult)
            {
                var userSetList = "SingUpContractStatus='false'";
                var userCriterList = "Rol!='1' and SingUpContractStatus='true'";
                var userUpdateResult = IoC.Castle.Resolve<IUserRepository>().SpecialUpdate("User", userSetList, userCriterList);

            }
        }
    }
}
