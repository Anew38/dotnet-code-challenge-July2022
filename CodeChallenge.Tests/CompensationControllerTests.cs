using System.Net;
using System.Net.Http;
using System.Text;
using CodeChallenge.Data;
using CodeChallenge.Models;
using CodeCodeChallenge.Tests.Integration.Extensions;
using CodeCodeChallenge.Tests.Integration.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeChallenge.Tests.Integration
{
    [TestClass]
    public class CompensationControllerTests
    {
        private static HttpClient _httpClient;
        private static TestServer _testServer;

        [ClassInitialize]
        // Attribute ClassInitialize requires this signature
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static void InitializeClass(TestContext context)
        {
            _testServer = new TestServer();
            _httpClient = _testServer.NewClient();
        }

        [ClassCleanup]
        public static void CleanUpTest()
        {
            _httpClient.Dispose();
            _testServer.Dispose();
        }


        // test for creating compensation by ID
        [TestMethod]
        public void CreateCompensationById_Returns_Created()
        {
            // Arrange
            var employee = new Employee()
            {
                EmployeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f",
                Department = "Engineering",
                FirstName = "John",
                LastName = "Doe",
                Position = "Developer"
            };

            var compensation = new Compensation()
            {
                employee = employee,
                employeeId = employee.EmployeeId,
                salary = 100000,
                effectiveDate = "2023-01-01"
            };

            var requestContent = new JsonSerialization().ToJson(compensation);

            // Execute
            var postRequestTask = _httpClient.PostAsync($"api/compensation/{employee.EmployeeId}",
               new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var response = postRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var newCompensation = response.DeserializeContent<Compensation>();
            Assert.IsNotNull(newCompensation.employeeId);
            Assert.AreEqual(compensation.salary, newCompensation.salary);
            Assert.AreEqual(compensation.effectiveDate, newCompensation.effectiveDate);
        }

        // test for reading compensation by ID
        [TestMethod]
        public void ReadCompensationById_Returns_Ok()
        {
            // Arrange
            var employeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f";
            var expectedSalary = 100000;
            var expectedEffectiveDate = "2023-01-01";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/compensation/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var compensation = response.DeserializeContent<Compensation>();
            Assert.AreEqual(expectedSalary, compensation.salary);
            Assert.AreEqual(expectedEffectiveDate, compensation.effectiveDate);
        }

        // test for reading compensation by ID that does not exist
        [TestMethod]
        public void ReadCompensationById_Returns_NotFound()
        {
            // Arrange
            var employeeId = "Invalid_Id";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/compensation/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}

