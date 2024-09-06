using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SMSPortal.BL.Helpers;
using SMSPortal.BL.Managers;
using SMSPortal.BL.ViewModels.Reports;
using SMSPortal.DAL.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Messaging;

namespace SMSPortal.BL.Services
{
    public class SMSService : ISMSService
    {
        private readonly TwilioSettings _twilio;
        private readonly IReportManager _reportManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SMSService(IOptions<TwilioSettings> twilio, IReportManager reportManager, IHttpContextAccessor httpContextAccessor)
        {
            _twilio = twilio.Value;
            _reportManager = reportManager;
            _httpContextAccessor = httpContextAccessor;

        }
        public MessageResource Send(string mobileNumber, string body)
        {
            try
            {
                TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);
                var result = MessageResource.Create(
                    body: body,
                    from: new Twilio.Types.PhoneNumber(_twilio.TwilioPhoneNumber),
                    to: mobileNumber
                    );
                return result;
            } catch(Exception ex)
            {
                var username = _httpContextAccessor.HttpContext.User.Identity.Name;
                ReportAddVM reportAddVM = new ReportAddVM()
                {
                    SenderUsername = username,
                    PhoneNumber = mobileNumber,
                    MessageContent = body,
                    SendingDate = DateTime.UtcNow,
                    Status = Status.Fail,
                    Details = ex.Message

                };
                _reportManager.AddReport(reportAddVM);
                return null;
            }
            
        }
    }
}
