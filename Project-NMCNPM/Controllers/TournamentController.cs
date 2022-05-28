using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB_QLGD1;
using DBIO;

namespace Project_NMCNPM.Controllers
{
    public class TournamentController : Controller
    {
        // GET: Tournament
        public ActionResult Index()
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("Login", "Register");
            }

            IODB_GD db = new IODB_GD();
            NGUOIDUNG user = db.getUser(Session["user"].ToString());
            return View(user);
        }


        [HttpPost]
        public JsonResult AddTournament(FormCollection form)
        {
            IODB_GD io = new IODB_GD();
            GIAIDAU newTournament = new GIAIDAU();
            newTournament.MAGD =  "GD" + (io.CountTournament() + 1).ToString();

            NGUOIDUNG user = io.getUser(Session["user"].ToString());
            newTournament.MAND = user.MAND;
            newTournament.TENGD = form["tournamentName"];
            newTournament.TGBATDAU = Convert.ToDateTime(form["time"]);
            newTournament.MASVD = form["address"];
            newTournament.TUOITOITHIEU = Convert.ToInt32(form["minAge"]);
            newTournament.TUOITOIDA = Convert.ToInt32(form["maxAge"]);
            newTournament.SOLUONGDOITG = Convert.ToInt32(form["amountOfTeam"]);
            newTournament.SLTVTOIDA = Convert.ToInt32(form["amountOfMember"]);
            newTournament.GIAITHUONG = form["prize"];
            newTournament.TRANGTHAI = 0;
            newTournament.SLTV_HT = 0;
            if (Request.Files.Count > 0)
            {

                newTournament.ImageUpload = Request.Files[0];
                string fileName = $"avatar{newTournament.MAGD}";
                string extension = Path.GetExtension(newTournament.ImageUpload.FileName);
                fileName = fileName + extension;
                newTournament.ANHDAIDIEN = "~/Assets/AvatarTournament/" + fileName;
                newTournament.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/AvatarTournament/"), fileName));

            }

            JsonResult jr = new JsonResult();

            io.addObject(newTournament);
            io.Save();


            jr.Data = new
            {
                status = "OK"
            };


            return Json(jr, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateTournament(FormCollection form)
        {
            IODB_GD io = new IODB_GD();
            GIAIDAU Tournament = io.getTournamentByid(form["uid"]);

            NGUOIDUNG user = io.getUser(Session["user"].ToString());
            Tournament.MAND = user.MAND;
            Tournament.TENGD = form["tournamentName"];
            Tournament.TGBATDAU = Convert.ToDateTime(form["time"]);
            Tournament.MASVD = form["address"];
            Tournament.TUOITOITHIEU = Convert.ToInt32(form["minAge"]);
            Tournament.TUOITOIDA = Convert.ToInt32(form["maxAge"]);
            Tournament.SOLUONGDOITG = Convert.ToInt32(form["amountOfTeam"]);
            Tournament.SLTVTOIDA = Convert.ToInt32(form["amountOfMember"]);
            Tournament.GIAITHUONG = form["prize"];
            Tournament.TRANGTHAI = 0;

            if (Request.Files.Count > 0)
            {

                Tournament.ImageUpload = Request.Files[0];
                string fileName = $"avatar{Tournament.MAGD}";
                string extension = Path.GetExtension(Tournament.ImageUpload.FileName);
                fileName = fileName + extension;
                Tournament.ANHDAIDIEN = "~/Assets/AvatarTournament/" + fileName;
                Tournament.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/AvatarTournament/"), fileName));

            }

            JsonResult jr = new JsonResult();

            io.Save();

            jr.Data = new
            {
                status = "OK"
            };


            return Json(jr, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ManageTournament()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Register");
            }

            IODB_GD db = new IODB_GD();
            NGUOIDUNG user = db.getUser(Session["user"].ToString());

            List<GIAIDAU> list = db.getTournamentsOfUser(user.MAND);
            ViewBag.User = user;
            return View(list);
        }

        public ActionResult Detail(string id)
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("Login", "Register");
            }
            IODB_GD io = new IODB_GD();
            
            ViewBag.User = io.getUser(Session["user"].ToString());
            GIAIDAU tm = io.getTournamentByid(id);
            ViewBag.Participant = io.getAllTeamParticipateTournament(id);
    
            return View(tm);
        }

        public ActionResult InforTournament(string id)
        {
            IODB_GD io = new IODB_GD();
            if (Session["user"] != null)
            {
                ViewBag.User = io.getUser(Session["user"].ToString());
                NGUOIDUNG user = io.getUser(Session["user"].ToString());
                ViewBag.TeamList = io.getAllTeamOfUser(user.MAND.Trim());
            }

            ViewBag.Participant = io.getAllTeamParticipateTournament(id);
            GIAIDAU tournament = io.getTournamentByid(id);
            return View(tournament);
        }

        [HttpPost]
        public JsonResult JoinTournament(FormCollection form)
        {
            string TeamId = form["TeamId"];
            string TournamentId = form["TournamentId"];

            IODB_GD io = new IODB_GD();
            GIAIDAU Tournament = io.getTournamentByid(TournamentId);

            JsonResult jr = new JsonResult();
            bool isTrue = true;
            if(Tournament.SLTV_HT + 1 <= Tournament.SOLUONGDOITG)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DB_GD"].ConnectionString;

                SqlConnection con = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand($"INSERT INTO THAMGIAGIAIDAU VALUES('{TeamId}','{TournamentId}')", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand($"SELECT ANHDAIDIEN,TENDB FROM DOIBONG WHERE MADB = '{TeamId}'", con);
                cmd1.CommandType = CommandType.Text;

                var reader = cmd1.ExecuteReader();
                DOIBONG team = new DOIBONG();
                while (reader.Read())
                {
                    team.ANHDAIDIEN = reader.GetString(0);
                    team.TENDB = reader.GetString(1);
                }

                Tournament.SLTV_HT++;
                io.Save();
                jr.Data = new
                {
                    status = "OK",
                    image = team.ANHDAIDIEN.Replace('~',' '),
                    teamName = team.TENDB
                };
            }
            else
            {
                isTrue = false;
            }

            

           

            
            if(isTrue == false)
            {
                jr.Data = new
                {
                    status = "F",
                    
                };
            }
          
          


            return Json(jr, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AddSchedule(FormCollection form)
        {
            JsonResult jr = new JsonResult();
            IODB_GD io = new IODB_GD();
            GIAIDAU Tournament = io.getTournamentByid(form["uid"]);


            if(Tournament.SLTV_HT == Tournament.SOLUONGDOITG)
            {
                List<DOIBONG> TeamList = io.getAllTeamParticipateTournament(Tournament.MAGD.Trim());


                if(Tournament.SOLUONGDOITG == 8)
                {
                    int count = 0;
                    List<TRANDAU> MatchList = new List<TRANDAU>();
                    for(int i = 0; i < 8; i+=2)
                    {
                        count++;
                        TRANDAU match = new TRANDAU();
                        match.MAGD = Tournament.MAGD.Trim();
                        match.MATD = $"TD{count}";
                        match.MAVD = "VD1";
                        match.MADB = TeamList[i].MADB;
                        match.DOI_MADB = TeamList[i + 1].MADB;
                        match.SOBAND1 = 0;
                        match.SOBAND2 = 0;
                        match.SOTHEPHAT = 0;
                        // match.THOIGIAN = null;


                        DateTime date = Convert.ToDateTime(Tournament.TGBATDAU);


                        match.THOIGIAN = Convert.ToDateTime(date.AddDays(count).ToString().Split(' ')[0]);

                        MatchList.Add(match);
                        //io.addObject(match);
                        
                    }
                    //io.Save();

                    jr.Data = new
                    {
                        status = "OK",
                        matchList = MatchList,
                        teamList = TeamList
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
    }




}