using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SMSPortal.BL.Managers;
using SMSPortal.BL.ViewModels.MessageTempletes;
using SMSPortal.DAL.Data.Models;

namespace SMSPortal.MVC.Controllers
{
    public class MessageTempleteController : Controller
    {

        private readonly IMessageTempleteManager _messageTempleteManager;


        public MessageTempleteController(IMessageTempleteManager messageTempleteManager)
        {
            _messageTempleteManager = messageTempleteManager;
        }
        [Authorize(Roles = "Sender,Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Sender,Admin")]

        public IActionResult GetData()
        {
            var messageTempletes = _messageTempleteManager.GetAll();
            return Json(new {data = messageTempletes});
        }

        [HttpGet]
        [Authorize(Roles = "Sender,Admin")]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Sender,Admin")]

        public IActionResult Create(MessageTempleteAddVM messageTempleteAddVM)
        {
            if (!ModelState.IsValid)
            {
                return View(messageTempleteAddVM);
            }
            _messageTempleteManager.AddMessageTemplete(messageTempleteAddVM);
             return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Edit(int id) {

            var messageTempleteEditVM = _messageTempleteManager.GetforEditById(id);
            return View(messageTempleteEditVM);
        
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MessageTempleteEditVM messageTempleteEditVM)
        {

            _messageTempleteManager.Edit(messageTempleteEditVM);
             return RedirectToAction(nameof(Index));

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _messageTempleteManager.Delete(id);
             return  Json(result);

        }

    }
}
