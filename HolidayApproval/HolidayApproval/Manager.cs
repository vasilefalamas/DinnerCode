using System.Net.Mail;
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
                Status = status,
                SignedBy = this.Name
            };
        }

        private static void Respond(Response response)
        {
            if (response.Status == Status.Approved)
            {
                SendEmail();
            }
            else
            {
                SendEmail();
            }
        }

        private static void SendEmail()
        {

        }
    }
}
