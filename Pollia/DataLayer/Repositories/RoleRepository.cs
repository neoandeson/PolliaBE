using DataLayer.Infrastucture;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class RoleRepository : RepositoryBase<AspNetRole>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public AspNetRole GetById(string roleId)
        {
            if (roleId != null)
            {
                AspNetRole Role = this.DbContext.AspNetRoles.Where(r => r.Id == roleId).FirstOrDefault();
                return Role;
            }
            return null;
        }

        public int GetTotalUsersOfRole(string roleName)
        {
            return this.DbContext.AspNetRoles.Where(r => r.Name.Contains(roleName)).FirstOrDefault().AspNetUsers.Count();
        }

        public IEnumerable<AspNetRole> GetRolesByName(string RoleName)
        {
            IEnumerable<AspNetRole> Roles = this.DbContext.AspNetRoles.Where(p => p.Name.Contains(RoleName));
            return Roles;
        }

        public List<string> GetUsersOfRoles(string roleName)
        {
            var roles = this.DbContext.AspNetRoles.Where(r => r.Name.Contains(roleName));
            List<string> userIds = new List<string>();
            foreach (var r in roles)
            {
                foreach (var u in r.AspNetUsers)
                {
                    userIds.Add(u.Id);
                }
            }
            return userIds;
        }
    }

    public interface IRoleRepository : IRepository<AspNetRole>
    {
        IEnumerable<AspNetRole> GetRolesByName(string roleName);
        AspNetRole GetById(string roleId);
        List<string> GetUsersOfRoles(string roleName);
        int GetTotalUsersOfRole(string roleName);
    }
}
