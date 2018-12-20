using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cities.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;
using System.Reflection;
using Cities.Models;

namespace Cities.Test
{
    public class ModelTests
    {
        [Fact]
        public void TestCity()
        {
            //arrange 
            var property = typeof(City).GetTypeInfo().GetDefaultMembers();
        }
    }
}
