using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_QLGD1;

namespace DBIO
{
    public class IODB_GD
    {
        private DB_GD db;

        public IODB_GD() { db = new DB_GD(); }

        public NGUOIDUNG getUser(string username)
        {
            return db.NGUOIDUNGs.Where(x => x.USERNAME == username).FirstOrDefault();
        }

        public void addObject<T>(T obj)
        {
            db.Set(obj.GetType()).Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public int CountUser()
        {
            return db.NGUOIDUNGs.ToList().Count();
        }

        public int CountTeam()
        {
            return db.DOIBONGs.ToList().Count();
        }

        public int CountMember()
        {
            return db.CAUTHUs.ToList().Count();
        }

        public int CountTournament()
        {
            return db.GIAIDAUs.ToList().Count();
        }

        public NGUOIDUNG getUserById(string id)
        {
            return db.NGUOIDUNGs.Where(x => x.MAND == id).FirstOrDefault();
        }

        public List<GIAIDAU> getAllTournament()
        {
            return db.GIAIDAUs.ToList();
        }

        public List<GIAIDAU> getAllTournamentNotBelongToUser(string userId)
        {
            return db.GIAIDAUs.Where(x => x.MAND != userId.Trim()).ToList();
        }

        public List<DOIBONG> getAllTeamOfUser(string userId)
        {
            return db.DOIBONGs.Where(x => x.MAND == userId).ToList();
        }

        public List<CAUTHU> getPlayerOfTeam(string TeamId)
        {
            return db.CAUTHUs.Where(x => x.MADB == TeamId).ToList();
        }

        public GIAIDAU getTournamentByid(string TournamentId)
        {
            return db.GIAIDAUs.Where(x => x.MAGD == TournamentId).FirstOrDefault();
        }

        public DOIBONG getTeamByid(string TeamId)
        {
            return db.DOIBONGs.Where(x => x.MADB == TeamId).FirstOrDefault();
        }

        public SANVANDONG getStadiumByid(string StadiumId)
        {
            return db.SANVANDONGs.Where(x => x.MASVD == StadiumId).FirstOrDefault();
        }

        public List<GIAIDAU> getTournamentsOfUser(string userId)
        {
            return db.GIAIDAUs.Where(x => x.MAND == userId).ToList();
        }

        public List<DOIBONG> getTeamOfUser(string userId)
        {
            return db.DOIBONGs.Where(x => x.MAND == userId).ToList();
        }

        public List<DOIBONG> getAllTeamParticipateTournament(string TournamentId)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DB_GD"].ConnectionString;

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand($"SELECT TG.MADB, ANHDAIDIEN, MAND, TENDB, SOLUONGTV, KHUVUC_HD FROM THAMGIAGIAIDAU TG JOIN DOIBONG DB ON TG.MADB = DB.MADB WHERE MAGD = '{TournamentId}'", con);
            cmd.CommandType = CommandType.Text;

            List<DOIBONG> list = new List<DOIBONG>();

            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DOIBONG team = new DOIBONG();
                team.MADB = reader.GetString(0);
                team.ANHDAIDIEN = reader.GetString(1);
                team.MAND = reader.GetString(2);
                team.TENDB = reader.GetString(3);
                team.SOLUONGTV = reader.GetInt32(4);
                team.KHUVUC_HD = reader.GetString(5);
                list.Add(team);
            }

            return list;
        }
    }
}
