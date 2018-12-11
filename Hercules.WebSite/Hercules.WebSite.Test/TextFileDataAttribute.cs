using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using Xunit.Sdk;

namespace Hercules.WebSite.Test
{
    public class TextFileDataAttribute : DataAttribute
    {
        private string filePath;
        private string property;

        public TextFileDataAttribute(string path) : this(path, null) { }

        public TextFileDataAttribute(string path, string prop)
        {
            this.filePath = path;
            this.property = prop;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
                throw new ArgumentNullException(nameof(testMethod));

            if (!File.Exists(filePath)) throw new FileNotFoundException($"{filePath} not exists.");


            var fileData = File.ReadAllText(filePath);

            var array = new string[][] { new string[] { fileData } };

            return array.AsEnumerable<string[]>();

        }
    }
}
