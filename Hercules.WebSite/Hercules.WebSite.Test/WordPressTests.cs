using System;
using Xunit;

using OpenQA.Selenium;
using System.Collections.Generic;
using Xunit.Abstractions;

using Hercules.WebSite.Models;

namespace Hercules.WebSite.Test
{
    public class WordPressTests
    {
        IWebDriver driver = Yunly.Net.SeleniumAPI.SeleniumFactory.createChromeDriver();

        private readonly ITestOutputHelper output;

        public WordPressTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        ~WordPressTests()
        {
            driver.Dispose();
            driver.Quit();
            driver.Close();
        }

        [Theory]
        [InlineData("https://herculesslr.com/wp-admin/index.php")]
        public void CanLogin(string expected)
        {
            //arrange
            var wordPress = new WordPrss(driver);
            var user = @"zhuang@herculesslr.com";
            var password = @"WbP^ICOCqCHfUeKUh)7oEgZ6";

            //action            
            wordPress.login(user, password);


            //assert
            Assert.Equal(expected, driver.Url);
        }

        [Theory]
        [InlineData("<li><a href=\"/?page_id=5989\">Aqua Green Superdan Rope</a></li>", "5989")]
        public void Can_Get_PageId(string input, string expected)
        {
            //arrange
            var wordPress = new WordPrss(driver);

            //action
            var result = wordPress.GetPageIdFromLink(input);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("https://herculesslr.com/wp-admin/post.php?post=5989&action=edit", "5989")]
        public void Can_Build_Url(string expected, string input)
        {
            //arrange
            var wordPress = new WordPrss(driver);

            //action
            var result = wordPress.BuildUrl(input);

            //assert
            Assert.Equal(expected, result);
        }






        [Theory]
        [TextFileData(@"C:\Users\zhuang\website\develop\text.txt")]
        public void Can_Read_File(string input)
        {
            Assert.Equal("123", input);
        }

        [Theory]
        [TextFileData(@"C:\Users\zhuang\website\develop\page.txt")]
        public void Can_Get_Context(string expected)
        {
            //arrange
            var wordPress = new WordPrss(driver);
            var user = @"zhuang@herculesslr.com";
            var password = @"WbP^ICOCqCHfUeKUh)7oEgZ6";
            var pageId = "1706";

            //action
            wordPress.login(user, password);
            var url = wordPress.BuildUrl(pageId);
            var result = wordPress.getContentFromUrl(url);

            //assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [TextFileData(@"C:\Users\zhuang\website\develop\Catalogue_en.txt")]
        public void Can_Gernerate_Urls(string input)
        {
            //arrange
            var wordPress = new WordPrss(driver);
            
            List<string> pageIds = new List<string>();
            foreach (var line in input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
            {
                var pageId = wordPress.GetPageIdFromLink(line);
                if (pageId == null)
                    continue;

                pageIds.Add(pageId);
            }

            var repo = new UrlRepository(pageIds, wordPress);
        }

        [Theory]
        [InlineData("3219", "1680")]
        [InlineData("3225", "1642")]
        public void Can_Compare_TableId(string pageId1, string pageId2)
        {
            //arrange
            WordPrss wordPrss = new WordPrss(driver);


            var user = @"zhuang@herculesslr.com";
            var password = @"WbP^ICOCqCHfUeKUh)7oEgZ6";


            wordPrss.login(user, password);




            var content1 = wordPrss.getContentFromUrl(pageId1);
            var content2 = wordPrss.getContentFromUrl(pageId2);

            //action

            var result = wordPrss.compareTableId(content1, content2);


            //assert
            Assert.True(result);



        }




        //[Theory]
        //[TextFileData(@"C:\Users\zhuang\website\develop\page.txt")]
        //public void Can_Add_Statement(string expected)
        //{
        //    //arrange
        //    var wordPress = new WordPrss(driver);
        //    var user = @"zhuang@herculesslr.com";
        //    var password = @"WbP^ICOCqCHfUeKUh)7oEgZ6";
        //    var pageId = "1706";

        //    //action
        //    wordPress.login(user, password);
        //    wordPress.addStatement(pageId);
        //    var result = wordPress.getContentFromUrl(pageId);

        //    //assert
        //    Assert.Equal(expected, result);
        //}

        //[Theory]
        //[TextFileData(@"C:\Users\zhuang\website\develop\Catalogue_en.txt")]
        //public void can_AddStatements(string input)
        //{
        //    //arrange
        //    //arrange
        //    var wordPress = new WordPrss(driver);
        //    var user = @"zhuang@herculesslr.com";
        //    var password = @"WbP^ICOCqCHfUeKUh)7oEgZ6";


        //    List<string> pageIds = new List<string>();
        //    foreach (var line in input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        var pageId = wordPress.GetPageIdFromLink(line);
        //        if (pageId == null)
        //            continue;

        //        pageIds.Add(pageId);
        //    }

        //    //action
        //    wordPress.login(user, password);
        //    wordPress.addStatements(pageIds, testPageId);

        //}

        private void testPageId(string pageId)
        {
            output.WriteLine(pageId);
        }

        [Theory]
        [TextFileData(@"C:\Users\zhuang\website\develop\text.txt", "123")]
        public void test_Attribute(string input, string expected)
        {
            output.WriteLine(input);
            output.WriteLine(expected);
            Assert.Equal(expected, input);
        }
    }
}
