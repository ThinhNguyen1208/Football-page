using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB_QLGD1;
using DBIO;

namespace Project_NMCNPM.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Register");
            }

            IODB_GD db = new IODB_GD();
            NGUOIDUNG user = db.getUser(Session["user"].ToString());
            return View(user);
        }


        [HttpPost]
        public JsonResult AddTeam(FormCollection form)
        {
            IODB_GD io = new IODB_GD();
            DOIBONG newTeam = new DOIBONG();
            newTeam.MADB = io.CountTeam().ToString();

            NGUOIDUNG user = io.getUser(Session["user"].ToString());
            newTeam.MAND = user.MAND;
            newTeam.TENDB = form["teamName"];
            newTeam.DOTUOI = Convert.ToInt32(form["age"]);
            newTeam.KHUVUC_HD = form["area"];
            newTeam.GIOITINH = form["gender"];
            newTeam.GIOITHIEU = form["introduction"];
            newTeam.SOLUONGTV = 10;
       

            if (Request.Files.Count > 0)
            {

                newTeam.ImageUpload1 = Request.Files[0];
                string fileName = $"avatar{newTeam.MADB}";
                string extension = Path.GetExtension(newTeam.ImageUpload1.FileName);
                fileName = fileName + extension;
                newTeam.ANHDAIDIEN = "~/Assets/AvatarTeam/" + fileName;
                newTeam.ImageUpload1.SaveAs(Path.Combine(Server.MapPath("~/Assets/AvatarTeam/"), fileName));

                newTeam.ImageUpload2 = Request.Files[1];
                fileName = $"uniform1-{newTeam.MADB}";
                extension = Path.GetExtension(newTeam.ImageUpload2.FileName);
                fileName = fileName + extension;
                newTeam.ANHDP1 = "~/Assets/AvatarTeam/" + fileName;
                newTeam.ImageUpload2.SaveAs(Path.Combine(Server.MapPath("~/Assets/AvatarTeam/"), fileName));

                newTeam.ImageUpload3 = Request.Files[2];
                fileName = $"uniform2-{newTeam.MADB}";
                extension = Path.GetExtension(newTeam.ImageUpload3.FileName);
                fileName = fileName + extension;
                newTeam.ANHDP2 = "~/Assets/AvatarTeam/" + fileName;
                newTeam.ImageUpload3.SaveAs(Path.Combine(Server.MapPath("~/Assets/AvatarTeam/"), fileName));

            }

            JsonResult jr = new JsonResult();

            io.addObject(newTeam);
            io.Save();


            jr.Data = new
            {
                status = "OK"
            };
         

            return Json(jr, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateTeam(FormCollection form)
        {
            IODB_GD io = new IODB_GD();
            DOIBONG Team = io.getTeamByid(form["uid"]);

            NGUOIDUNG user = io.getUser(Session["user"].ToString());
            Team.MAND = user.MAND;
            Team.TENDB = form["teamName"];
            Team.DOTUOI = Convert.ToInt32(form["age"]);
            Team.KHUVUC_HD = form["area"];
            Team.GIOITHIEU = form["introduction"];



            if (Request.Files.Count > 0)
            {
                int count = 0;
                string fileName = "";
                string extension = "";
                if(form["img1"] == "T")
                {
                    Team.ImageUpload1 = Request.Files[0];
                    fileName = $"avatar{Team.MADB}";
                    extension = Path.GetExtension(Team.ImageUpload1.FileName);
                    fileName = fileName + extension;
                    Team.ANHDAIDIEN = "~/Assets/AvatarTeam/" + fileName;
                    Team.ImageUpload1.SaveAs(Path.Combine(Server.MapPath("~/Assets/AvatarTeam/"), fileName));
                    count++;
                }

                if (form["img2"] == "T")
                {
                    Team.ImageUpload2 = Request.Files[count];
                    fileName = $"uniform1-{Team.MADB}";
                    extension = Path.GetExtension(Team.ImageUpload2.FileName);
                    fileName = fileName + extension;
                    Team.ANHDP1 = "~/Assets/AvatarTeam/" + fileName;
                    Team.ImageUpload2.SaveAs(Path.Combine(Server.MapPath("~/Assets/AvatarTeam/"), fileName));
                    count++;
                }


                if (form["img3"] == "T")
                {
                    Team.ImageUpload3 = Request.Files[count];
                    fileName = $"uniform2-{Team.MADB}";
                    extension = Path.GetExtension(Team.ImageUpload3.FileName);
                    fileName = fileName + extension;
                    Team.ANHDP2 = "~/Assets/AvatarTeam/" + fileName;
                    Team.ImageUpload3.SaveAs(Path.Combine(Server.MapPath("~/Assets/AvatarTeam/"), fileName));
                }
            }

            JsonResult jr = new JsonResult();

            io.Save();

            jr.Data = new
            {
                status = "OK"
            };


            return Json(jr, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(string id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Register");
            }
            IODB_GD io = new IODB_GD();

            ViewBag.User = io.getUser(Session["user"].ToString());
            ViewBag.Member = io.getPlayerOfTeam(id);


            DOIBONG team = io.getTeamByid(id);
           
            return View(team);
        }


        [HttpPost]
        public JsonResult addMember(FormCollection form)
        {
            IODB_GD io = new IODB_GD();
           

            NGUOIDUNG user = io.getUser(Session["user"].ToString());

            CAUTHU player = new CAUTHU();
            player.MATV = $"CT{io.CountMember()}";
            player.MADB = form["uid"];
            player.TENTV = form["memberName"];
            player.NGAYSINH = Convert.ToDateTime(form["birthday"]);
            player.GIOITINH = form["gender"];
            player.VITRI = form["position"];
            player.SOAO = Convert.ToInt32(form["numberShirt"]);



            if (Request.Files.Count > 0)
            {
                    player.ImageUpload = Request.Files[0];
                    string fileName = $"avatar{player.MATV}";
                    string extension = Path.GetExtension(player.ImageUpload.FileName);
                    fileName = fileName + extension;
                    player.ANHTHE = "~/Assets/AvatarMember/" + fileName;
                    player.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/AvatarMember/"), fileName));
            }

            JsonResult jr = new JsonResult();
            io.addObject(player);
            io.Save();

            jr.Data = new
            {
                status = "OK",
                imgSrc = Url.Content(player.ANHTHE)
            };


            return Json(jr, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ManageTeam()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Register");
            }

            IODB_GD db = new IODB_GD();
            NGUOIDUNG user = db.getUser(Session["user"].ToString());

            List<DOIBONG> list = db.getTeamOfUser(user.MAND);
            ViewBag.User = user;
            return View(list);
        }

    }

}
