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
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult NewCreate()
        {
            return View();
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home",null);
        }



        [HttpPost]
        public JsonResult CheckLogin(FormCollection form )
        {
            string username = form["username"];
            string pass = form["password"];

            IODB_GD io = new IODB_GD();
    
            NGUOIDUNG user = io.getUser(username);
            JsonResult jr = new JsonResult();
            if (user != null)
            {
                if(pass == user.PASSWORD.Trim())
                {
                    Session["user"] = username;
                    jr.Data = new
                    {
                        status = "OK",
                        
                    };
                }
                else
                {
                    jr.Data = new
                    {
                        status = "Fi",
                    };
                }
                
            }
            else
            {
                jr.Data = new
                {
                    status = "F"
                };
            }
                    
           return Json(jr, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddNew(FormCollection form)
        {
            IODB_GD io = new IODB_GD();
            NGUOIDUNG newUser = new NGUOIDUNG();
            newUser.MAND = io.CountUser().ToString();
            newUser.TENND = form["name"];
            newUser.USERNAME = form["username"];
            newUser.PASSWORD = form["password"];
            newUser.EMAIL = form["email"];
            newUser.SDT = form["numberPhone"];
            newUser.NGAYSINH = Convert.ToDateTime(form["birthday"]);

            
            if (Request.Files.Count > 0)
            {
                newUser.ImageUpload = Request.Files[0];
                string fileName = $"avatar{newUser.MAND}";
                string extension = Path.GetExtension(newUser.ImageUpload.FileName);
                fileName = fileName + extension;
                newUser.ANHDAIDIEN = "~/Assets/Avatar/" + fileName;
                newUser.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Avatar/"), fileName));
            }

            JsonResult jr = new JsonResult();
           
            NGUOIDUNG user = io.getUser(newUser.USERNAME);

            if (user == null)
            {
                io.addObject(newUser);
                io.Save();
                Session["user"] = newUser.USERNAME;
                jr.Data = new
                {
                    status = "OK"
                };
            }
            else
            {
                jr.Data = new
                {
                    status = "F"
                };
            }

            return Json(jr, JsonRequestBehavior.AllowGet);
        }
    }
}