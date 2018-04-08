using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pollia.ViewModels
{
    public class PlaceViewModel
    {
        public PlaceViewModel() { }

        public PlaceViewModel(string name, string description, double longitude, double latitude, double? zoomSize, int? scopeId, string address, int serveStatus, string placeKind, int? timeOpen, int? timeClose, int ratingStar, int nofSearch, int popular, int pLike, string facebook, string instagram, string pageUrl, string imgUrl, string userId, string phoneNumber, DateTime? dateCreate, DateTime? lastConfirm, string lastUpdateUserId, int? prevPlaceId, int? nextPlaceId)
        {
            Name = name;
            Description = description;
            Longitude = longitude;
            Latitude = latitude;
            ZoomSize = zoomSize;
            ScopeId = scopeId;
            Address = address;
            ServeStatus = serveStatus;
            PlaceKind = placeKind;
            TimeOpen = timeOpen;
            TimeClose = timeClose;
            RatingStar = ratingStar;
            NofSearch = nofSearch;
            Popular = popular;
            PLike = pLike;
            Facebook = facebook;
            Instagram = instagram;
            PageUrl = pageUrl;
            ImageUrl = imgUrl;
            UserId = userId;
            PhoneNumber = phoneNumber;
            DateCreate = dateCreate;
            LastConfirm = lastConfirm;
            LastUpdateUserId = lastUpdateUserId;
            PrevPlaceId = prevPlaceId;
            NextPlaceId = nextPlaceId;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public Nullable<double> ZoomSize { get; set; }
        public Nullable<int> ScopeId { get; set; }
        public string Address { get; set; }
        public int ServeStatus { get; set; }
        public string PlaceKind { get; set; }
        public Nullable<int> TimeOpen { get; set; }
        public Nullable<int> TimeClose { get; set; }
        public int RatingStar { get; set; }
        public int NofSearch { get; set; }
        public int Popular { get; set; }
        public int PLike { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string PageUrl { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<System.DateTime> LastConfirm { get; set; }
        public string LastUpdateUserId { get; set; }
        public Nullable<int> PrevPlaceId { get; set; }
        public Nullable<int> NextPlaceId { get; set; }
    }
}