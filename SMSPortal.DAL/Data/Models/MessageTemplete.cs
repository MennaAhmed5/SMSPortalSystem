﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.DAL.Data.Models
{
    public class MessageTemplete
    {
        public int Id { get; set; }
         
        public string Name { get; set; }
      
        public string Content { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
