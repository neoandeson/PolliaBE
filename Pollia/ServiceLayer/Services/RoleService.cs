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
    public interface IRoleService
    {
        IEnumerable<AspNetRole> GetRoles(string name = null);
        AspNetRole GetRole(string roleId);
        int GetTotalUsersOfRoles(string roleName);
        List<string> GetUsersOfRoles(string roleName);
    }

    public class RoleService : IRoleService
    {
        private readonly IRoleRepository RoleRepository;
        private readonly IUnitOfWork unitOfWork;

        public RoleService(IRoleRepository EventRepository, IUnitOfWork unitOfWork)
        {
            this.RoleRepository = EventRepository;
            this.unitOfWork = unitOfWork;
        }

        public AspNetRole GetRole(int id)
        {
            var Role = RoleRepository.GetById(id);
            return Role;
        }

        public AspNetRole GetRole(string RoleId)
        {
            if (RoleId != null)
            {
                var Role = RoleRepository.GetById(RoleId);
                return Role;
            }
            return null;
        }

        public IEnumerable<AspNetRole> GetRoles(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return RoleRepository.GetAll();
            else
                return RoleRepository.GetAll().Where(c => c.Name.Contains(name));
        }

        public int GetTotalUsersOfRoles(string roleName)
        {
            return RoleRepository.GetTotalUsersOfRole(roleName);
        }

        public List<string> GetUsersOfRoles(string roleName)
        {
            return RoleRepository.GetUsersOfRoles(roleName);
        }

        public void SaveRole()
        {
            unitOfWork.Commit();
        }
    }
}
