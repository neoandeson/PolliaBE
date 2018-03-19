using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pollia.Controllers.FunctionControllers
{
    public class ImageController : ApiController
    {
        private readonly IImageService _imageService;
        private readonly IPlaceService _placeService;

        public ImageController(IImageService imageService, IPlaceService placeService)
        {
            _imageService = imageService;
            _placeService = placeService;
        }

        public IHttpActionResult AddPlacesImages()
        {
            var places = _placeService.GetPlaces();
            var images = _imageService.GetImages();

            foreach (var place in places)
            {
                var image = images.Where(q => q.OwnId == place.Id).FirstOrDefault();
                place.ImgUrl = image.Url;
                _placeService.EditPlace(place);
            }
            return Ok();
        }
    }
}