using BusPassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusPassManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Home()
        {
            List<Addbus> ab = new List<Addbus>();
            using (BusContext bc = new BusContext())
            {
                ab = bc.addbus.ToList();
            }
            return View(ab);
        }
        public IActionResult Addbus()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addbus(Addbus ud)
        {
            if (ModelState.IsValid)
            {
                using (BusContext bc = new BusContext())
                {
                    bc.Add(ud);
                    if (bc.SaveChanges() > 0)
                    {
                        TempData["Bus"] = "1";
                    }
                    else
                    {
                        TempData["Bus"] = "0";
                    }
                }
            }
            return View();
        }
        public IActionResult busroute()
        {
            List<Addbus> ab = new List<Addbus>();
            using (BusContext bc = new BusContext())
            {
                ab = bc.addbus.ToList();
            }
            return View(ab);
        }
        public IActionResult edit(int id)
        {
            Addbus? ab = new Addbus();
            using (BusContext bc = new BusContext())
            {
                ab = bc.addbus.Where(x => x.Snum == id).FirstOrDefault();
            }
            return View(ab);
        }
        [HttpPost]
        public IActionResult edit(Addbus a)
        {

            using (BusContext bc = new BusContext())
            {
                var s = bc.addbus.Find(a.Snum);
                s.BusNo = a.BusNo;
                s.Source = a.Source;
                s.Destination = a.Destination;
                s.NoOfStops = a.NoOfStops;
                if (bc.SaveChanges() > 0)
                {
                    TempData["edit"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["edit"] = "0";
                }
            }
            return RedirectToAction("busroute", "Admin");
        }
        public IActionResult passtype()
        {
            var s_uid=HttpContext.Session.GetString("uid");
            using (BusContext bc = new BusContext())
            {
                TempData["passtype"] = bc.Passtypes.Where(x => x.UserId ==s_uid).ToList();
            }
            return View();
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(passtype p)
        {
            var s_uid = HttpContext.Session.GetString("uid");
            p.UserId = s_uid;
            using (BusContext bc = new BusContext())
            {
                bc.Passtypes.Add(p);
                if(bc.SaveChanges()>0)
                {
                    TempData["create"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["create"]="0";

                }
            }
            return View();
        }
    }
}

