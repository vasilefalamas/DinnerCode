using System.Management.Instrumentation;
using HolidayApproval.HolidayRequest;

namespace HolidayApproval.HolidayResponse
{
    public class Response
    {
        public Request InitialRequest { get; set; }
        
        public Status Status { get; set; }
    }
}
