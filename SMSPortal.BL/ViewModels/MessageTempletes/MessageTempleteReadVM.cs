using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.BL.ViewModels.MessageTempletes
{
    public class MessageTempleteReadVM
    {
         public int Id { get; set; }
         public string Name { get; set; }
         public string Content { get; set; }

         public int PlaceHoldersCount { get; set; }
        public MessageTempleteReadVM(int id, string name, string content ,int placeHoldersCount)
        {
            Id = id;
            Name = name;
            Content = content;
            PlaceHoldersCount = placeHoldersCount;
        }


    }
}
