    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Chrome;

    namespace Com.Sogeti.Tests.DesenioTest.Object_Repository
    {

        public class Desenio_Test_Objects
    {
        // Test Case 1
        public static readonly Dictionary<string, string> NYHETER_LINK = new Dictionary<string, string> { { "xpath", "(.//*[normalize-space(text()) and normalize-space(.)='THE BLUE-GREEN SPECTRUM'])[1]/following::div[1]" } };
        public static readonly Dictionary<string, string> ARTICLE_LINK = new Dictionary<string, string> { { "id", "mainArticleWrapper" }, { "text", "Ice Poppy Poster" } };
        public static readonly Dictionary<string, string> ADDITEM_BUTTON = new Dictionary<string, string> { { "id", "SubmitFalt" }, { "text", "Lägg i shoppingbagen" } };
        public static readonly Dictionary<string, string> CHECKOUT_BUTTON = new Dictionary<string, string> { { "class", "checkout" }, { "xpath", "(.//*[normalize-space(text()) and normalize-space(.)='Fortsätt handla'])[2]/following::div[1]" } };
        public static readonly Dictionary<string, string> CHECKOUT_TEXT = new Dictionary<string, string> { { "xpath", "(.//*[normalize-space(text()) and normalize-space(.)='Inspiration'])[3]/following::h1[1]" } };
        // public static readonly Dictionary<string, string> ARTICLE_LINK = new Dictionary<string, string> { { "linkText", "Ice Poppy Poster" } };

        // Test Case 2
        public static readonly Dictionary<string, string> INSPIRATION_LINK = new Dictionary<string, string> { { "xpath", "//div[@id='mainMenuIncludeContainer']/div[9]/a" } };
        public static readonly Dictionary<string, string> ROOM_LINK = new Dictionary<string, string> { { "xpath", "(.//*[normalize-space(text()) and normalize-space(.)='INSP9543'])[1]/following::img[1]" } };
        public static readonly Dictionary<string, string> BUY_BUTTON = new Dictionary<string, string> { { "xpath", "(.//*[normalize-space(text()) and normalize-space(.)=':-'])[3]/following::div[1]" } };
        public static readonly Dictionary<string, string> CLOSE_BUTTON = new Dictionary<string, string> { { "id", "closeQuickview" }};
        public static readonly Dictionary<string, string> KASSAN_BUTTON = new Dictionary<string, string> { { "id", "desktopCheckout" } };
        // public static readonly Dictionary<string, string> ARTICLE_LINK = new Dictionary<string, string> { { "linkText", "Ice Poppy Poster" } };



    }
}



