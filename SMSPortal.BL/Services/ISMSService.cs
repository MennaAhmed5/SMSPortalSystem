using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace SMSPortal.BL.Services
{
    public interface ISMSService
    {
        int Send(string mobileNumber, string Message);
         
    }
}
