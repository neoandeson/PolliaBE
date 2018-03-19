using DataLayer.Infrastucture;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ScopeRepository : RepositoryBase<Scope>, IScopeRepository
    {
        public ScopeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Scope GetById(int? ScopeId)
        {
            if (ScopeId != null)
            {
                Scope Scope = this.DbContext.Scopes.Where(p => p.Id == ScopeId).FirstOrDefault();
                return Scope;
            }
            return null;
        }

        public Scope GetScopeByLongLat(float slongitude, float elongitude, float slatitude, float elatitude)
        {
            Scope Scope = this.DbContext.Scopes.Where(p => p.StartLongitude == slongitude && p.StartLatitude == slatitude && p.EndLongitude == elongitude && p.EndLongitude == elongitude).FirstOrDefault();
            return Scope;
        }

        //public List<Scope> GetScopeNearBy(float longitude, float latitude, float distance, int scope)
        //{
        //    List<Scope> Scopes = this.DbContext.Scopes.Where(p => ((Math.Abs((p.Longitude - longitude)) < distance) && (Math.Abs((p.Latitude - latitude)) < distance)) && (p.ScopeKindId == scope)).Take(20).ToList();
        //    return Scopes;
        //}
    }

    public interface IScopeRepository : IRepository<Scope>
    {
        Scope GetScopeByLongLat(float slongitude, float elongitude, float slatitude, float elatitude);
        //List<Scope> GetScopeNearBy(float longitude, float latitude, float distance, int scope);
        Scope GetById(int? ScopeId);
    }
}
