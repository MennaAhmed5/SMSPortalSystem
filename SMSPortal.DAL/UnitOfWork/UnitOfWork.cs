using SMSPortal.DAL.Data.Context;
using SMSPortal.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private  readonly ApplicationContext _context;

        public IMessageTempleteRepository MessageTempleteRepository { get; }

        public IReportRepository ReportRepository { get; }
        public UnitOfWork( ApplicationContext context, IMessageTempleteRepository messageTempleteRepository, IReportRepository reportRepository)
        {
            _context = context;
            MessageTempleteRepository = messageTempleteRepository;
            ReportRepository = reportRepository;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
