using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.BL.ViewModels.MessageTempletes
{
    public class MessageTempleteDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Content { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public MessageTempleteDetailsVM(int id , string name, string content, DateTime createdAt, DateTime? updatedAt)
        {
            Id= id;
            Name= name;
            Content= content;
            CreatedAt= createdAt;
            UpdatedAt= updatedAt;
        }
    }
}
