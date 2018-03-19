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
    public interface IImageService
    {
        Image GetImage(int id);
        void CreateImage(Image Image);
        void EditImage(Image Image);
        void SaveImage();
        Image GetImage(int? ImageId);
        IEnumerable<Image> GetImages();
    }

    public class ImageService : IImageService
    {
        private readonly IImageRepository ImageRepository;
        private readonly IUnitOfWork unitOfWork;

        public ImageService(IImageRepository ImageRepository, IUnitOfWork unitOfWork)
        {
            this.ImageRepository = ImageRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateImage(Image Image)
        {
            ImageRepository.Add(Image);
            SaveImage();
        }

        public void EditImage(Image Image)
        {
            ImageRepository.Update(Image);
            SaveImage();
        }

        public Image GetImage(int id)
        {
            var Image = ImageRepository.GetById(id);
            return Image;
        }

        public Image GetImage(int? ImageId)
        {
            if (ImageId != null)
            {
                var Image = ImageRepository.GetById((int)ImageId);
                return Image;
            }
            return null;
        }

        public IEnumerable<Image> GetImages()
        {
            return ImageRepository.GetAll();
        }

        public void SaveImage()
        {
            unitOfWork.Commit();
        }
    }
}
