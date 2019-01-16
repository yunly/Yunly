using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;

namespace Yunly.Learning
{
    /// <summary>
    /// C:\Users\zhuang\Downloads\datangshuanglongchuan_huangyi.txt
    /// </summary>
    public class DtAnalyzer
    {
        private string content;
        private string path = @"C:\Users\zhuang\Downloads\datangshuanglongchuan_huangyi.txt";
        private string pathOutput = @"C:\Users\zhuang\Downloads\out.log";
        public DtAnalyzer()
        {
            if (File.Exists(pathOutput)) File.Delete(pathOutput);

            loadText(path);
        }

        private void loadText(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                content = sr.ReadToEnd();
            }            
        }

        public string[] excludedStr { get; set; } = new string[]
           {"\n", " ", "\r", "\t", "，","？", "”", "。", "*", "！", "：", "-","“", "　　",};

        public string Content => content;

        public void ProcessFormat()
        {
            foreach (var ch in excludedStr)
                content = content.Replace(ch, "");

        }


        public void analyzeWordCount(int len, int taken)
        {
            List<string> raw = new List<string>();

            

            for (int i = 0; i < content.Length - (len - 1); i++)
            {
                raw.Add(content.Substring(i, len));
            }

            var result = raw.GroupBy(d => d, (d, names) => new { name = d, count = names.Count() }).OrderByDescending(d => d.count).Take(taken);

            foreach (var item in result)
                WriteLog($"{item.name}:{item.count}");



            
        }



        public void WriteLog(string log)
        {
            using (StreamWriter sw = new StreamWriter(pathOutput, true, Encoding.UTF8))
            {
                sw.WriteLine(log);
            }
        }
    }
}
