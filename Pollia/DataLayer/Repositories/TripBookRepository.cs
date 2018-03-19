using DataLayer.Infrastucture;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class TripBookRepository : RepositoryBase<TripBook>, ITripBookRepository
    {
        public TripBookRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public TripBook GetById(int? TripBookId)
        {
            if (TripBookId != null)
            {
                TripBook TripBook = this.DbContext.TripBooks.Where(p => p.Id == TripBookId).FirstOrDefault();
                return TripBook;
            }
            return null;
        }
        public int GetTotalTripBooks()
        {
            return this.DbContext.TripBooks.Count();
        }

        public int GetTotalTripBooksOf(List<string> args)
        {
            return this.DbContext.TripBooks.Where(e => args.Contains(e.UserId)).Count();
        }
    }

    public interface ITripBookRepository : IRepository<TripBook>
    {
        TripBook GetById(int? TripBookId);
        int GetTotalTripBooks();
        int GetTotalTripBooksOf(List<string> args);
    }
}
