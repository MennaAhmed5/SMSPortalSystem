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
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {

        public ReportRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Report> FilterReports(string? userName, string? number, int? submissionId)
        {
            var reports = _context.Reports.AsQueryable();

            if (!string.IsNullOrWhiteSpace(userName))
            {
                 reports = reports.Where(r => r.SenderUsername.Contains(userName, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(number))
            {
                reports = reports.Where(r => r.PhoneNumber.Contains(number));
            }

            if (submissionId != 0)
            {
                reports = reports.Where(r => r.SubmissionId == submissionId);
            }

            return reports;
        }
    }
}
