using System;

namespace HolidayApproval.V2
{
    public class HolidayRequest
    {
        public string EmployeeName;
        public string EmployeeEmail;
        public string ManagerEmail;

        public DateTime Start;
        public DateTime End;

        public void Approve()
        {
            Send(Status.Approved, "hr_holidays@iQ.com");
        }

        public void Reject()
        {
            Send(Status.Rejected, EmployeeEmail);
        }

        private void Send(Status requestStatus, string recipient)
        {
            var subject = string.Format("Holiday Request - {0}.", requestStatus);
            var message = string.Format("The request for {0} (starting {1} to {2}), has been {3}.", EmployeeName, Start, End, requestStatus);

            var email = new Email(ManagerEmail, recipient, subject, message);
            email.Send();
        }
    }
}
