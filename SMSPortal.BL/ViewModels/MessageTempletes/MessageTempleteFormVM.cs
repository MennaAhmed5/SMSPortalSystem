using Microsoft.AspNetCore.Http;
using SMSPortal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SMSPortal.BL.ViewModels.MessageTempletes
{
    public class MessageTempleteFormVM
    {
        public List<MessageTempleteReadVM> Templates { get; set; } =new List<MessageTempleteReadVM>();

        [Required]
        public int SelectedTemplateId { get; set; }
        public string? SelectedTemplateContent { get; set; }
        public Dictionary<string, string> PlaceholderValues { get; set; } = new Dictionary<string, string>();

        [Required]
        public IFormFile CsvFile { get; set; }
        public string? ProcessedMessage { get; set; }
    }
}
