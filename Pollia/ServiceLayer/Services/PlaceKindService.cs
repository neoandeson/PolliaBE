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
    public interface IPlaceKindService
    {
        PlaceKind GetPlaceKind(int id);
        void CreatePlaceKind(PlaceKind PlaceKind);
        void EditPlaceKind(PlaceKind PlaceKind);
        void SavePlaceKind();
        PlaceKind GetPlaceKind(int? PlaceKindId);
    }

    public class PlaceKindService : IPlaceKindService
    {
        private readonly IPlaceKindRepository PlaceKindRepository;
        private readonly IUnitOfWork unitOfWork;

        public PlaceKindService(IPlaceKindRepository PlaceKindRepository, IUnitOfWork unitOfWork)
        {
            this.PlaceKindRepository = PlaceKindRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreatePlaceKind(PlaceKind PlaceKind)
        {
            PlaceKindRepository.Add(PlaceKind);
            SavePlaceKind();
        }

        public void EditPlaceKind(PlaceKind PlaceKind)
        {
            PlaceKindRepository.Update(PlaceKind);
            SavePlaceKind();
        }

        public PlaceKind GetPlaceKind(int id)
        {
            var PlaceKind = PlaceKindRepository.GetById(id);
            return PlaceKind;
        }

        public PlaceKind GetPlaceKind(int? PlaceKindId)
        {
            if (PlaceKindId != null)
            {
                var PlaceKind = PlaceKindRepository.GetById((int)PlaceKindId);
                return PlaceKind;
            }
            return null;
        }

        public void SavePlaceKind()
        {
            unitOfWork.Commit();
        }
    }
}
