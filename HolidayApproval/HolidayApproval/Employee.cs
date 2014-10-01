using System;
using HolidayApproval.HolidayRequest;

namespace HolidayApproval
{
    public class Employee
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public void Apply(string managerEmail, DateTime start, DateTime end)
        {
            var request = CreateRequest(managerEmail, start, end);
            
            SendRequest(request);
        }

        private Request CreateRequest(string managerEmail, DateTime start, DateTime end)
        {
            return new Request
            {
                ManagerEmail = managerEmail,
                Employee = this,
                Bounds = new Bounds
                {
                    Start = start,
                    End = end
                }
            };
        }

        private void SendRequest(Request request)
        {

        }
    }
}
