using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAFEBBA.LogMgn;
using SAFEBBA.CommonFuncMgn;
using SAFEBBA.Application.Web.Selenium;

namespace SAFEBBA.WindowManagement.DriverRelatedWindowMgn
{
    class WindowsSecurityWindow : SeleniumTestInitialize
    {
        string WINDOW_WINDOWS_SECURITY = "Windows Security";
        //private  string FIELD_USER_NAME = "User name";
        //private string FIELD_PASSWORD = "Password";
        private string BUTTON_OK = "OK";


        public void FieldUserNameInsert(params string[] userName)
        {
            string name = SAFEBBALog.TestStep(CommonUtilities.GetClassAndMethodName(), userName);
            //operateOnWhiteElements.InsertInToHiddenFieldByIndex(WINDOW_WINDOWS_SECURITY, 0, name);
        }

        public void FieldPasswordInsert(params string[] userPassWord)
        {
           // string passWrd = Encryption.Decrypt(SAFEBBALog.TestStep(CommonUtilities.GetClassAndMethodName(), userPassWord));
            //operateOnWhiteElements.InsertInToHiddenFieldByIndex(WINDOW_WINDOWS_SECURITY, 1, passWrd);
        }

        public void ButtonOkClick()
        {
            SAFEBBALog.TestStep(CommonUtilities.GetClassAndMethodName());
            //operateOnWhiteElements.ClickButtonByName(WINDOW_WINDOWS_SECURITY, BUTTON_OK);
        }
    }
}
