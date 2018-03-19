using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pollia.Models
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel() {}
        public UserRoleViewModel(string userId, string fullName, string email, IEnumerable<SelectListItem> rolesList)
        {
            this.UserId = userId;
            this.FullName = fullName;
            this.RolesList = rolesList;
            this.Email = email;
        }

        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public IEnumerable<SelectListItem> RolesList{ get; set; }
    }
}