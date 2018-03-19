using ModelLayer.Models;
using Pollia.Utils;
using Pollia.ViewModels;
using Pollia.ViewModels.Place;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pollia.Controllers.FunctionControllers
{
    public class TestPlaceController : ApiController
    {
        private readonly IPlaceService _placeService;

        public TestPlaceController(IPlaceService _placeService)
        {
            this._placeService = _placeService;
        }

        //public IHttpActionResult GetPlaces()
        //{
        //    try
        //    {
        //        IEnumerable<Place> places = _placeService.GetPlaces();
        //        List<PlaceViewModel> placeVMs = new List<PlaceViewModel>();
        //        PlaceViewModel placeVM = null;
        //        foreach (var place in places)
        //        {
        //            placeVM = new PlaceViewModel(
        //            place.Id,
        //            place.Name,
        //            place.Description,
        //            place.Longitude,
        //            place.Latitude,
        //            place.ZoomSize,
        //            place.ScopeId,
        //            place.Address,
        //            place.ServeStatus,
        //            place.PlaceKindId,
        //            place.TimeOpen,
        //            place.TimeClose,
        //            place.RatingStar,
        //            place.NofSearch,
        //            place.Popular,
        //            place.PLike,
        //            place.Facebook,
        //            place.Instagram,
        //            place.PageUrl,
        //            place.ImgUrl,
        //            place.UserId,
        //            place.PhoneNumber,
        //            place.DateCreate,
        //            place.LastConfirm,
        //            place.LastUpdateUserId,
        //            place.PrevPlaceId,
        //            place.NextPlaceId
        //            );
        //            placeVMs.Add(placeVM);
        //        }
        //        return Ok(placeVMs);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
            
        //}

        //public IHttpActionResult GetPlaceById(int Id)
        //{
        //    try
        //    {
        //        Place place = _placeService.GetPlace(Id);
        //        PlaceViewModel placeVM = new PlaceViewModel(
        //            place.Id,
        //            place.Name,
        //            place.Description,
        //            place.Longitude,
        //            place.Latitude,
        //            place.ZoomSize,
        //            place.ScopeId,
        //            place.Address,
        //            place.ServeStatus,
        //            place.PlaceKindId,
        //            place.TimeOpen,
        //            place.TimeClose,
        //            place.RatingStar,
        //            place.NofSearch,
        //            place.Popular,
        //            place.PLike,
        //            place.Facebook,
        //            place.Instagram,
        //            place.PageUrl,
        //            place.ImgUrl,
        //            place.UserId,
        //            place.PhoneNumber,
        //            place.DateCreate,
        //            place.LastConfirm,
        //            place.LastUpdateUserId,
        //            place.PrevPlaceId,
        //            place.NextPlaceId
        //        );
        //        return Ok(placeVM);
        //    }
        //    catch (Exception e)
        //    {
        //        return Content(System.Net.HttpStatusCode.InternalServerError, e.Message);
        //    }

        //}

        public IHttpActionResult Create(CreatePlaceViewModel createPlaceVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                Place place = new Place();
                place.Id = 0;//Identity in DB
                place.Name = createPlaceVM.Name;
                place.Description = createPlaceVM.Description;
                place.Longitude = createPlaceVM.Longitude;
                place.Latitude = createPlaceVM.Latitude;
                place.ZoomSize = createPlaceVM.ZoomSize;
                place.Address = createPlaceVM.Address;
                place.ServeStatus = (int) Utils.EPlaceServeStatus.Unconfirmed;
                place.PlaceKindId = createPlaceVM.PlaceKindId;
                place.TimeOpen = createPlaceVM.TimeOpen;
                place.TimeClose = createPlaceVM.TimeClose;
                place.RatingStar = createPlaceVM.RatingStar;
                place.NofSearch = createPlaceVM.NofSearch;
                place.Popular = createPlaceVM.Popular;
                place.PLike = createPlaceVM.PLike;
                place.Facebook = createPlaceVM.Facebook;
                place.Instagram = createPlaceVM.Instagram;
                place.PageUrl = createPlaceVM.PageUrl;
                place.UserId = createPlaceVM.UserId;
                place.PhoneNumber = createPlaceVM.PhoneNumber;
                place.DateCreate = DateTime.Today;
                place.LastConfirm = DateTime.Today;
                place.LastUpdateUserId = HttpContext.Current.User.Identity.Name;
                //place.LastUpdateUserId = HttpContext.Current.User.Identity.Name;

                _placeService.CreatePlace(place);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult Edit(EditPlaceViewModel editPlaceVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                Place place = _placeService.GetPlace(editPlaceVM.Id);
                place.Id = editPlaceVM.Id;//Identity in DB
                place.Name = editPlaceVM.Name;
                place.Description = editPlaceVM.Description;
                place.ScopeId = editPlaceVM.ScopeId;
                place.Longitude = editPlaceVM.Longitude;
                place.Latitude = editPlaceVM.Latitude;
                place.ZoomSize = editPlaceVM.ZoomSize;
                place.Address = editPlaceVM.Address;
                place.ServeStatus = editPlaceVM.ServeStatus;
                place.PlaceKindId = editPlaceVM.PlaceKindId;
                place.TimeOpen = editPlaceVM.TimeOpen;
                place.TimeClose = editPlaceVM.TimeClose;
                place.RatingStar = editPlaceVM.RatingStar;
                place.NofSearch = editPlaceVM.NofSearch;
                place.Popular = editPlaceVM.Popular;
                place.PLike = editPlaceVM.PLike;
                place.Facebook = editPlaceVM.Facebook;
                place.Instagram = editPlaceVM.Instagram;
                place.PageUrl = editPlaceVM.PageUrl;
                place.UserId = editPlaceVM.UserId;
                place.PhoneNumber = editPlaceVM.PhoneNumber;
                place.DateCreate = DateTime.Today;
                place.LastConfirm = DateTime.Today;
                place.LastUpdateUserId = "A";
                place.PrevPlaceId = editPlaceVM.PrevPlaceId;
                place.NextPlaceId = editPlaceVM.NextPlaceId;
                //place.LastUpdateUserId = HttpContext.Current.User.Identity.Name;

                _placeService.EditPlace(place);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, e.Message);
            }
        }


        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ApiCustomAuthorize(Roles = "Admin")]
        public IHttpActionResult Delete(int Id)
        {
            try
            {
                Place place = _placeService.GetPlace(Id);
                if (place != null)
                {
                    place.ServeStatus = (int)EPlaceServeStatus.Closed;
                    _placeService.EditPlace(place);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, e.Message);
            }
            
        }
    }
}