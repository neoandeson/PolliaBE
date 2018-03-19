using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pollia.Models
{
    public class RoleViewModel
    {
        public RoleViewModel() {}
        public RoleViewModel(ApplicationRole role)
        {
            this.Id = role.Id;
            this.Name = role.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}