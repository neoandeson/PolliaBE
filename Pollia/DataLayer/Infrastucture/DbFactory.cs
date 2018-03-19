using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;

namespace DataLayer.Infrastucture
{
    public class DbFactory : Disposable, IDbFactory
    {
        PolliaEntities dbContext;

        public PolliaEntities Init()
        {
            return dbContext ?? (dbContext = new PolliaEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }

    public interface IDbFactory : IDisposable
    {
        PolliaEntities Init();
    }
}
