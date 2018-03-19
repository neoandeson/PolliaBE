using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pollia.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        //Updateable
        public string FullName { get; set; }
        public int Province { get; set; }
        public int District { get; set; }
        public int Ward { get; set; }
        public string AvatarUrl { get; set; }

    }
}