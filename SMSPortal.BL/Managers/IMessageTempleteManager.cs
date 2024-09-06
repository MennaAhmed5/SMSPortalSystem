using SMSPortal.BL.ViewModels.MessageTempletes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.BL.Managers
{
    public  interface IMessageTempleteManager
    {
        IEnumerable<MessageTempleteReadVM> GetAll();
        MessageTempleteDetailsVM GetDetailsById(int id);

        void AddMessageTemplete(MessageTempleteAddVM messageTempleteAddVM);

        MessageTempleteEditVM? GetforEditById(int id);

        void Edit(MessageTempleteEditVM messageTempleteEditVM);
 
        Object Delete(int id);
    }
}
