using DataLayer.Infrastucture;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserRepository : RepositoryBase<AspNetUser>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public AspNetUser GetById(string userId)
        {
            if (userId != null)
            {
                AspNetUser AspNetUser = this.DbContext.AspNetUsers.Where(p => p.Id == userId).FirstOrDefault();
                return AspNetUser;
            }
            return null;
        }

        public int GetTotalUser()
        {
            return this.DbContext.AspNetUsers.Count();
        }

        public AspNetUser GetUserByEmail(string email)
        {
            AspNetUser AspNetUser = this.DbContext.AspNetUsers.Where(p => p.Email == email).FirstOrDefault();
            return AspNetUser;
        }

        public AspNetUser GetUserByName(string name)
        {
            AspNetUser AspNetUser = this.DbContext.AspNetUsers.Where(p => p.FullName.Contains(name)).FirstOrDefault();
            return AspNetUser;
        }

        //public List<AspNetUser> GetAspNetUserNearBy(float longitude, float latitude, float distance, int scope)
        //{
        //    List<AspNetUser> AspNetUsers = this.DbContext.AspNetUsers.Where(p => ((Math.Abs((p.Longitude - longitude)) < distance) && (Math.Abs((p.Latitude - latitude)) < distance)) && (p.AspNetUserKindId == scope)).Take(20).ToList();
        //    return AspNetUsers;
        //}

        public IEnumerable<AspNetUser> GetUsersByName(string name, int curr, int take)
        {
            IEnumerable<AspNetUser> AspNetUsers = this.DbContext.AspNetUsers.Where(p => p.FullName.Contains(name)).OrderBy(p => p.Points).Skip(curr).Take(take);
            return AspNetUsers;
        }
    }

    public interface IUserRepository : IRepository<AspNetUser>
    {
        AspNetUser GetUserByEmail(string email);
        AspNetUser GetUserByName(string name);
        IEnumerable<AspNetUser> GetUsersByName(string name, int curr, int take);
        //List<AspNetUser> GetAspNetUserNearBy(float longitude, float latitude, float distance, int scope);
        AspNetUser GetById(string userId);
        int GetTotalUser();
    }
}
