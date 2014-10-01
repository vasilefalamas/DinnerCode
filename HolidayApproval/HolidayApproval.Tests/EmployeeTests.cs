using System;
using HolidayApproval.HolidayRequest;
using HolidayApproval.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HolidayApproval.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        private Employee _employee;

        private Request _request;

        private string _managerEmail = "manager.fellow@dummy.com";

        private EmailClientMock _emailClient;

        [TestInitialize]
        public void EmployeeInitialize()
        {
            _employee = new Employee
                {
                    Email = "john.doe@dummy.com",
                    Name = "John Doe"
                };

            _request = new Request
            {
                Employee = _employee,
                ManagerEmail = _managerEmail,
                Bounds = new Bounds
                {
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays(10)
                }
            };

            EmailClientLocator.EmailClient = new EmailClientMock();
            _emailClient = (EmailClientMock) EmailClientLocator.EmailClient;
        }


        [TestMethod]
        public void Employee_WhenApplies_EmailIsSent()
        {
            _employee.Apply(_managerEmail, _request.Bounds.Start, _request.Bounds.End);

            Assert.AreEqual(_managerEmail, _emailClient.SentEmail.Recipient);

        }
    }
}
