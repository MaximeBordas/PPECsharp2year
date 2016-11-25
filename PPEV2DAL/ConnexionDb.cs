using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using MySql.Data.MySqlClient;


namespace PPEV2DAL
{
    public class ConnexionDb
    {
        // ATTRIBUTS
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataReader monLecteur;
        private string chaineConnection;

        // accesseur en lecture de la chaine de connexion
        public string GetChaineConnexion()
        {
            return chaineConnection;
        }
        // Accesseur en écriture de la chaîne de connexion
        public void SetchaineConnexion(string ch)
        {
            chaineConnection = ch;
        }
        // Accesseur en lecture, renvoi une instance de connexion
        public MySqlConnection GetConnexionBD()
        {
            if (con == null)
            {
                con = new MySqlConnection();
            }
            return con;
        }

        public MySqlConnection Con
        {
            get { return con; }
            set { con = value; }
        }
        public MySqlCommand Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        public MySqlDataReader MonLecteur
        {
            get { return monLecteur; }
            set { monLecteur = value; }
        }
        public string ChaineConnection
        {
            get { return chaineConnection; }
            set { chaineConnection = value; }
        }


        // CONSTRUCTEUR
        public ConnexionDb()
        {
        }
        // METHODES
        public void InitializeConnection()
        {
            con = new MySqlConnection("server = localhost; user id = root; persistsecurityinfo = True; database = testppe;");
            cmd = new MySqlCommand("", con);
        }

        public void OpenConnection()
        {
            con.Open();
        }
        public void CloseConnection()
        {
            con.Close();
        }
    }
}
