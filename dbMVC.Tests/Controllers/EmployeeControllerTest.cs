using System;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbMVC;
using dbMVC.Controllers;
using dbMVC.Lib;
using dbMVC.Tests.Models;
using Moq;

namespace dbMVC.Tests.Controllers
{
    /// <summary>
    /// Summary description for EmployeecontrollerTest
    /// </summary>
    [TestClass]
    public class EmployeeControllerTest
    {
        public EmployeeControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private IEmployeeManager inEmployees = new InMemoryEmployeeReposittory();

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Get_DefaultViewTest()
        {
            var controller = getEmployeeController();
            ViewResult result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<Employee>;

            Assert.IsTrue(model.Count() > 1);
        }

        [TestMethod]
        public void Get_DetailViewTest()
        {
            int id = inEmployees[0].ID;
            var controller = getEmployeeController();
            ViewResult result = controller.Details(id) as ViewResult;
            var model = result.Model as Employee;

            Assert.IsTrue(id == model.ID);
        }

        [TestMethod]
        public void Get_DeleteTest()
        {
            Mock<IEmployeeManager> mymock = new Mock<IEmployeeManager>();
            mymock.Setup(m => m[0]).Returns(new Employee() {ID = 1});

            Employee emp1 = this.inEmployees.Get(0);
            Employee empM = ((IEmployeeManager)mymock.Object)[0];

            Assert.IsTrue(emp1.ID == empM.ID);

        }

        private  static EmployeeController getEmployeeController()
        {
            EmployeeController controller = new EmployeeController();
            controller.ControllerContext = new ControllerContext()
                                               {
                                                   Controller = controller,
                                                   RequestContext =new RequestContext(new MockHttpContext(),
                                                   new RouteData())
                                               };
            return controller;
        }

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someuser"), null);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }

    }
}
