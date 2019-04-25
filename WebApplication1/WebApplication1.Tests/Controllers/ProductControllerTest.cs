using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new ProductEntities();
            var controller = new ProductController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            var model = result.Model as List<Product>;
            Assert.IsNotNull(model);
            Assert.AreEqual(db.Products.Count(), model.Count);

        }
        [TestMethod]
        public void TestCreate()
        {
            var controller = new ProductController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestEdit()
        {
            var controller = new ProductController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            var db = new ProductEntities();
            var item = db.Products.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as Product;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);
           
        }
    }
}
