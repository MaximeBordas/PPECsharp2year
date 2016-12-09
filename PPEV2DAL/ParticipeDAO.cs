using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using MySql.Data.MySqlClient;
using System.Data;

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
                int partiCheval = (int)MaConnectionSql.MonLecteur["ch_id"];
                int partiCourse = (int)MaConnectionSql.MonLecteur["crs_id"];
                int partiJockey = (int)MaConnectionSql.MonLecteur["joc_id"];
                int partiClass = (int)MaConnectionSql.MonLecteur["classement"];

                Participe uneParti = new Participe(partiCheval, partiCourse, partiJockey, partiClass);
                listParticipe.Add(uneParti);
            }
            MaConnectionSql.MonLecteur.Close();
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
            string stringSql = " insert into participe (ch_id, crs_id, joc_id, classement) VALUES (" + uneParticipe.Cheval + "," + uneParticipe.Course + "," + uneParticipe.Jockey + "," + uneParticipe.Clas + ")";
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
            string stringSql = "update participe set ch_id = '" + uneParticipe.Cheval + "', crs_id = '" + uneParticipe.Course + "', joc_id = " + uneParticipe.Jockey + ", classement = '" + uneParticipe.Clas;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        public static int AssignerClassementCheval(int idCheval, int idCourse, int classement)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();

            string stringSql = "update participe set classement ='" + classement + "'WHERE ch_id ='" + idCheval + "'AND crs_id=" + idCourse;
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
        public static DataTable GetResultatDerniereCourse(int id)
        {
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            MySqlDataAdapter myDa = new MySqlDataAdapter();
            string stringSql = "SELECT classement AS 'Classement', ch_nom AS 'Nom Cheval' FROM participe, cheval, course WHERE participe.ch_id = cheval.ch_id AND participe.crs_id = course.crs_id AND course.crs_id ='" + id + "'ORDER BY classement";
            myDa.SelectCommand = new MySqlCommand(stringSql, MaConnectionSql.Con);
            MaConnectionSql.Cmd.CommandText = stringSql;
            DataTable table = new DataTable();

            myDa.Fill(table);

            MaConnectionSql.CloseConnection();
            return table;
        }
    }
    }
