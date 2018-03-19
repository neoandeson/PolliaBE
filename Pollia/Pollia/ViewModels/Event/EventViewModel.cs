using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pollia.ViewModels.Event
{
    public class EventViewModel
    {
        public EventViewModel()
        {

        }

        public EventViewModel(int id, string userId, string title, string description, string page, string pageUrl, string imgUrl, string phoneNumber, int eventKindId, int placeId, int? scopeId, int serveStatus, int ratingStar, int nofSearch, int poppular, int pLike, string facebook, string instagram, int? timeOpen, int? timeClose, DateTime? dateCreate, DateTime dateStart, DateTime dateEnd, DateTime? lastConfirm)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Description = description;
            Page = page;
            PageUrl = pageUrl;
            ImgUrl = imgUrl;
            PhoneNumber = phoneNumber;
            EventKindId = eventKindId;
            PlaceId = placeId;
            ScopeId = scopeId;
            ServeStatus = serveStatus;
            RatingStar = ratingStar;
            NofSearch = nofSearch;
            Poppular = poppular;
            PLike = pLike;
            Facebook = facebook;
            Instagram = instagram;
            TimeOpen = timeOpen;
            TimeClose = timeClose;
            DateCreate = dateCreate;
            DateStart = dateStart;
            DateEnd = dateEnd;
            LastConfirm = lastConfirm;
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Page { get; set; }

        public string PageUrl { get; set; }

        public string ImgUrl { get; set; }

        public string PhoneNumber { get; set; }

        public int EventKindId { get; set; }

        public int PlaceId { get; set; }

        public int? ScopeId { get; set; }

        public int ServeStatus { get; set; }

        public int RatingStar { get; set; }

        public int NofSearch { get; set; }

        public int Poppular { get; set; }

        public int PLike { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public int? TimeOpen { get; set; }

        public int? TimeClose { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public DateTime? LastConfirm { get; set; }
    }
}