using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMSPortal.BL.Managers;
using SMSPortal.BL.Services;
using SMSPortal.BL.ViewModels.MessageTempletes;
using System.Text.RegularExpressions;

namespace SMSPortal.MVC.Controllers
{
    public class MessageFormController : Controller
    {
        private readonly IMessageTempleteManager _messageTempleteManager;
        private readonly IReportManager _reportManager;
        private readonly ISMSService _smsService;

        public MessageFormController(IMessageTempleteManager messageTempleteManager, ISMSService smsService, IReportManager reportManager)
        {
            _messageTempleteManager = messageTempleteManager;
            _smsService = smsService;
            _reportManager = reportManager;
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Sender,Admin")]
        //Display all form with messageTemplete in the table
        public IActionResult CreateMessage()
        {
            var model = new MessageTempleteFormVM()
            {
                Templates = _messageTempleteManager.GetAll().ToList()
            };

            return View("MessageForm", model);
        }


        [HttpPost]
        [Authorize(Roles = "Sender,Admin")]
        [ValidateAntiForgeryToken]
        
            public IActionResult CreateMessage(MessageTempleteFormVM messageTempleteFormVM)
            {

             if (messageTempleteFormVM.SelectedTemplateId == 0)
            {
                ModelState.AddModelError(" ", "Please select a template before submitting.");
             }
            if (!ModelState.IsValid)
            {
                // If validation fails, return the view with validation messages
                messageTempleteFormVM.Templates = _messageTempleteManager.GetAll().ToList();
                return View("MessageForm", messageTempleteFormVM);
            }


            // Validate CSV file
            if (messageTempleteFormVM.CsvFile != null)
                {
                    int subId = 0;
                     //create stream reader object to read file
                    using (var reader = new StreamReader(messageTempleteFormVM.CsvFile.OpenReadStream()))
                    {
                        var phoneNumbers = new List<string>();
                        //read file line by line
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var numbers = line.Split(',');
                            //validate numbers
                            foreach (var number in numbers)
                            {
                                if (Regex.IsMatch(number.Trim(), @"^\+201(0|1|2|5)\d{8}$"))
                                {
                                    phoneNumbers.Add(number.Trim());
                                }
                                else
                                {
                                    ModelState.AddModelError("CsvFile", $"Invalid phone number: {number.Trim()}");
                                }
                            }
                        }
                    if (!ModelState.IsValid)
                    {
                        // If validation fails, return the view with validation messages
                        messageTempleteFormVM.Templates = _messageTempleteManager.GetAll().ToList();
                        return View("MessageForm", messageTempleteFormVM);
                    }

                    var SelectedteTemplete = _messageTempleteManager.GetDetailsById(messageTempleteFormVM.SelectedTemplateId);

                    // Proceed with sending messages using Twilio
                    foreach (var phoneNumber in phoneNumbers)
                    {
                        var processedMessage = SelectedteTemplete.Content;
                        
                        foreach (var placeholder in messageTempleteFormVM.PlaceholderValues)
                        {
                            processedMessage = processedMessage.Replace(placeholder.Key, placeholder.Value);
                        }

                        // Twilio sending logic here
                         subId = _smsService.Send(phoneNumber, processedMessage);
                        
                     
                    }


                }

                return RedirectToAction("Index", "Report", new { submissionId = subId });

            }

            return View("MessageForm", messageTempleteFormVM);

        }








    }
    
}
