using Pollia.Utils;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pollia.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlaceService _placeService;
        private readonly IUserService _userService;
        private readonly IArticleService _articleService;
        private readonly IEventService _eventService;
        private readonly IRoleService _roleService;

        public HomeController(IPlaceService placeService, IUserService userService, IArticleService articleService, IEventService eventService, IRoleService roleService)
        {
            _placeService = placeService;
            _userService = userService;
            _articleService = articleService;
            _eventService = eventService;
            _roleService = roleService;
        }

        // GET: Admin
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            int totalUsers = _userService.GetTotalUsers();
            int totalSupplierUsers = _roleService.GetTotalUsersOfRoles("Supplier");

            List<string> userIds = _roleService.GetUsersOfRoles("Supplier");
            int totalPlaces = _placeService.GetTotalPlaces();
            int totalSuppliersPlaces = _placeService.GetTotalPlacesOf(userIds);
            int totalArticles = _articleService.GetTotalArticles();
            int totalSupllierArticles = _articleService.GetTotalArticlesOf(userIds);
            int totalEvents = _eventService.GetTotalEvents();
            int totalSupplierEvent = _eventService.GetTotalEventOf(userIds);
            AdminNumberViewModel anvm = new AdminNumberViewModel(
                totalUsers, totalSupplierUsers,
                totalPlaces, totalSuppliersPlaces,
                totalArticles, totalSupllierArticles,
                totalEvents, totalSupplierEvent);
            return View(anvm);
        }

        public ActionResult Place()
        {
            return View();
        }
    }

    public class AdminNumberViewModel
    {
        public AdminNumberViewModel(int totalUsers, int totalSupplierUsers, int totalPlaces, int totalSuppliersPlaces, int totalArticles, int totalSupllierArticles, int totalEvents, int totalSupplierEvent)
        {
            this.totalUsers = totalUsers;
            this.totalSupplierUsers = totalSupplierUsers;
            this.totalPlaces = totalPlaces;
            this.totalSuppliersPlaces = totalSuppliersPlaces;
            this.totalArticles = totalArticles;
            this.totalSupllierArticles = totalSupllierArticles;
            this.totalEvents = totalEvents;
            this.totalSupplierEvent = totalSupplierEvent;
        }

        public int totalUsers { get; set; }
        public int totalSupplierUsers { get; set; }
        public int totalPlaces { get; set; }
        public int totalSuppliersPlaces { get; set; }
        public int totalArticles { get; set; }
        public int totalSupllierArticles { get; set; }
        public int totalEvents { get; set; }
        public int totalSupplierEvent { get; set; }
    }
}