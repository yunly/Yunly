using System;
using System.Collections.Generic;
using System.Net.Http;

using System.Threading.Tasks;

using Newtonsoft.Json;

using Yunly.App.Crawler.HalifaxMyRec.Models;


namespace Yunly.App.Crawler.HalifaxMyRec
{
    public class MyRecProgram
    {
        const string programIndexUrl = @"https://recreation.halifax.ca/enterprise/program/index";


        List<RecProgram> recPrograms = new List<RecProgram>();

        public void updateLocalDb()
        {

            int pageId = 0;
            int pageSize = 20;

            var results = getPrograms(pageId.ToString());
            recPrograms.AddRange(results.Data);

            if (results.TotalResultsCount <= pageSize)
                return;


            for (; pageId++ <= (results.TotalResultsCount - 1) / pageSize;)
            {
                results = getPrograms(pageId.ToString());
                recPrograms.AddRange(results.Data);
            }


            using (var db = new YunlyDbContext())
            {
                db.RecProgram.AddRange(recPrograms);
                db.SaveChanges();
            }
                    
        }

        private RecProgramData getPrograms(string pageId)
        {
            HttpClient client = new HttpClient();

            var postUrl = @"https://recreation.halifax.ca/Enterprise/SportsCourseSearch";



            var values = new Dictionary<string, string>
            {
                {"Name","" },
                {"CategoryId","" },
                {"StartFromDate","" },
                {"StartBeforeDate","" },
                {"InstructorId","" },
                {"LocationIdList","" },
                {"AgeMonths","" },
                {"Page",pageId}
            };

            var formData = new FormUrlEncodedContent(values);


            Task.Delay(TimeSpan.FromMilliseconds(500));

            Console.WriteLine("Send Post Request [{0}], Page={1}", postUrl, pageId);
            var response = client.PostAsync(postUrl, formData).Result;

            

            var responseString = response.Content.ReadAsStringAsync().Result;

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateFormatString = "ddd dd MMM, yyyy - HH:mm";

            
            var result = JsonConvert.DeserializeObject<RecProgramData>(responseString, settings);


            return result;

        }


    }
}
