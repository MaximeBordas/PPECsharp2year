using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using MySql.Data.MySqlClient;

namespace PPEV2DAL
{
    public class EntraineurDAO
    {
        private EntraineurDAO unEntraineurDAO;

        public EntraineurDAO GetUnEntraineurDAO()
        {
            if (unEntraineurDAO == null)
            {
                unEntraineurDAO = new EntraineurDAO();
            }
            return unEntraineurDAO;
        }

        public static List<Entraineur> GetEntraineurs()
        {
            List<Entraineur> listEntr = new List<Entraineur>();
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql2 = "select * from entraineur";
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            while (MaConnectionSql.MonLecteur.Read())
            {
                // recuperation de valeurs
                int entId = (int)MaConnectionSql.MonLecteur["ent_id"];
                string entNom = (string)MaConnectionSql.MonLecteur["ent_nom"];
                string entPrenom = (string)MaConnectionSql.MonLecteur["ent_prenom"];
                int entAge = (int)MaConnectionSql.MonLecteur["ent_age"];
                string entCivilite = (string)MaConnectionSql.MonLecteur["ent_civilite"];
                string entLocalisation = (string)MaConnectionSql.MonLecteur["ent_localisation"];
                Entraineur unEnt = new Entraineur(entId, entNom, entPrenom, entAge, entCivilite, entLocalisation);
                listEntr.Add(unEnt);
            }
            MaConnectionSql.MonLecteur.Close();
            MaConnectionSql.CloseConnection();
            return listEntr;
        }
        // Cette méthode insert un nouvel utilisateur passé en paramètre dans la BD
        // A VERIFIER ABSOLUMENT
        public static int AjoutEntraineur(Entraineur unEntraineur)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = " insert into entraineur (ent_nom, ent_prenom, ent_age, ent_civilite, ent_localisation) VALUES ('" + unEntraineur.Nom + "','" + unEntraineur.Prenom + "'," + unEntraineur.Age + ",'" + unEntraineur.Civilite + "','" + unEntraineur.Localisation + "')";
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }


        // methode qui relie les cables de la DAL avec la BLL
        // C'est VIIIIIINCE qui m'a donné cette méthode. Va falloir la tester (voir CHEVAL DAO création de l'objet cheval a partir de la BDD)
        public static Entraineur GetUnEntraineur(int id)
        {
            Entraineur unEntraineur = null;
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "select * from entraineur where ent_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();

            if(MaConnectionSql.MonLecteur.Read())
            {
                int entId = (int)MaConnectionSql.MonLecteur["ent_id"];
                string entNom = (string)MaConnectionSql.MonLecteur["ent_nom"];
                string entPrenom = (string)MaConnectionSql.MonLecteur["ent_prenom"];
                int entAge = (int)MaConnectionSql.MonLecteur["ent_age"];
                string entCivilite = (string)MaConnectionSql.MonLecteur["ent_civilite"];
                string entLocalisation = (string)MaConnectionSql.MonLecteur["ent_localisation"];
                unEntraineur = new Entraineur(entId, entNom, entPrenom, entAge, entCivilite, entLocalisation);
            }
            

            MaConnectionSql.CloseConnection();
            return unEntraineur;
        }
        //Cette méthode modifie un utilisateur passé en paramétre dans la BD
        // A VERIFIER ABSOLUMENT
        public static int UpdateEntraineur(Entraineur unEntraineur)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "update entraineur set ent_nom '" + unEntraineur.Nom + "', ent_prenom = '" + unEntraineur.Prenom + "', ent_age = " + unEntraineur.Age + ", ent_civilite = '" + unEntraineur.Civilite + "', ent_localisation = '" + unEntraineur.Localisation + "')";
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        public static int DeleteEntraineur(int id)
        {
            int nbEnr = 0;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();


            string stringSql = "delete from entraineur where ent_id = " + id;

            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
    }
}
