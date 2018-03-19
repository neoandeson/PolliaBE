using DataLayer.Infrastucture;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class PlaceKindRepository : RepositoryBase<PlaceKind>, IPlaceKindRepository
    {
        public PlaceKindRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public PlaceKind GetById(int? PlaceKindId)
        {
            if (PlaceKindId != null)
            {
                PlaceKind PlaceKind = this.DbContext.PlaceKinds.Where(p => p.Id == PlaceKindId).FirstOrDefault();
                return PlaceKind;
            }
            return null;
        }
    }

    public interface IPlaceKindRepository : IRepository<PlaceKind>
    {
        PlaceKind GetById(int? PlaceKindId);
    }
}
