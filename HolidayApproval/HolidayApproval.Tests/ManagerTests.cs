using System;
using HolidayApproval.HolidayRequest;
using HolidayApproval.HolidayResponse;
using HolidayApproval.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HolidayApproval.Tests
{
    [TestClass]
    public class ManagerTests
    {
        private Employee _employee;

        private Request _request;

        private Manager _manager;

        private string _managerEmail = "manager.fellow@dummy.com";

        private string _hrEmail = "hr_holidays@mailing.com";

        private EmailClientMock _emailClient;

        [TestInitialize]
        public void ManagerInitialize()
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

            _manager = new Manager
            {
                Email = "manager.fellow@dummy.com",
                Name = "Manager Fellow"
            };

            EmailClientLocator.EmailClient = new EmailClientMock();
            _emailClient = (EmailClientMock)EmailClientLocator.EmailClient;
        }

        [TestMethod]
        public void Manager_WhenApproves_ApprovalMailIsSentToHR()
        {
            _manager.Approve(_request);

            Assert.AreEqual(_hrEmail, _emailClient.SentEmail.Recipient);
        }

        [TestMethod]
        public void Manager_WhenRejects_RejectMailIsSentToEmployee()
        {
            _manager.Reject(_request);

            Assert.AreEqual(_employee.Email, _emailClient.SentEmail.Recipient);
        }

        [TestMethod]
        public void Manager_WhenApproves_ResponseStatusIsSetToApproved()
        {
            _manager.Approve(_request);

            Assert.IsTrue(_emailClient.SentEmail.Subject.Contains(Status.Approved.ToString()));
        }

        [TestMethod]
        public void Manager_WhenRejects_ResponseStatusIsSetToRejected()
        {
            _manager.Reject(_request);

            Assert.IsTrue(_emailClient.SentEmail.Subject.Contains(Status.Rejected.ToString()));
        }

    }
}
