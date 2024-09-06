using SMSPortal.BL.ViewModels.MessageTempletes;
using SMSPortal.BL.ViewModels.Reports;
using SMSPortal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.BL.Managers
{
    public interface IReportManager
    {
        IEnumerable<ReportReadVM> GetAll();
        ReportDetailsVM? GetDetailsById(int id);

        Report AddReport(ReportAddVM reportAddVM);

        ReportEditVM? GetforEditById(int id);

        void Edit(ReportEditVM reportEditVM);

        Object Delete(int id);
        public IEnumerable<ReportReadVM> GetFilteredReports(string? userName, string? number, int? submissionId);


    }
}
