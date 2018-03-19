﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pollia.ViewModels
{
    public class CreatePlaceViewModel
    {
        public CreatePlaceViewModel()
        {

        }

        public CreatePlaceViewModel(string name, string description, double longitude, double latitude, double? zoomSize, string address, int placeKindId, int? timeOpen, int? timeClose, int ratingStar, int nofSearch, int popular, int pLike, string facebook, string instagram, string pageUrl, string userId, string phoneNumber)
        {
            Name = name;
            Description = description;
            Longitude = longitude;
            Latitude = latitude;
            ZoomSize = zoomSize;
            Address = address;
            PlaceKindId = placeKindId;
            TimeOpen = timeOpen;
            TimeClose = timeClose;
            RatingStar = ratingStar;
            NofSearch = nofSearch;
            Popular = popular;
            PLike = pLike;
            Facebook = facebook;
            Instagram = instagram;
            PageUrl = pageUrl;
            UserId = userId;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public Nullable<double> ZoomSize { get; set; }
        public string Address { get; set; }
        public int PlaceKindId { get; set; }
        public Nullable<int> TimeOpen { get; set; }
        public Nullable<int> TimeClose { get; set; }
        public int RatingStar { get; set; }
        public int NofSearch { get; set; }
        public int Popular { get; set; }
        public int PLike { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string PageUrl { get; set; }
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
    }
}