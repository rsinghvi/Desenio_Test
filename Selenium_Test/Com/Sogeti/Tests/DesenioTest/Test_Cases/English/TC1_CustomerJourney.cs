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
    public class TC1_CustomerJourney : SeleniumTestInitialize
    {
        


        [TestInitialize]
        public void Setup()
        {

            SeleniumSetup();
            WriteTestResultsExcel.setTestClassStart("Customer Journey", dateTime);

        }

        [TestCleanup]
        public void tearDown()
        {

            SeleniumQuit();
            WriteTestResultsExcel.setTestClassFinish("Customer Journey");

        }




        [TestMethod]        
        public void CustomerJourney()
        {
            
            WriteTestResultsExcel.setTestCaseStart("Customer Journey", "Customer Journey");
            try
            {
                //Test Step 1
                {
                    WriteTestResultsExcel.setTestStepStart("Click on Nyheter in navbar on startpage", "Click on Nyheter in navbar on startpage");

                    String nyheterLinkXpath = getDictionaryValue(Desenio_Test_Objects.NYHETER_LINK, "xpath");
                    operateOnWebDriverElement.ClickAnElementByXPath(nyheterLinkXpath);                 
                    
                    WriteTestResultsExcel.setTestStepFinish("Pass", null);
                }

                //Test Step 2
                {
                    WriteTestResultsExcel.setTestStepStart("Click on the first article", "Click on the first article");

                    String articleLinkId = getDictionaryValue(Desenio_Test_Objects.ARTICLE_LINK, "id");
                    String articleLinkText = getDictionaryValue(Desenio_Test_Objects.ARTICLE_LINK, "text");
                  //  operateOnWebDriverElement.ClickAnElementByLinkText(articleLinkText);
                 //   driver.FindElement(By.PartialLinkText("Poppy")).Click();
                    clickLinkText(articleLinkId, articleLinkText);


                    WriteTestResultsExcel.setTestStepFinish("Pass", null);
                }

                //Test Step 3
                {
                    WriteTestResultsExcel.setTestStepStart("Add the article to shopping bag", "Add the article to shopping bag");

                    String addArticleButtonId = getDictionaryValue(Desenio_Test_Objects.ADDITEM_BUTTON, "id");
                    String addArticleButtonText = getDictionaryValue(Desenio_Test_Objects.ADDITEM_BUTTON, "text");
                    clickTableLink(addArticleButtonId, addArticleButtonText);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);
                }

                //Test Step 4
                {
                    WriteTestResultsExcel.setTestStepStart("Till Kassan", "Till Kassan");

                    String checkOutButtonClass = getDictionaryValue(Desenio_Test_Objects.CHECKOUT_BUTTON, "xpath");
                    //operateOnWebDriverElement.ClickAnElementByClassName(checkOutButtonClass);
                    operateOnWebDriverElement.ClickAnElementByXPath(checkOutButtonClass);

                    WriteTestResultsExcel.setTestStepFinish("Pass", null);
                }

                //Test Step 5
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

        //// Click the menu from the left side of the panel
        //public void clickLinkText(String id, String param)
        //{

        //    IWebElement webelement = findWebDriverElement.waitForElementById(null, null, id);
        //    Boolean flag = false;
        //    IReadOnlyCollection<IWebElement> elementLiList = webelement.FindElements(By.TagName("ul"));
        //    try
        //    {
        //        foreach (IWebElement elementLi in elementLiList)
        //        {
        //            IReadOnlyCollection<IWebElement> elementUlList = elementLi.FindElements(By.TagName("li"));

        //            foreach (IWebElement elementUl in elementUlList)
        //            {
        //                IReadOnlyCollection<IWebElement> elementList = elementUl.FindElements(By.TagName("div"));

        //                foreach (IWebElement subelementList in elementList)
        //                {
        //                    IReadOnlyCollection<IWebElement> anchorElementList = subelementList.FindElements(By.TagName("div"));

        //                    foreach (IWebElement anchorElement in anchorElementList)
        //                    {
        //                        IReadOnlyCollection<IWebElement> linkElementList = anchorElement.FindElements(By.TagName("a"));

        //                        foreach (IWebElement linkElement in linkElementList)
        //                        {
        //                            if (linkElement.Text == param)
        //                            {
        //                                linkElement.Click();
        //                                flag = true;
        //                                break;
        //                            }

        //                        }
        //                        if (flag) { break; }
        //                    }
        //                    if (flag) { break; }

        //                }
        //                if (flag) { break; }
        //            }
        //            if (flag) { break; }
        //        }

        //    }
        //    catch (Exception e) { SAFEBBALog.TestCaseErrorMessage(e); }
        //}


        // Click the menu from the left side of the panel
        public void clickLinkText(String id, String text)
        {

            IWebElement webelement = findWebDriverElement.waitForElementById(null, null, id);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementLiList = webelement.FindElements(By.TagName("ul"));
            try
            {
                foreach (IWebElement elementLi in elementLiList)
                {
                    IReadOnlyCollection<IWebElement> elementUlList = elementLi.FindElements(By.TagName("li"));

                    foreach (IWebElement elementUl in elementUlList)
                    {
                        
                      if (elementUl.GetAttribute("innerHTML").Contains(text))
                       {
                        elementUl.Click();
                        flag = true;
                        break;
                       }

                    }
                     if (flag) { break; }
                }
                 

            }
                       
            catch (Exception e) { SAFEBBALog.TestCaseErrorMessage(e); }
        }

        // Click the menu from the left side of the panel
        public void clickTableLink(String id, String text)
        {

            IWebElement webelement = findWebDriverElement.waitForElementById(null, null, id);
            Boolean flag = false;
            IReadOnlyCollection<IWebElement> elementLiList = webelement.FindElements(By.TagName("table"));
            try
            {
                foreach (IWebElement elementLi in elementLiList)
                {
                    IReadOnlyCollection<IWebElement> elementUlList = elementLi.FindElements(By.TagName("tbody"));

                    foreach (IWebElement elementUl in elementUlList)
                    {

                        if (elementUl.GetAttribute("innerHTML").Contains(text))
                        {
                            elementUl.Click();
                            flag = true;
                            break;
                        }

                    }
                    if (flag) { break; }
                }


            }

            catch (Exception e) { SAFEBBALog.TestCaseErrorMessage(e); }
        }

    }
 }

        