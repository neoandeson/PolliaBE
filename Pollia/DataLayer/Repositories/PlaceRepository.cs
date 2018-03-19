using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using DataLayer.Infrastucture;
using ModelLayer.Models;

namespace DataLayer.Repositories
{
    public class PlaceRepository : RepositoryBase<Place>, IPlaceRepository
    {
        public PlaceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Place GetById(int? placeId)
        {
            if (placeId != null)
            {
                Place place = this.DbContext.Places.Where(p => p.Id == placeId).FirstOrDefault();
                return place;
            }
            return null;
        }

        public Place GetPlaceByAddress(string address)
        {
            Place place = this.DbContext.Places.Where(p => p.Address == address).FirstOrDefault();
            return place;
        }

        public Place GetPlaceByName(string placeName)
        {
            Place place = this.DbContext.Places.Where(p => p.Name.Contains(placeName) ).FirstOrDefault();
            return place;
        }

        public List<Place> GetPlaceNearBy(float longitude, float latitude, float distance, int scope)
        {
            List<Place> places = this.DbContext.Places.Where(p => ((Math.Abs((p.Longitude - longitude)) < distance) && (Math.Abs((p.Latitude - latitude)) < distance)) && (p.PlaceKindId == scope)).Take(20).ToList();
            return places;
        }

        public IEnumerable<Place> GetPlacesByName(string placeName, int curr, int take)
        {
            IEnumerable<Place> places = this.DbContext.Places.Where(p => p.Name.Contains(placeName)).OrderBy(q => q.Id).Skip(curr).Take(take);
            return places;
        }

        public int GetTotalPlaces()
        {
            return this.DbContext.Places.Count();
        }

        public int GetTotalPlacesOf(List<string> args)
        {
            return this.DbContext.Places.Where(q => args.Contains(q.UserId)).Count();
        }
    }

    public interface IPlaceRepository : IRepository<Place>
    {
        Place GetPlaceByAddress(string address);
        Place GetPlaceByName(string placeName);
        IEnumerable<Place> GetPlacesByName(string placeName, int curr, int take);
        List<Place> GetPlaceNearBy(float longitude, float latitude, float distance, int scope);
        Place GetById(int? placeId);
        int GetTotalPlaces();
        int GetTotalPlacesOf(List<string> args);
    }
}
