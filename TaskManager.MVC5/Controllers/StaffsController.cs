using Scheduler.MVC5.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.MVC5.Models;

namespace TaskManager.MVC5.Controllers
{
    public class StaffsController : Controller
    {
        private readonly Staff_ManagerEntities staff_ManagerEntities =new Staff_ManagerEntities();

        private AppUserManagerProvider _appUserManagerProvider;

        public AppUserManagerProvider AppUserManagerProvider
        {
            get { return _appUserManagerProvider ?? (_appUserManagerProvider = new AppUserManagerProvider()); }
        }


        
        [Authorize(Roles ="Manager")]
        // GET: Staff
        public ActionResult Index()
        {

            var staffs=staff_ManagerEntities.UserInRoles.Where(x=>x.RoleId== "c5f7b779-cf81-4d0c-b6a1-8d9bedd75418").ToList();
            return View(staffs);
        }


        public ActionResult DeleteStaff(string id)
        {
            var staff = staff_ManagerEntities.Users.FirstOrDefault(x => x.Id == id);
            staff_ManagerEntities.Users.Remove(staff);
            staff_ManagerEntities.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}