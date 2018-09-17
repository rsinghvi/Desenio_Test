using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using SAFEBBA.Application.Web.Selenium;
using Com.Sogeti.Tests.DesenioTest.Object_Repository;
using Com.Sogeti.Tests.DesenioTest.Test_Cases;
using NUnit.Framework;
using SAFEBBA.LogMgn;
using BiW_IT_Test.Common_Function_Management;
using System.Data;
using System.Data.SqlClient;
////using SAFEBBA.ParameterAndUserDataMgn;
using System.Threading;
using SAFEBBA.Common_Function_Management;
using SAFEBBA.CommonFuncMgn;
using OpenQA.Selenium.Interactions;

namespace Com.Sogeti.Tests.DesenioTest.Test_Cases.English
{

    [TestClass]
    public class TC2_BuyInspirationRoom : SeleniumTestInitialize
    {
        


        [TestInitialize]
        public void Setup()
        {

            SeleniumSetup();
            WriteTestResultsExcel.setTestClassStart("Customer Journey Buy Inspiration Room", dateTime);

        }

        [TestCleanup]
        public void tearDown()
        {

            SeleniumQuit();
            WriteTestResultsExcel.setTestClassFinish("Customer Journey Buy Inspiration Room");

        }




        [TestMethod]        
        public void BuyInspirationRoom()
        {
            
            WriteTestResultsExcel.setTestCaseStart("Customer Journey Buy Inspirational Room", "Customer Journey Buy Inspirational Room");
            try
            {
                //Test Step 1
                {
                    WriteTestResultsExcel.setTestStepStart("Click on Inspiration in navbar on startpage", "Click on Inspiration in navbar on startpage");

                    String inspirationLinkLink = getDictionaryValue(Desenio_Test_Objects.INSPIRATION_LINK, "xpath");
                    operateOnWebDriverElement.ClickAnElementByXPath(inspirationLinkLink);                 
                    
                    WriteTestResultsExcel.setTestStepFinish("Pass", null);
                }

                //Test Step 2
                {
                    WriteTestResultsExcel.setTestStepStart("Click on the first inspiration room", "Click on the first inspiration room");

                    String roomLinkXpath = getDictionaryValue(Desenio_Test_Objects.ROOM_LINK, "xpath");
                    operateOnWebDriverElement.ClickAnElementByXPath(roomLinkXpath);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);
                }

                //Test Step 3
                {
                    WriteTestResultsExcel.setTestStepStart("Click on the Buy Container button", "Click on the Buy Container button");

                    String buyArticleButtonXpath = getDictionaryValue(Desenio_Test_Objects.BUY_BUTTON, "xpath");
                    operateOnWebDriverElement.ClickAnElementByXPath(buyArticleButtonXpath);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);
                }

                //Test Step 4
                {
                    WriteTestResultsExcel.setTestStepStart("Click on the Close window button", "Click on the Close window button");

                    String closeWindoeButtonXpath = getDictionaryValue(Desenio_Test_Objects.CLOSE_BUTTON, "id");
                    operateOnWebDriverElement.ClickAnElementById(closeWindoeButtonXpath);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);
                }

                //Test Step 5
                {
                    WriteTestResultsExcel.setTestStepStart("Till Kassan", "Till Kassan");

                    String kassanButtonId = getDictionaryValue(Desenio_Test_Objects.KASSAN_BUTTON, "id");
                    //operateOnWebDriverElement.ClickAnElementByClassName(checkOutButtonClass);
                    operateOnWebDriverElement.ClickAnElementById(kassanButtonId);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);
                }

                //Test Step 6
                {
                    WriteTestResultsExcel.setTestStepStart("Verify the Kassan page", "Verify the Kassan page");

                    String checkOutButtonXpath = getDictionaryValue(Desenio_Test_Objects.CHECKOUT_TEXT, "xpath");
                    //operateOnWebDriverElement.ClickAnElementByClassName(checkOutButtonClass);
                    String titleText = operateOnWebDriverElement.GetTextOnElementByXPath(checkOutButtonXpath);
                    Console.WriteLine(titleText);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);
                }



                // Finish Test Case
                WriteTestResultsExcel.setTestCaseFinish("Pass");
            }
            catch (Exception e)
            {

                WriteTestResultsExcel.setTestStepFinish("Fail", e);

                WriteTestResultsExcel.setTestCaseFinish("Fail");

                throw e;
            }

        } 

        

    }
 }

        