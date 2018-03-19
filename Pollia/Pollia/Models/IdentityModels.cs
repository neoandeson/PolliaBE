using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace Pollia.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Full Name")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Invalid Name")]
        public string FullName { get; set; }

        [Display(Name = "ProvinceId"), Required]
        public int ProvinceId { get; set; }

        [Display(Name = "DistrictId"), Required]
        public int DistrictId { get; set; }

        [Display(Name = "WardId"), Required]
        public int WardId { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }

        [Display(Name = "IsOnline")]
        public bool IsOnline { get; set; }

        [Display(Name = "Sex"), Required]
        public int Sex { get; set; }

        [Display(Name = "Birthday"), Required]
        public DateTime DoB { get; set; }

        [Display(Name = "Url")]
        [StringLength(400)]
        public string AvatarUrl { get; set; }

        [Display(Name = "EP")]
        public int Points { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("FullName", this.FullName));
            userIdentity.AddClaim(new Claim("Avatar", this.AvatarUrl));
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(): base(){ }
        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("AccountDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Pollia.Models.RoleViewModel> RoleViewModels { get; set; }

        //public System.Data.Entity.DbSet<Pollia.Models.EditUserViewModel> EditUserViewModels { get; set; }

        //Modified
        //public System.Data.Entity.DbSet<Pollia.Models.RoleViewModel> RoleViewModels { get; set; }
    }
}