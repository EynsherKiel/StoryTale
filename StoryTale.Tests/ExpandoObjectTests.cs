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
        public void ExpandoTestsSuccess()
        {
            var left = new ExpandoObject();
            var right = new ExpandoObject();

            Assert.IsTrue(left.Compare(right));
        }

        [TestMethod]
        public void DynamicExpandoTestsSuccess()
        {
            dynamic left = new ExpandoObject();
            dynamic right = new ExpandoObject();

            left.iNcar = "car";
            right.incar = "dad";

            Assert.IsTrue(ExpandoObjectExtensions.Compare(left, right));
        }

        [TestMethod]
        public void ToJsonSuccess()
        {
            static string func() => "14";
            dynamic left = new ExpandoObject();

            left.iNcar = (Func<string>)func;

            var exp = left as IDictionary<string, object>;

            exp["iNcar"] = ((dynamic)exp["iNcar"])();

            var obj = Newtonsoft.Json.JsonConvert.SerializeObject(exp);

            Assert.IsNotNull(obj);
        }
    }
}