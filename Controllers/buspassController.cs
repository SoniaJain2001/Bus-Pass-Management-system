using BusPassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusPassManagementSystem.Controllers
{
    public class buspassController : Controller
    {
        public IActionResult Frontpage()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login l)
        {
            if(ModelState.IsValid)
            {
                using(BusContext context = new BusContext())
                {
                    var a = context.userdetails.Where(x => x.UserId == l.UserId && x.Password == l.Password);
                    if(a.Count()>0)
                    {
                        userdetails? u = a.FirstOrDefault();
                        HttpContext.Session.SetString("Name", u.Name);
                        HttpContext.Session.SetInt32("role", u.RoleId);
                        HttpContext.Session.SetString("uid", u.UserId);
                        TempData["Login"] = "1";
                        return RedirectToAction("Home", "Admin");
                    }
                    else
                    {
                        TempData["Login"]="0";
                    }
                }
            }
            return View();
        }
        public IActionResult ULogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ULogin(Login l)
        {
            if (ModelState.IsValid)
            {
                using (BusContext context = new BusContext())
                {
                    var a = context.userdetails.Where(x => x.UserId == l.UserId && x.Password == l.Password);
                    if (a.Count() > 0)
                    {
                        userdetails? u = a.FirstOrDefault();
                        HttpContext.Session.SetString("Name", u.Name);
                        HttpContext.Session.SetInt32("role", u.RoleId);
                        HttpContext.Session.SetString("uid", u.UserId);
                        TempData["Login"] = "1";
                        return RedirectToAction("Home", "User");
                    }
                    else
                    {
                        TempData["Login"] = "0";
                    }
                }
            }
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(userdetails ud)
        {
            ud.RoleId = 1;
           if (ModelState.IsValid)
            {
                using (BusContext bc=new BusContext())
                {
                    bc.Add(ud);
                    if (bc.SaveChanges() > 0)
                    {
                        TempData["signup"] = "1";
                    }
                    else
                    {
                        TempData["signup"] = "0";
                    }
                }
            }
            return View();
        }
        public IActionResult USignup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult USignup(userdetails ud)
        {
            ud.RoleId = 2;
            if (ModelState.IsValid)
            {
                using (BusContext bc = new BusContext())
                {
                    bc.Add(ud);
                    if (bc.SaveChanges() > 0)
                    {
                        TempData["Signup"] = "1";
                    }
                    else
                    {
                        TempData["Signup"] = "0";
                    }
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("frontpage", "buspass");
        }
        public IActionResult Reset()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reset(Resetpassword rp)
        {
            if (ModelState.IsValid)
            {
                using (BusContext context = new BusContext())
                {
                    var a = context.userdetails.Where(x => x.UserId == rp.UserId && x.ContactNo == rp.MobileNumber);
                    if (a.Count() > 0)
                    {
                        userdetails? u = a.FirstOrDefault();
                        TempData["Login"] = "1";
                        return RedirectToAction("Home", "Admin");
                    }
                    else
                    {
                        TempData["Login"] = "0";
                    }
                }
            }
            return View();
        }
    }
}
