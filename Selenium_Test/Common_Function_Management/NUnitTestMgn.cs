using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAFEBBA;
using SAFEBBA.WindowManagement;
using System.Configuration;
using NUnit.Core;
using NUnit.Core.Extensibility;
using SAFEBBA.LogMgn;
using SAFEBBA.ParameterAndUserDataMgn;
using System.IO;

namespace SAFEBBA.CommonFuncMgn
{
    [NUnitAddin(Name = "Screenshot on Error Addin", Description = "This Addin takes a screenshot if a test fails or has an error.")]
    public class NUnitTestManager :IAddin, EventListener
    {

        #region IAddin Members
        string failedTestCasesToReRun="";

        public bool Install(IExtensionHost host)
        {
            IExtensionPoint listeners = host.GetExtensionPoint("EventListeners");
            if (listeners == null)
                return false;

            listeners.Install(new NUnitTestManager());
            return true;
        }

        #endregion

        #region EventListener Members

        bool isScreenShotTaken;


        public void TestFinished(TestResult result)
        {
            SAFEBBALog.Info(CommonUtilities.GetClassAndMethodName());
            CreatScreenShotOnFailure(result);
            SAFEBBALog.TestCaseEnd(result);
        }

        public void RunFinished(Exception exception)
        {
            SAFEBBALog.Info(CommonUtilities.GetClassAndMethodName());
        }

        public void RunFinished(TestResult result)
        {
            SAFEBBALog.Info(CommonUtilities.GetClassAndMethodName());
            createReRunFailesTestCaseFile();
        }

        public void RunStarted(string name, int testCount)
        {
            SAFEBBALog.Info(CommonUtilities.GetClassAndMethodName());
            failedTestCasesToReRun += ConfigParameters.PATH_NUNIT_PACKAGE_CONSOLE_EXE;
            SAFEBBALog.TotalNumberOfTestsToRun = testCount;
            SAFEBBALog.PrintApplicationConfigurations();
        }

        public void SuiteFinished(TestResult result)
        {
            SAFEBBALog.Info(CommonUtilities.GetClassAndMethodName());
            if (SAFEBBALog.NumberOfExecutedTests==0 && !isScreenShotTaken)
            {
                CreatScreenShotOnFailure(result);
            }
                
        }

        public void SuiteStarted(TestName testName)
        {
            SAFEBBALog.Info(CommonUtilities.GetClassAndMethodName());
            isScreenShotTaken = false;
        }

        public void TestOutput(TestOutput testOutput)
        {
        }

        public void TestStarted(TestName testName)
        {
            SAFEBBALog.Info(CommonUtilities.GetClassAndMethodName());
        }

        public void UnhandledException(Exception exception)
        {
        }

        /// <summary>
        /// Create a screen shot when a test case fail
        /// The screen shot is saved in 
        /// </summary>
        /// <param name="result"></param>
        private void CreatScreenShotOnFailure(TestResult result)
        {
            SAFEBBALog.Info(CommonUtilities.GetClassAndMethodName());
            SAFEBBALog.IsPreviousTestCaseSucceeded = true;
            string fullname = result.FullName;
            if (result.ResultState == ResultState.Error || result.ResultState == ResultState.Failure)
            {
                
                string testCaseName = result.Name;
                string fullNameWithoutTestCaseName = fullname.Substring(0, (fullname.Length - testCaseName.Length - 1));
                int startIndexForTestClass = fullNameWithoutTestCaseName.LastIndexOf(".");
                string testClassName = fullNameWithoutTestCaseName.Substring(startIndexForTestClass + 1);
                string fullFolderPath = CommonUtilities.CreateFolder("bin\\Debug\\ScreenShots\\" + testClassName);
                string imageFullPathAndName = fullFolderPath + "\\" + testCaseName + CommonUtilities.GetCurrentDate() + ".png";
                CommonUtilities.CreateAndSaveScreenShot(imageFullPathAndName);
                
                isScreenShotTaken = true;
                SAFEBBALog.IsPreviousTestCaseSucceeded = false;
                failedTestCasesToReRun += fullname +",";
              }
           
        }

        /// <summary>
        /// Create a file that contains the commandline in order to be able rerun the failed test cases 
        /// </summary>
        private void createReRunFailesTestCaseFile()
        {
            string projectName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string p = " " + projectName + ConfigParameters.PATH_SAF_DLL_BIN_DEBUG + projectName + ".dll";
            failedTestCasesToReRun += p;
            failedTestCasesToReRun = failedTestCasesToReRun.Replace("\\", @"\");
            string reRunFialdTestCasesFolderPath = ConfigParameters.PATH_RERUN_FAILED_TEST_CASES_FOLDER + ConfigParameters.ENVIRONMENT;
            bool exists = Directory.Exists(reRunFialdTestCasesFolderPath);

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(reRunFialdTestCasesFolderPath);
            }
            File.WriteAllText(reRunFialdTestCasesFolderPath + @"\ReRunFailedTestCases"+ CommonUtilities.GetCurrentDate()+".bat", failedTestCasesToReRun);
            File.WriteAllText(reRunFialdTestCasesFolderPath + @"\ReRunFailedTestCases_Latest.bat", failedTestCasesToReRun);
        }
    }
        #endregion
}
