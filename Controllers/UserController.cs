using BusPassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusPassManagementSystem.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Home()
        {
            passtype p=new passtype();  
            List<passtype> passes = new List<passtype>();
            var s_uid = HttpContext.Session.GetString("uid");
            p.UserId = s_uid;
            using (BusContext bc=new BusContext())
            {
                passes = bc.Passtypes.ToList();
            }
            return View(passes);
        }
        public IActionResult Apply()
        {
            passtype p = new passtype();
            List<passtype> passes = new List<passtype>();
            var s_uid = HttpContext.Session.GetString("uid");
            p.UserId = s_uid;
            using (BusContext bc = new BusContext())
            {
                passes = bc.Passtypes.ToList();
            }
            return View(passes);
        }
        public IActionResult ApplyPass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApplyPass(ApplyPass applyPass)
        {
            if (ModelState.IsValid)
            {
                using(BusContext kc=new BusContext())
                {
                    kc.Add(applyPass);
                    int count = kc.SaveChanges();
                    if (count > 0)
                    {
                        TempData["pass"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["pass"] = "0";
                    }
                }
            }
            return View();
        }
        public IActionResult viewpass()
        {
            var s_uid = HttpContext.Session.GetString("uid");
            List<ApplyPass> res=new List<ApplyPass>();
            using (BusContext bc = new BusContext())
            {
                res = bc.ApplyPasses.ToList();
            }
            return View(res);
        }
    }
}
