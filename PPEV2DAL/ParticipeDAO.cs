using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using MySql.Data.MySqlClient;

namespace PPEV2DAL
{
    public class ParticipeDAO
    {
        private ParticipeDAO uneParticipationDAO;

        public ParticipeDAO GetUneParticipationDAO()
        {
            if (uneParticipationDAO == null)
            {
                uneParticipationDAO = new ParticipeDAO();
            }
            return uneParticipationDAO;
        }
        public static List<Participe> GetParticipation()
        {
            List<Participe> listParticipe = new List<Participe>();
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();

            string stringSql2 = "select * from participe";
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            while (MaConnectionSql.MonLecteur.Read())
            {
                // recuperation de valeurs
                Cheval partiCheval = ChevalDAO.GetUnCheval((int)MaConnectionSql.MonLecteur["ch_id"]);
                Course partiCourse = CoursesDAO.GetUneCourse((int)MaConnectionSql.MonLecteur["crs_id"]);
                Jockey partiJockey = JockeyDAO.GetUnJockey((int)MaConnectionSql.MonLecteur["joc_id"]);
                DateTime partiDate = (DateTime)MaConnectionSql.MonLecteur["date_course"];
                int partiClass = (int)MaConnectionSql.MonLecteur["classement"];

                Participe uneParti = new Participe(partiCheval, partiCourse, partiJockey, partiDate, partiClass);
                listParticipe.Add(uneParti);
            }
            MaConnectionSql.CloseConnection();
            return listParticipe;
        }
        public static int AjoutParticipation(Participe uneParticipe)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            // ok, la ligne suivante en sql fait un peu mal à la tête
            // merci de bien la vérifié au niveau de cheval.ent.id et cheval.pro.Id
            string stringSql = " insert into participe (ch_id, crs_id, joc_id, date_course, classement) VALUES (" + uneParticipe.Cheval.Id + "," + uneParticipe.Course.Id + "," + uneParticipe.Jockey.Id + "," + uneParticipe.DateCourue + "," + uneParticipe.Clas + ")";
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        // UPDATE 
        public static int UpdateParticipation(Participe uneParticipe)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "update participe set ch_id = '" + uneParticipe.Cheval.Id + "', crs_id = '" + uneParticipe.Course.Id + "', joc_id = " + uneParticipe.Jockey.Id + ", date_course = '" + uneParticipe.DateCourue + "', classement = '" + uneParticipe.Clas;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        public static int DeleteParticipation(int id)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "delete from participe where ch_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
    }
    }
