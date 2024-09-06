using SMSPortal.DAL.Data.Context;
using SMSPortal.DAL.Data.Models;

using SMSPortal.DAL.Repository.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.DAL.Repository
{
    public class MessageTempleteRepository : GenericRepository<MessageTemplete>, IMessageTempleteRepository
    {
        public MessageTempleteRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
