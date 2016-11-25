using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using MySql.Data.MySqlClient;

namespace PPEV2DAL
{
    public class JockeyDAO
    {
        private JockeyDAO unJockeyDAO;

        public JockeyDAO GetUnJockeyDAO()
        {
            if (unJockeyDAO == null)
            {
                unJockeyDAO = new JockeyDAO();
            }
            return unJockeyDAO;
        }

        public static List<Jockey> GetJockeys()
        {
            List<Jockey> ListJockey = new List<Jockey>();
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql2 = "select * from jockey";
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            while (MaConnectionSql.MonLecteur.Read())
            {
                // recuperation de valeurs
                int jockId = (int)MaConnectionSql.MonLecteur["joc_id"];
                string jockNom = (string)MaConnectionSql.MonLecteur["joc_nom"];
                string jockPrenom = (string)MaConnectionSql.MonLecteur["joc_prenom"];
                int jockAge = (int)MaConnectionSql.MonLecteur["joc_age"];
                string jockCiv = (string)MaConnectionSql.MonLecteur["joc_civilite"];
                Jockey unJockey = new Jockey(jockId,jockNom,jockPrenom,jockAge,jockCiv);
                ListJockey.Add(unJockey);

            }
            MaConnectionSql.MonLecteur.Close();
            MaConnectionSql.CloseConnection();
            return ListJockey;
        }
        // methode qui relie les cables de la DAL avec la BLL
        // C'est VIIIIIINCE qui m'a donné cette méthode. Va falloir la tester (voir CHEVAL DAO création de l'objet cheval a partir de la BDD)
        public static Jockey GetUnJockey(int id)
        {
            Jockey unJockey = null;
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "select * from jockey where joc_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            if (MaConnectionSql.MonLecteur.Read() == true)
            {
                int jockId = (int)MaConnectionSql.MonLecteur["joc_id"];
                string jockNom = (string)MaConnectionSql.MonLecteur["joc_nom"];
                string jockPrenom = (string)MaConnectionSql.MonLecteur["joc_prenom"];
                int jockAge = (int)MaConnectionSql.MonLecteur["joc_age"];
                string jockCiv = (string)MaConnectionSql.MonLecteur["joc_civilite"];
                unJockey = new Jockey(jockId, jockNom, jockPrenom, jockAge, jockCiv);
            }
            
            MaConnectionSql.CloseConnection();
            return unJockey;
        }
        //Cette méthode modifie un utilisateur passé en paramétre dans la BD
        // A VERIFIER ABSOLUMENT (SQL)
        public static int UpdateJockey(Jockey unJockey)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "update jockey set joc_nom = '" + unJockey.Nom + "', joc_prenom = '" + unJockey.Prenom + "', joc_age = " + unJockey.Age + ", joc_civilite = '" + unJockey.Civilite + "'  WHERE joc_id = " + unJockey.Id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        public static int DeleteJockey(int id)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "delete from jockey where joc_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        public static int AjoutJockey(Jockey unJockey)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            // ok, la ligne suivante en sql fait un peu mal à la tête
            // merci de bien la vérifié au niveau de cheval.ent.id et cheval.pro.Id
            string stringSql = " insert into jockey (joc_nom, joc_prenom, joc_age, joc_civilite) VALUES ('" + unJockey.Nom + "','" + unJockey.Prenom + "'," + unJockey.Age + ",'" + unJockey.Civilite + "')";
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
    }
}
