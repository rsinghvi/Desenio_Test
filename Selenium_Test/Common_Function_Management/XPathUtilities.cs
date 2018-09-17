using SAFEBBA.LogMgn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFEBBA.CommonFuncMgn
{
    public class XPathUtilities
    {
        
        // Find pattern as //a[@title="SHIFT <> Å"]	
        public static String XPathEquals(String element, String attribute, String value)
        {
            String xPathEquals = "//" + element + "[@" + attribute + "=\"" + value + "\"]";
            SAFEBBALog.Debug("xPathEquals: " + xPathEquals);
            return xPathEquals;
        }
        
        /// <summary>
        /// Find images by image name
        /// </summary>
        /// <param name="imageName"></param>
        /// <returns></returns>
        static public String XPathImageName(String imageName)
        {
            return "//img[contains(@src,\"" + imageName + "\")]";
        }

        /// <summary>
        /// Find image by name and Id for the nearest parents
        /// </summary>
        /// <param name="id"></param>
        /// <param name="imageName"></param>
        /// <returns></returns>
        static public String XPathIdAndImageName(String id, String imageName)
        {
            return "//*[@id=\"" + id + "\"]//img[contains(@src,\"" + imageName + "\")]";
        }


        public static String XPathStartsWithId(String tag, String id)
        {
            String xPath = "//" + tag + "[starts-with(@id, '" + id + "')]";
            return xPath;
        }

        public static String XPathEndsWithId(String tag, String endPartOfId)
        {
            String xPath = "//" + tag + "[substring(@id,(string-length(@id)-string-length('" + endPartOfId + "')+1))= '" + endPartOfId + "']";
            return xPath;
        }

        public static String XPathContains(String tag, String endPartOfId)
        {
            String xPath = "//" + tag + "[contains(@id,'" + endPartOfId + "')]";
            return xPath;
        }

        public static String XPathContainsStartAndEndPart(String tag, String startPartOfIdm, String endPartOfId)
        {
            String xPath = "//" + tag + "[contains(@id,'" + startPartOfIdm + "') and contains(@id,'" + endPartOfId + "')]";
            return xPath;
        }

        public static String XPathStartsWithIdAndContains(String tag, String id, String endPartOfId)
        {
            String xPath = "//" + tag + "[starts-with(@id, '" + id + "') and contains(@id,'" + endPartOfId + "')]";
            return xPath;
        }

        public String XPathExcludeDynamicPart(String tag, String startPartId, String endPartId)
        {
            String xPath = "//" + tag + "[substring(@id,(string-length('" + startPartId + "')+1)) = '" + startPartId + "' and substring(@id,(string-length(@id)-string-length('" + endPartId + "')+1))= '" + endPartId + "'])";
            return xPath;
        }
    }
}
