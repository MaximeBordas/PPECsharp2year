using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using MySql.Data.MySqlClient;
using PPEV2DAL;

namespace PPEV2DAL
{
    public class ChevalDAO
    {
        private ChevalDAO unChevalDAO;

        public ChevalDAO GetunChevalDAO()
        {
            if (unChevalDAO == null)
            {
                unChevalDAO = new ChevalDAO();
            }
            return unChevalDAO;
        }


        /// <summary>
        /// RETOURNE  LA LISTE DES CHEVAUX DANS LA BDD
        /// </summary>
        /// <returns></returns>
        public static List<Cheval> GetChevaux()
        {
            List<Cheval> listChe = new List<Cheval>();
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();

            string stringSql2 = "select * from cheval";
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            while (MaConnectionSql.MonLecteur.Read())
            {
                // recuperation de valeurs
                int chevalId = (int)MaConnectionSql.MonLecteur["ch_id"];
                string chevalNom = (string)MaConnectionSql.MonLecteur["ch_nom"];
                string chevalCouleur = (string)MaConnectionSql.MonLecteur["ch_couleur"];
                int chevalAge = (int)MaConnectionSql.MonLecteur["ch_age"];
                string chevalSpecialite = (string)MaConnectionSql.MonLecteur["ch_specialite"];
                string chevalNomPere = (string)MaConnectionSql.MonLecteur["ch_nompere"];
                string chevalNomMere = (string)MaConnectionSql.MonLecteur["ch_nommere"];
                string chevalSexe = (string)MaConnectionSql.MonLecteur["ch_sexe"];
                // c'est ici que ça deviens compliqué, bien lire les deux prochaines lignes plusieurs fois pour comprendre.
                int chevalEnt = (int)MaConnectionSql.MonLecteur["ent_id"];
                int chevalPro = (int)MaConnectionSql.MonLecteur["pro_id"];
                //Entraineur chevalEnt = EntraineurDAO.GetUnEntraineur((int)MaConnectionSql.MonLecteur["ent_id"]);
                //Proprietaire chevalPro = ProprietaireDAO.GetUnProprietaire((int)MaConnectionSql.MonLecteur["pro_id"]);

                // Et la bim, on crée l'objet cheval. ( Et y'a pas d'erreur wow )
                Cheval unCheval = new Cheval(chevalId, chevalNom, chevalCouleur, chevalAge, chevalSpecialite, chevalNomPere, chevalNomMere, chevalSexe, chevalEnt, chevalPro);
                // on ajoute le cheval à la liste
                listChe.Add(unCheval);
            }
            MaConnectionSql.MonLecteur.Close();
            MaConnectionSql.CloseConnection();
            return listChe;
            // auccune erreur, wow.
        }

        /// <summary>
        /// Cette méthode insert un nouveau cheval passé en paramètre dans la BDD
        /// </summary>
        /// <param name="unCheval"></param>
        /// <returns></returns>
        public static int AjoutCheval(Cheval unCheval)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            // ok, la ligne suivante en sql fait un peu mal à la tête
            // merci de bien la vérifié au niveau de cheval.ent.id et cheval.pro.Id
            string stringSql = " insert into cheval (ch_nom, ch_couleur, ch_age, ch_specialite, ch_nompere, ch_nommere, ch_sexe, ent_id, pro_id) VALUES ('" + unCheval.Nom + "','" + unCheval.Couleur +  "'," + unCheval.Age + ",'" + unCheval.Specialite + "','" + unCheval.Nompere + "','" + unCheval.Nommere + "','" + unCheval.Sexe + "'," + unCheval.Entraineur + "," + unCheval.Proprietaire + ")";
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }

        /// <summary>
        /// Cette méthode met à jour un nouveau cheval passé en paramètre dans la BDD
        /// </summary>
        /// <param name="unCheval"></param>
        /// <returns></returns>
        public static int UpdateCheval(Cheval unCheval)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "update cheval set ch_nom = '" + unCheval.Nom + "', ch_couleur = '" + unCheval.Couleur + "', ch_age = " + unCheval.Age + ", ch_specialite = '" + unCheval.Specialite + "', ch_nompere = '" + unCheval.Nompere + "', ch_nommere = '" + unCheval.Nommere + "', ch_sexe = '" + unCheval.Sexe + "', ent_id = " + unCheval.Entraineur + ", pro_id = " + unCheval.Proprietaire + " WHERE ch_id  =" + unCheval.Id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }

        /// <summary>
        /// Cette méthode supprime un cheval passé en paramètre dans la BDD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteCheval(int id)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "delete from cheval where ch_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }

        /// <summary>
        /// Cette méthode retourne un cheval en passant son id en paramètre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Cheval GetUnCheval(int id)
        {
            Cheval unCheval = null;
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql2 = "select * from cheval where ch_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            if (MaConnectionSql.MonLecteur.Read())
            {
                // recuperation de valeurs
                int chevalId = (int)MaConnectionSql.MonLecteur["ch_id"];
                string chevalNom = (string)MaConnectionSql.MonLecteur["ch_nom"];
                string chevalCouleur = (string)MaConnectionSql.MonLecteur["ch_couleur"];
                int chevalAge = (int)MaConnectionSql.MonLecteur["ch_age"];
                string chevalSpecialite = (string)MaConnectionSql.MonLecteur["ch_specialite"];
                string chevalNomPere = (string)MaConnectionSql.MonLecteur["ch_nompere"];
                string chevalNomMere = (string)MaConnectionSql.MonLecteur["ch_nommere"];
                string chevalSexe = (string)MaConnectionSql.MonLecteur["ch_sexe"];
                // c'est ici que ça deviens compliqué, bien lire les deux prochaines lignes plusieurs fois pour comprendre.
                int chevalEnt = (int)MaConnectionSql.MonLecteur["ent_id"];
                int chevalPro = (int)MaConnectionSql.MonLecteur["pro_id"];

                // Et la bim, on crée l'objet cheval. ( Et y'a pas d'erreur wow )
                unCheval = new Cheval(chevalId, chevalNom, chevalCouleur, chevalAge, chevalSpecialite, chevalNomPere, chevalNomMere, chevalSexe, chevalEnt, chevalPro);

            }
            

            return unCheval;
        }

        /// <summary>
        /// Cette méthode retourne une liste de cheval assigné à une course en passant l'id de la course en paramètre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Cheval> GetLesChevauxDuneCourse(int id)
        {
            List<Participe> listPart = new List<Participe>();

            
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();

            string stringSql2 = "select * from participe where crs_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            while (MaConnectionSql.MonLecteur.Read())
            {
                // recuperation de valeurs
                int chevalId = (int)MaConnectionSql.MonLecteur["ch_id"];
                int courseId = (int)MaConnectionSql.MonLecteur["crs_id"];
                int jockeyId = (int)MaConnectionSql.MonLecteur["joc_id"];
                int classement = (int)MaConnectionSql.MonLecteur["classement"];
                
                Participe uneParticipation = new Participe(chevalId, courseId, jockeyId, classement);
                // on ajoute le cheval à la liste
                listPart.Add(uneParticipation);
            }
            List<Cheval> listChe = new List<Cheval>();
            foreach (Participe unPar in listPart)
            {
                listChe.Add(GetUnCheval(unPar.Cheval));
            }
            MaConnectionSql.MonLecteur.Close();
            MaConnectionSql.CloseConnection();
            return listChe;
            // auccune erreur, wow.
        }

        public static List<Participe> GetCourseDuCheval(int idCheval)
        {
            List<Participe> listParticipe = new List<Participe>();
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();

            string stringSql2 = "select * from participe WHERE ch_id =" + idCheval;
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
        
    }
}
