using SMSPortal.BL.ViewModels.MessageTempletes;
using SMSPortal.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSPortal.DAL.Data.Models;
using System.Text.RegularExpressions;

namespace SMSPortal.BL.Managers
{
    public class MessageTempleteManager : IMessageTempleteManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public MessageTempleteManager(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }
        public void AddMessageTemplete(MessageTempleteAddVM messageTempleteAddVM)
        {
            MessageTemplete messageTemplete = new MessageTemplete()
            {
                  Name  = messageTempleteAddVM.Name,
                  Content = messageTempleteAddVM.Content,
                  CreatedAt = DateTime.Now,
            };

            _unitOfWork.MessageTempleteRepository.Add(messageTemplete);
            _unitOfWork.SaveChanges();
        }

        public Object Delete(int id)
        {
            var MessageTemplete = _unitOfWork.MessageTempleteRepository.GetById(id);
             if (MessageTemplete == null) return new {success=false, message="Error While Deleting "};
            _unitOfWork.MessageTempleteRepository.Delete(MessageTemplete);
            _unitOfWork.SaveChanges();
            return new { success = true, message = "Message tmplete has been Deleted " };


        }

        public void Edit(MessageTempleteEditVM messageTempleteEditVM)
        {
            var messageTemplete = _unitOfWork.MessageTempleteRepository.GetById(messageTempleteEditVM.Id);
            messageTemplete.Name = messageTempleteEditVM.Name;
            messageTemplete.Content = messageTempleteEditVM.Content;
            messageTemplete.UpdatedAt = DateTime.Now;

            _unitOfWork.MessageTempleteRepository.Update(messageTemplete);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<MessageTempleteReadVM> GetAll()
        {
            IEnumerable<MessageTemplete> messageTempletes = _unitOfWork.MessageTempleteRepository.GetAll();
            IEnumerable<MessageTempleteReadVM> messageTempletesVM = messageTempletes.Select(m => new MessageTempleteReadVM(m.Id, m.Name, m.Content, Regex.Matches(m.Content, @"\{(\d+)\}").Count()));
            return messageTempletesVM;
        }

        public MessageTempleteDetailsVM GetDetailsById(int id)
        {
            var messageTemplete = _unitOfWork.MessageTempleteRepository.GetById(id);
            if(messageTemplete == null)
            {
                return null;
            }
            else
            {
                return new MessageTempleteDetailsVM(messageTemplete.Id, messageTemplete.Name, messageTemplete.Content, messageTemplete.CreatedAt, messageTemplete.UpdatedAt);
            }
        }

        public MessageTempleteEditVM? GetforEditById(int id)
        {
            var messageTemplete = _unitOfWork.MessageTempleteRepository.GetById(id);
            if (messageTemplete == null) return null;
            return new MessageTempleteEditVM(messageTemplete.Id, messageTemplete.Name, messageTemplete.Content); 
        }
    }
}
