using HolidayApproval.HolidayRequest;
using HolidayApproval.HolidayResponse;

namespace HolidayApproval
{
    public class Manager
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public void Approve(Request request)
        {
            var response = CreateResponse(request, Status.Approved);
            Respond(response);
        }

        public void Reject(Request request)
        {
            var response = CreateResponse(request, Status.Rejected);
            Respond(response);
        }

        private Response CreateResponse(Request request, Status status)
        {
            return new Response
            {
                InitialRequest = request,
                Status = status
            };
        }

        private void Respond(Response response)
        {
            if (response.Status == Status.Approved)
            {
                SendEmail("hr_holidays@mailing.com", response);
            }
            else
            {
                SendEmail(response.InitialRequest.Employee.Email, response);
            }
        }

        private void SendEmail(string recipient, Response response)
        {
            EmailClientLocator.EmailClient.Send(this.Email, recipient, "Holiday Request was " + response.Status, response.ToString());
        }
    }
}
