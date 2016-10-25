using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankATM.Data.Infrastructure
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _context;

        public DbContextFactory()
        {
            _context = new DataContext();
        }

        public DbContext GetContext()
        {
            return _context;
        }
    }

    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
    //https://forums.asp.net/t/1782128.aspx?Di+Autofac+question+carn+t+figure+it+out  < -- DbContextFactory
    //http://stackoverflow.com/questions/8059900/convert-dbcontext-to-objectcontext-for-use-with-gridview  < -- Usage?
}
