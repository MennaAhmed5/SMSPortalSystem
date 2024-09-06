using SMSPortal.DAL.Data.Models;
using SMSPortal.DAL.Repository.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.DAL.Repository
{
    public interface IReportRepository : IGenericRepository<Report>
    {
        public  IEnumerable<Report> FilterReports(string? userName, string? number, int? submissionId);

    }
}
