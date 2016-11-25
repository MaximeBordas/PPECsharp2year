using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using MySql.Data.MySqlClient;

namespace PPEV2DAL
{
    public class HippodromeDAO
    {
        private HippodromeDAO unHippodromeDAO;

        public HippodromeDAO GetUnHippodromeDAO()
        {
            if (unHippodromeDAO == null)
            {
                unHippodromeDAO = new HippodromeDAO();
            }
            return unHippodromeDAO;
        }
        public static List<Hippodrome> GetHippodromes()
        {
            List<Hippodrome> listHip= new List<Hippodrome>();
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql2 = "select * from hippodrome";
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            while (MaConnectionSql.MonLecteur.Read())
            {
                // recuperation de valeurs
                int hipId = (int)MaConnectionSql.MonLecteur["hip_id"];
                string hipNom = (string)MaConnectionSql.MonLecteur["hip_nom"];
                string hipLieu = (string)MaConnectionSql.MonLecteur["hip_lieu"];
                Hippodrome unHip = new Hippodrome(hipId, hipNom, hipLieu);
                listHip.Add(unHip);
            }
            MaConnectionSql.MonLecteur.Close();
            MaConnectionSql.CloseConnection();
            return listHip;
        }
        // methode qui relie les cables de la DAL avec la BLL
        // C'est VIIIIIINCE qui m'a donné cette méthode. Va falloir la tester (voir CHEVAL DAO création de l'objet cheval a partir de la BDD)
        public static Hippodrome GetUnHippodrome(int id)
        {
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "select * from hippodrome where hip_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            MaConnectionSql.Cmd.ExecuteReader();
            int hipId = (int)MaConnectionSql.MonLecteur["hip_id"];
            string hipNom = (string)MaConnectionSql.MonLecteur["hip_nom"];
            string hipLieu = (string)MaConnectionSql.MonLecteur["hip_lieu"];
            Hippodrome unHip = new Hippodrome(hipId, hipNom, hipLieu);
            MaConnectionSql.CloseConnection();
            return unHip;
        }
        //Cette méthode modifie un utilisateur passé en paramétre dans la BD
        // A VERIFIER ABSOLUMENT (SQL)
        public static int UpdateHippodrome(Hippodrome unHippodrome)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "update hippodrome set hip_nom = '" + unHippodrome.Nom + "', hip_lieu = '" + unHippodrome.Lieu + "' WHERE hip_id = " + unHippodrome.Id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        //Cette méthode supprime un utilisateur passé en paramétre dans la BD
        // A VERIFIER ABSOLUMENT (SQL)
        public static int DeleteHippodrome(int id)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "delete from hippodrome where hip_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        public static int AjoutHippodrome(Hippodrome unHippodrome)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            // ok, la ligne suivante en sql fait un peu mal à la tête
            // merci de bien la vérifié au niveau de cheval.ent.id et cheval.pro.Id
            string stringSql = " insert into hippodrome (hip_nom, hip_lieu) VALUES ('" + unHippodrome.Nom + "','" + unHippodrome.Lieu + ")";
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
    }
}
