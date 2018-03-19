using DataLayer.Infrastucture;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Image GetById(int? ImageId)
        {
            if (ImageId != null)
            {
                Image Image = this.DbContext.Images.Where(p => p.Id == ImageId).FirstOrDefault();
                return Image;
            }
            return null;
        }
    }

    public interface IImageRepository : IRepository<Image>
    {
        Image GetById(int? ImageId);
    }
}
