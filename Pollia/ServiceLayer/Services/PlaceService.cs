﻿using System.Text;
using System.Threading.Tasks;
using DataLayer.Infrastucture;
//using Pollia.DataLayer;
using ModelLayer.Models;
using System.Collections.Generic;
using DataLayer.Repositories;
using System.Linq;

namespace ServiceLayer.Services
{
    public interface IPlaceService
    {
        IEnumerable<Place> GetPlaces(string name = null);
        IEnumerable<Place> GetNPlaces(int quantity);
        Place GetPlace(int id);
        Place GetPlace(string name);
        Place GetPlaceByAddress(string address);
        void CreatePlace(Place Place);
        void EditPlace(Place Place);
        void RemovePlace(int id);
        void SavePlace();
        void UnRemovePlace(int id);
        Place GetPlace(int? placeId);
        List<Place> GetPlacesNearBy(float longitude, float latitude, float distance, int scope);
        IEnumerable<Place> GetPlacesByName(string name, int curr, int take);
        int GetTotalPlaces();
        int GetTotalPlacesOf(List<string> args);
    }

    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository PlaceRepository;
        private readonly IUnitOfWork unitOfWork;

        public PlaceService(IPlaceRepository PlaceRepository, IUnitOfWork unitOfWork)
        {
            this.PlaceRepository = PlaceRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreatePlace(Place Place)
        {
            PlaceRepository.Add(Place);
            SavePlace();
        }

        public void EditPlace(Place Place)
        {
            PlaceRepository.Update(Place);
            SavePlace();
        }

        public IEnumerable<Place> GetNPlaces(int quantity)
        {
            return PlaceRepository.GetAll().Skip(0).Take(quantity);
        }

        public Place GetPlace(int id)
        {
            var Place = PlaceRepository.GetById(id);
            return Place;
        }

        public Place GetPlace(string name)
        {
            var Place = PlaceRepository.GetPlaceByName(name);
            return Place;
        }

        public Place GetPlace(int? placeId)
        {
            if (placeId != null)
            {
                var Place = PlaceRepository.GetById((int)placeId);
                return Place;
            }
            return null;
        }

        public Place GetPlaceByAddress(string address)
        {
            Place place = PlaceRepository.GetPlaceByAddress(address);
            return place;
        }

        public IEnumerable<Place> GetPlaces(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return PlaceRepository.GetAll();
            else
                return PlaceRepository.GetAll().Where(c => c.Name.Equals(name));
        }

        public IEnumerable<Place> GetPlacesByName(string name, int curr, int take)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            else
                return PlaceRepository.GetPlacesByName(name, curr, take);
        }

        public List<Place> GetPlacesNearBy(float longitude, float latitude, float distance, int scope)
        {
            return PlaceRepository.GetPlaceNearBy(longitude, latitude, distance, scope);
        }

        public int GetTotalPlaces()
        {
            return PlaceRepository.GetTotalPlaces();
        }

        public int GetTotalPlacesOf(List<string> args)
        {
            return PlaceRepository.GetTotalPlacesOf(args);
        }

        public void RemovePlace(int id)
        {
            Place p = PlaceRepository.GetById(id);
            p.ServeStatus = 0;
            PlaceRepository.Update(p);
            SavePlace();
        }

        public void SavePlace()
        {
            unitOfWork.Commit();
        }

        public void UnRemovePlace(int id)
        {
            Place p = PlaceRepository.GetById(id);
            p.ServeStatus = 1;
            PlaceRepository.Update(p);
            SavePlace();
        }
    }

}
