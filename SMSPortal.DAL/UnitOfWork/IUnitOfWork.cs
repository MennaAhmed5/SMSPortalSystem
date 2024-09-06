using SMSPortal.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IMessageTempleteRepository MessageTempleteRepository { get; }

        public IReportRepository ReportRepository { get; }
        public void SaveChanges();
         
    }
}
