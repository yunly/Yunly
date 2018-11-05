using System;
using System.Collections.Generic;
using System.Text;

using HtmlAgilityPack;

namespace Hercules.WebSite
{
    public class HtmlTranslator
    {


        const string frenchPath = @"C:\Users\zhuang\website\French\HerculesSLR_2018_Catalogue_FRENCH_FIN_02_UPDATED_BLEED FR-lo-res_new.html";

        const string englishPath = @"C:\Users\zhuang\website\French\HerculesSLR_2018_Catalogue_ENG_FIN_02_final_1.html";

        const string resultLogFile = @"C:\Users\zhuang\website\French\result.txt";

        List<string> innerText = new List<string>();


        #region static
        static HtmlNode frenchDocument
        {
            get
            {
                return getHtmlNodeFromFile(frenchPath);
            }
        }

        static HtmlNode englishDocument
        {
            get
            {
                return getHtmlNodeFromFile(englishPath);
            }
        }

        static HtmlNode getHtmlNodeFromFile(string path)
        {
            var html = new HtmlDocument();

            

            html.Load(path);
            return html.DocumentNode;
        }

        static List<string> exculsiveTag = new List<string>
        {
            "table","br"
        };

        #endregion


        #region Public Method
        public HtmlTranslator()
        {           
            
        }


        


        public string replaceAllTable(string input)
        {
            HtmlDocument htmlDestination = new HtmlDocument();
            htmlDestination.LoadHtml(input);

            var tables = htmlDestination.DocumentNode.SelectNodes("//table");

            if (tables == null)
                return input;

            foreach (var table in tables)
            {
                var tableNode = frenchDocument.SelectSingleNode("//table[@id='" + realTableId(table.Id) + "']");

                if (tableNode != null)
                    table.InnerHtml = tableNode.InnerHtml;
            }

            return htmlDestination.DocumentNode.OuterHtml;
        }


        public void getInnerTextFromNode()
        {
            List<string> englishInnerTexts = new List<string>();
            getCurrentInnerText(ref englishInnerTexts, englishDocument);


            List<string> frenchInnerTexts = new List<string>();
            getCurrentInnerText(ref frenchInnerTexts, frenchDocument);



            using (var sw = new System.IO.StreamWriter(resultLogFile, false))
            {

                sw.WriteLine($"English count: {englishInnerTexts.Count}");
                sw.WriteLine($"french  count: {frenchInnerTexts.Count}");

                var capacity = englishInnerTexts.Count > frenchInnerTexts.Count ? frenchInnerTexts.Count : englishInnerTexts.Count;

                for (var i = 0; i < capacity; i++)
                {
                    sw.WriteLine(i);
                    sw.WriteLine(englishInnerTexts[i]);
                    sw.WriteLine(frenchInnerTexts[i]);
                    sw.WriteLine();
                }

            }
        }


        public List<string> printAllInnerText(string file)
        {
            HtmlDocument html = new HtmlDocument();
            
            html.Load(file);


            printNodesText(html.DocumentNode);

            return innerText; 
        }

        public List<string> printTableHeadLine(string file, string id)
        {
            HtmlDocument html = new HtmlDocument();
            
            html.Load(file);

            List<string> heads = new List<string>();

            HtmlNode headTr = html.DocumentNode.SelectSingleNode("//table[@id='" + id + "']/tbody/tr[1]");

            foreach (var td in headTr.ChildNodes)
                heads.Add(td.InnerHtml);

            return heads;
        }



        public string getHtmlByText(string elementText, string text)
        {
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(elementText);

            return findElementByText(html.DocumentNode, text);
                      
        }



        


        public void replaceAllTable(string filePathSource, string filePathDestination, string newPath)
        {
            HtmlDocument htmlSource = new HtmlDocument();
            HtmlDocument htmlDestination = new HtmlDocument();

            htmlSource.Load(filePathSource);
            htmlDestination.Load(filePathDestination);


            foreach (var table in htmlDestination.DocumentNode.SelectNodes("//table"))
            {
                

                table.InnerHtml = htmlSource.DocumentNode.SelectSingleNode("//table[@id='" + table.Id + "']").InnerHtml;                
            }

            htmlDestination.Save(newPath);
        }        

                     
        public void replaceTable(string tableId, string filePathSource, string filePathDestination, string newPath)
        {
            HtmlDocument html = new HtmlDocument();

            html.Load(filePathSource);

            string tableHtml = html.DocumentNode.SelectSingleNode("//table[@id='" + tableId + "']").InnerHtml;

            html.Load(filePathDestination);

            html.DocumentNode.SelectSingleNode("//table[@id='" + tableId + "']").InnerHtml = tableHtml;

            html.Save(newPath);
        }

        #endregion


        #region Private Method


        private string findElementByText(HtmlNode node, string text)
        {
            if (node.InnerText == text)
                return node.OuterHtml;

            foreach (var child in node.ChildNodes)
                return findElementByText(child, text);

            return null;
        }


        private void getCurrentInnerText(ref List<string> innerTexts, HtmlNode node)
        {
            if (exculsiveTag.Contains(node.Name))
                return;

            if (!node.HasChildNodes)
            {
                var nodeValue = node.InnerText.Trim('\n', '\r', '\t', ' ');

                if (!string.IsNullOrEmpty(nodeValue))
                    innerTexts.Add(node.Name + ":" + nodeValue);
            }
            else
                foreach (var childNode in node.ChildNodes)
                {
                    getCurrentInnerText(ref innerTexts, childNode);
                }
        }

        private void printNodesText(HtmlNode htmlNode)
        {
            foreach (HtmlNode node in htmlNode.ChildNodes)
            {
                if (node.HasChildNodes)
                    printNodesText(node);
                else
                {
                    if (!string.IsNullOrEmpty(node.InnerText.Trim()))
                        innerText.Add(node.InnerText);
                }
            }
        }

        private string realTableId(string tableId)
        {
            if (String.IsNullOrEmpty(tableId) || tableId.Length != 8)
            {
                Console.WriteLine("Invalid tableId:" + tableId ?? "null");
                return "";
            }

            Console.WriteLine(tableId);

            int numberId = int.Parse(tableId.Trim().Substring(5));

            numberId = numberId >= 87 ? numberId + 1 : numberId;

            return "table" + numberId.ToString("D3");
        }

        #endregion



    }
}
