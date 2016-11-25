using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using MySql.Data.MySqlClient;

namespace PPEV2DAL
{
    public class UtilisateurDAO
    {
        private UtilisateurDAO unUtilisateurDAO;
        public UtilisateurDAO GetunUtilisateurDAO()
        {
            if (unUtilisateurDAO == null)
            {
                unUtilisateurDAO = new UtilisateurDAO();
            }
            return unUtilisateurDAO;
        }

        public static List<Utilisateur> GetUtilisateurs()
        {
            List<Utilisateur> listUtil = new List<Utilisateur>();
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();

            string stringSql = "select count(*) from utilisateur";
            MaConnectionSql.Cmd.CommandText = stringSql;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            MaConnectionSql.MonLecteur.Close();

            string stringSql2 = "select * from utilisateur";
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            while (MaConnectionSql.MonLecteur.Read())
            {
                // recuperation de valeurs
                int userId = (int)MaConnectionSql.MonLecteur["user_id"];
                string userlogin = (string)MaConnectionSql.MonLecteur["user_login"];
                string usermdp = (string)MaConnectionSql.MonLecteur["user_mdp"];
                Utilisateur newUser = new Utilisateur(userId, userlogin, usermdp);
                listUtil.Add(newUser);
            }
            MaConnectionSql.MonLecteur.Close();
            MaConnectionSql.CloseConnection();
            return listUtil;
        }
        // Cette méthode insert un nouvel utilisateur passé en paramètre dans la BD
        // A VERIFIER ABSOLUMENT (SQL)
        public static int AjoutUtilisateur(Utilisateur unUtilisateur)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();

            string stringSql = " insert into utilisateur (user_login, user_mdp) VALUES ('" + unUtilisateur.Login + "','" + unUtilisateur.Mdp + "')";

            MaConnectionSql.Cmd.CommandText = stringSql;

            // MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();

            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();

            MaConnectionSql.CloseConnection();
            return nbEnr;
        }   
        //Cette méthode modifie un utilisateur passé en paramétre dans la BD
        // A VERIFIER ABSOLUMENT (SQL)
        public static int UpdateUtilisateur(Utilisateur unUtilisateur)
        {
            int nbEnr;

            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();

            string stringSql = "update utilisateur set user_login = '" + unUtilisateur.Login + "', user_mdp = '" + unUtilisateur.Mdp + "' WHERE user_id = " + unUtilisateur.Id;

            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }

        //Cette méthode supprime un utilisateur passé en paramétre dans la BD
        // A VERIFIER ABSOLUMENT (SQL)
        public static int DeleteUtilisateur(int id)
        {
            int nbEnr;

            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "delete from utilisateur where user_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
    }
}
