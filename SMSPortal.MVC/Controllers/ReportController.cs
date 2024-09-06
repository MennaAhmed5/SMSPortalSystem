using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMSPortal.BL.Managers;

namespace SMSPortal.MVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportManager _reportManager;
        public ReportController(IReportManager reportManager) {
            _reportManager = reportManager;
        }
        [Authorize(Roles = "Viewer,Admin, Sender")]
        public IActionResult Index(string? userName, string? number, int? submissionId)
        {
            var reports = _reportManager.GetFilteredReports(userName, number, submissionId);

            return View(reports);
        }
        
   }
}
