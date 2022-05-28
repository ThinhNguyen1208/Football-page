using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB_QLGD1;
using DBIO;

namespace Project_NMCNPM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction($"IndexUser/{Session["user"]}");
            }
            return View();
        }


        public ActionResult IndexUser(string id)
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("Index");
            }
            if(id == null)
            {
                Session.Clear();
                return RedirectToAction("Index");
            }

            IODB_GD io = new IODB_GD();
            NGUOIDUNG user = io.getUser(id);
            return View(user);
        }

        public ActionResult Tournaments()
        {   
            IODB_GD io = new IODB_GD();
            List<GIAIDAU> list = null;
            if (Session["user"] != null)
            {
                ViewBag.User = io.getUser(Session["user"].ToString());
                NGUOIDUNG user = io.getUser(Session["user"].ToString());
                list = io.getAllTournamentNotBelongToUser(user.MAND);
            }
            else
            {
                list = io.getAllTournament();
            }
           
            return View(list);
        }
    }

    
}