using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.BL.ViewModels.MessageTempletes
{
    public class MessageTempleteEditVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        public MessageTempleteEditVM()
        {
        }

        public MessageTempleteEditVM(int id, string name , string content)
        {
            Id = id;
            Name = name;
            Content = content;
        }
    }
}
