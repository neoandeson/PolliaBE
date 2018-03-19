using DataLayer.Infrastucture;
using DataLayer.Repositories;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface ITripBookService
    {
        //IEnumerable<TripBook> GetTripBooks(string name = null);
        TripBook GetTripBook(int id);
        //TripBook GetTripBook(string name);
        void CreateTripBook(TripBook TripBook);
        void EditTripBook(TripBook TripBook);
        void RemoveTripBook(int id);
        void SaveTripBook();
        void UnRemoveTripBook(int id);
        TripBook GetTripBook(int? TripBookId);
        //List<TripBook> GetTripBooksNearBy(float longitude, float latitude, float distance, int scope);
        //IEnumerable<TripBook> GetTripBooksByName(string name, int curr, int take);
        int GetTotalTripBooks();
        int GetTotalTripBookOf(List<string> args);
    }

    public class TripBookService : ITripBookService
    {
        private readonly ITripBookRepository TripBookRepository;
        private readonly IUnitOfWork unitOfWork;

        public TripBookService(ITripBookRepository TripBookRepository, IUnitOfWork unitOfWork)
        {
            this.TripBookRepository = TripBookRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateTripBook(TripBook TripBook)
        {
            TripBookRepository.Add(TripBook);
            SaveTripBook();
        }

        public void EditTripBook(TripBook TripBook)
        {
            TripBookRepository.Update(TripBook);
            SaveTripBook();
        }

        public TripBook GetTripBook(int id)
        {
            var TripBook = TripBookRepository.GetById(id);
            return TripBook;
        }

        public TripBook GetTripBook(int? TripBookId)
        {
            if (TripBookId != null)
            {
                var TripBook = TripBookRepository.GetById((int)TripBookId);
                return TripBook;
            }
            return null;
        }

        //public TripBook GetTripBookByUserId(string userId)
        //{
        //    TripBook TripBook = TripBookRepository.GetById(userId);
        //    return TripBook;
        //}

        //public IEnumerable<TripBook> GetTripBooks(string name = null)
        //{
        //    if (string.IsNullOrEmpty(name))
        //        return TripBookRepository.GetAll();
        //    else
        //        return TripBookRepository.GetAll().Where(c => c.Name.Contains(name));
        //}

        //public IEnumerable<TripBook> GetTripBooksByName(string name, int curr, int take)
        //{
        //    if (string.IsNullOrEmpty(name))
        //        return null;
        //    else
        //        return TripBookRepository.GetTripBooksByName(name, curr, take);
        //}

        public int GetTotalTripBookOf(List<string> args)
        {
            if (args != null)
            {
                return TripBookRepository.GetTotalTripBooksOf(args);
            }
            return 0;
        }

        public int GetTotalTripBooks()
        {
            return TripBookRepository.GetTotalTripBooks();
        }

        public void RemoveTripBook(int id)
        {
            TripBook p = TripBookRepository.GetById(id);
            p.IsRemoved = false;
            TripBookRepository.Update(p);
            SaveTripBook();
        }

        public void SaveTripBook()
        {
            unitOfWork.Commit();
        }

        public void UnRemoveTripBook(int id)
        {
            TripBook p = TripBookRepository.GetById(id);
            p.IsRemoved = true;
            TripBookRepository.Update(p);
            SaveTripBook();
        }
    }
}
