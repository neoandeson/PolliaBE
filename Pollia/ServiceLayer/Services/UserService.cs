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
    public interface IUserService
    {
        IEnumerable<AspNetUser> GetUsers(string name = null);
        AspNetUser GetUser(int id);
        AspNetUser GetUser(string name);
        AspNetUser GetUserByAddress(string address);
        AspNetUser GetUser(int? UserId);
        //List<User> GetUsersNearBy(float longitude, float latitude, float distance, int scope);
        IEnumerable<AspNetUser> GetUsersByName(string name, int curr, int take);
        int GetTotalUsers();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository EventRepository, IUnitOfWork unitOfWork)
        {
            this.UserRepository = EventRepository;
            this.unitOfWork = unitOfWork;
        }

        public int GetTotalUsers()
        {
            return UserRepository.GetTotalUser();
        }

        public AspNetUser GetUser(int id)
        {
            var user = UserRepository.GetById(id);
            return user;
        }

        public AspNetUser GetUser(string name)
        {
            var User = UserRepository.GetUserByName(name);
            return User;
        }

        public AspNetUser GetUser(int? UserId)
        {
            if (UserId != null)
            {
                var User = UserRepository.GetById((int)UserId);
                return User;
            }
            return null;
        }

        public AspNetUser GetUserByAddress(string email)
        {
            AspNetUser User = UserRepository.GetUserByEmail(email);
            return User;
        }

        public IEnumerable<AspNetUser> GetUsers(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return UserRepository.GetAll();
            else
                return UserRepository.GetAll().Where(c => c.FullName.Contains(name));
        }

        public IEnumerable<AspNetUser> GetUsersByName(string name, int curr, int take)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            else
                return UserRepository.GetUsersByName(name, curr, take);
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }
    }
}
