using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using MySql.Data.MySqlClient;

namespace PPEV2DAL
{
    public class ProprietaireDAO
    {
        private ProprietaireDAO unProprietaireDAO;

        public ProprietaireDAO GetUnProprietaireDAO()
        {
            if (unProprietaireDAO == null)
            {
                unProprietaireDAO = new ProprietaireDAO();
            }
            return unProprietaireDAO;
        }

        public static List<Proprietaire> GetProprietaire()
        {
            List<Proprietaire> listPro = new List<Proprietaire>();
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql2 = "select * from proprietaire";
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            while (MaConnectionSql.MonLecteur.Read())
            {
                // recuperation de valeurs
                int proId = (int)MaConnectionSql.MonLecteur["pro_id"];
                string proNom = (string)MaConnectionSql.MonLecteur["pro_nom"];
                string proPrenom = (string)MaConnectionSql.MonLecteur["pro_prenom"];
                string proCivilite = (string)MaConnectionSql.MonLecteur["pro_civilite"];
                Proprietaire unPro = new Proprietaire(proId, proNom, proPrenom, proCivilite);
                listPro.Add(unPro);
            }
            MaConnectionSql.MonLecteur.Close();
            MaConnectionSql.CloseConnection();
            return listPro;
        }
        // Cette méthode insert un nouvel proprietaire passé en paramètre dans la BD
        // A VERIFIER ABSOLUMENT (SQL)
        public static int AjoutProprietaire(Proprietaire unProprietaire)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = " insert into proprietaire (pro_nom, pro_prenom, pro_civilite) VALUES ('" + unProprietaire.Nom+ "','" + unProprietaire.Prenom + "')";
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        // methode qui relie les cables de la DAL avec la BLL
        // C'est VIIIIIINCE qui m'a donné cette méthode. Va falloir la tester (voir CHEVAL DAO création de l'objet cheval a partir de la BDD)
        public static Proprietaire GetUnProprietaire(int id)
        {
            Proprietaire unPro = null;
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "select * from proprietaire where pro_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            if(MaConnectionSql.MonLecteur.Read() == true)
            {
                int proId = (int)MaConnectionSql.MonLecteur["pro_id"];
                string proNom = (string)MaConnectionSql.MonLecteur["pro_nom"];
                string proPrenom = (string)MaConnectionSql.MonLecteur["pro_prenom"];
                string proCivilite = (string)MaConnectionSql.MonLecteur["pro_civilite"];
                unPro = new Proprietaire(proId, proNom, proPrenom, proCivilite);
            }
            MaConnectionSql.MonLecteur.Close();
            MaConnectionSql.CloseConnection();
            return unPro;
        }
        //Cette méthode modifie un utilisateur passé en paramétre dans la BD
        // A VERIFIER ABSOLUMENT (SQL)
        public static int UpdateProprietaire(Proprietaire unProprietaire)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "update proprietaire set pro_nom = '" + unProprietaire.Nom + "', pro_prenom = '" + unProprietaire.Prenom + "' WHERE pro_id = " + unProprietaire.Id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }

        //Cette méthode supprime un utilisateur passé en paramétre dans la BD
        // A VERIFIER ABSOLUMENT (SQL)
        public static int DeleteProprietaire(int id)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "delete from proprietaire where pro_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
    }
}
