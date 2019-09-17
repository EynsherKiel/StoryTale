using StoryTale.Core.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace StoryTale.Tests
{
    [TestClass]
    public class ExpandoObjectTests
    {
        [TestMethod]
        public void ToJsonSuccess()
        {
            string func()
            {
                return "14";
            }

            dynamic left = new ExpandoObject();

            left.iNcar = (Func<string>)func;

            var exp = left as IDictionary<string, object>;

            exp["iNcar"] = ((dynamic)exp["iNcar"])();

            var obj = Newtonsoft.Json.JsonConvert.SerializeObject(exp);

            Assert.IsNotNull(obj);
        }
    }
}