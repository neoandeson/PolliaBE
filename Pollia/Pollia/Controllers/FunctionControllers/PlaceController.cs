using DataLayer;
using ModelLayer.Models;
using Pollia.ViewModels;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pollia.Controllers.FunctionControllers
{
    public class PlaceController : ApiController
    {
        private readonly IPlaceService _placeService;
        private readonly IPlaceKindService _placeKindService;

        public PlaceController(IPlaceService placeService, IPlaceKindService placeKindService)
        {
            _placeService = placeService;
            _placeKindService = placeKindService;
        }

        public IHttpActionResult GetPlaces()
        {
            try
            {
                IEnumerable<Place> places = _placeService.GetPlaces();
                List<PlaceViewModel> placeVMs = new List<PlaceViewModel>();
                PlaceViewModel placeVM = null;
                PlaceKind placeKind;
                foreach (var place in places)
                {
                    placeKind = _placeKindService.GetPlaceKind(place.PlaceKindId);
                    placeVM = new PlaceViewModel(
                    place.Id,
                    place.Name,
                    place.Description,
                    place.Longitude,
                    place.Latitude,
                    place.ZoomSize,
                    place.ScopeId,
                    place.Address,
                    place.ServeStatus,
                    placeKind != null ? placeKind.Description : place.PlaceKindId + "",
                    place.TimeOpen,
                    place.TimeClose,
                    place.RatingStar,
                    place.NofSearch,
                    place.Popular,
                    place.PLike,
                    place.Facebook,
                    place.Instagram,
                    place.PageUrl,
                    place.ImgUrl,
                    place.UserId,
                    place.PhoneNumber,
                    place.DateCreate,
                    place.LastConfirm,
                    place.LastUpdateUserId,
                    place.PrevPlaceId,
                    place.NextPlaceId
                    );
                    placeVMs.Add(placeVM);
                }
                return Ok(placeVMs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Get10Places()
        {
            try
            {
                IEnumerable<Place> places = _placeService.GetNPlaces(10);
                List<PlaceViewModel> placeVMs = new List<PlaceViewModel>();
                PlaceViewModel placeVM = null;
                PlaceKind placeKind;
                foreach (var place in places)
                {
                    placeKind = _placeKindService.GetPlaceKind(place.PlaceKindId);
                    placeVM = new PlaceViewModel(
                    place.Id,
                    place.Name,
                    place.Description,
                    place.Longitude,
                    place.Latitude,
                    place.ZoomSize,
                    place.ScopeId,
                    place.Address,
                    place.ServeStatus,
                    placeKind != null ? placeKind.Description : place.PlaceKindId + "",
                    place.TimeOpen,
                    place.TimeClose,
                    place.RatingStar,
                    place.NofSearch,
                    place.Popular,
                    place.PLike,
                    place.Facebook,
                    place.Instagram,
                    place.PageUrl,
                    place.ImgUrl,
                    place.UserId,
                    place.PhoneNumber,
                    place.DateCreate,
                    place.LastConfirm,
                    place.LastUpdateUserId,
                    place.PrevPlaceId,
                    place.NextPlaceId
                    );
                    placeVMs.Add(placeVM);
                }
                return Ok(placeVMs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult GetPlaceByName(string name)
        {
            if (!String.IsNullOrEmpty(name.Trim()))
            {
                try
                {
                    Place place = _placeService.GetPlace(name);
                    PlaceKind placeKind;
                    if (place != null)
                    {
                        placeKind = _placeKindService.GetPlaceKind(place.PlaceKindId);
                        PlaceViewModel placeVM = new PlaceViewModel(
                            place.Id,
                            place.Name,
                            place.Description,
                            place.Longitude,
                            place.Latitude,
                            place.ZoomSize,
                            place.ScopeId,
                            place.Address,
                            place.ServeStatus,
                            placeKind != null ? placeKind.Description : place.PlaceKindId + "",
                            place.TimeOpen,
                            place.TimeClose,
                            place.RatingStar,
                            place.NofSearch,
                            place.Popular,
                            place.PLike,
                            place.Facebook,
                            place.Instagram,
                            place.PageUrl,
                            place.ImgUrl,
                            place.UserId,
                            place.PhoneNumber,
                            place.DateCreate,
                            place.LastConfirm,
                            place.LastUpdateUserId,
                            place.PrevPlaceId,
                            place.NextPlaceId
                            );
                        return Ok(placeVM);
                    }
                    return Ok("Not Found");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("Name is not valid");
            }
        }

        public IHttpActionResult GetPlacesByName(string name, int curr, int take)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                IEnumerable<Place> places = _placeService.GetPlacesByName(name, curr, take);
                if (places != null)
                {
                    List<PlaceViewModel> placeVMs = new List<PlaceViewModel>();
                    PlaceViewModel placeVM;
                    PlaceKind placeKind;
                    foreach (var place in places)
                    {
                        placeKind = _placeKindService.GetPlaceKind(place.PlaceKindId);
                        placeVM = new PlaceViewModel(
                            place.Id,
                            place.Name,
                            place.Description,
                            place.Longitude,
                            place.Latitude,
                            place.ZoomSize,
                            place.ScopeId,
                            place.Address,
                            place.ServeStatus,
                            placeKind != null ? placeKind.Description : place.PlaceKindId + "",
                            place.TimeOpen,
                            place.TimeClose,
                            place.RatingStar,
                            place.NofSearch,
                            place.Popular,
                            place.PLike,
                            place.Facebook,
                            place.Instagram,
                            place.PageUrl,
                            place.ImgUrl,
                            place.UserId,
                            place.PhoneNumber,
                            place.DateCreate,
                            place.LastConfirm,
                            place.LastUpdateUserId,
                            place.PrevPlaceId,
                            place.NextPlaceId
                            );
                        placeVMs.Add(placeVM);
                    }
                    return Ok(placeVMs);
                }
                return Ok("Not found");
            }
            else
                return BadRequest();
        }

        public IHttpActionResult GetPlace(int id)
        {
            try
            {
                Place place = _placeService.GetPlace(id);
                if (place != null)
                {
                    var user = System.Web.HttpContext.Current.User.Identity.Name;
                    var placeKind = _placeKindService.GetPlaceKind(place.PlaceKindId);
                    PlaceViewModel placeVM = new PlaceViewModel(
                                place.Id,
                                place.Name,
                                place.Description,
                                place.Longitude,
                                place.Latitude,
                                place.ZoomSize,
                                place.ScopeId,
                                place.Address,
                                place.ServeStatus,
                                placeKind != null ? placeKind.Description : place.PlaceKindId + "",
                                place.TimeOpen,
                                place.TimeClose,
                                place.RatingStar,
                                place.NofSearch,
                                place.Popular,
                                place.PLike,
                                place.Facebook,
                                place.Instagram,
                                place.PageUrl,
                                place.ImgUrl,
                                place.UserId,
                                place.PhoneNumber,
                                place.DateCreate,
                                place.LastConfirm,
                                place.LastUpdateUserId,
                                place.PrevPlaceId,
                                place.NextPlaceId
                                );
                    return Ok(placeVM);
                }
                return Ok("Not Found");
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
            
        }

    }
}
