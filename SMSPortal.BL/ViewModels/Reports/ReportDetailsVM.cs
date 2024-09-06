using SMSPortal.DAL.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Types;

namespace SMSPortal.BL.ViewModels.Reports
{
    public class ReportDetailsVM
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }

        public string SenderUsername { get; set; }

        public string PhoneNumber { get; set; }

        public string MessageContent { get; set; }

        public DateTime SendingDate { get; set; }

        public Status Status { get; set; }

        public string Details { get; set; }

        public ReportDetailsVM(int id, string senderUsername, string phoneNumber, string messageContent, DateTime sendingDate, Status status, string details, int submissionId)
        {
            Id = id;
            SubmissionId = submissionId;
            SenderUsername = senderUsername;
            PhoneNumber = phoneNumber;
            MessageContent = messageContent;
            SendingDate = sendingDate;
            Status = status;
            Details = details;


        }
    }
}
