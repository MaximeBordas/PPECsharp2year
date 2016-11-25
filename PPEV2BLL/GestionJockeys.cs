using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using PPEV2DAL;

namespace PPEV2BLL
{
    class GestionJockeys
    {
        private GestionJockeys uneGestionJockey;

        public GestionJockeys GetGestionJockeys()
        {
            if (uneGestionJockey == null)
            {
                uneGestionJockey = new GestionJockeys();
            }
            return uneGestionJockey;
        }
        // Méthode qui renvoit une List d'objets Jockey en faisant appel à la méthode GetJockey() de la DAL
        public static List<Jockey> GetJockeys()
        {
            return JockeyDAO.GetJockeys();
        }
        //crée un jockey
        public static int CreerJockey(string nom, string prenom, int age, string civilite)
        {
            Jockey jo = new Jockey(nom, prenom, age, civilite);
            return JockeyDAO.AjoutJockey(jo);
        }
        //modifier un jockey
        public static int ModifierJockey(string nom, string prenom, int age, string civilite)
        {
            Jockey jo = new Jockey(nom, prenom, age, civilite);
            return JockeyDAO.UpdateJockey(jo);
        }
        //supprimer un jockey
        public static int SupprimerJockey(int id)
        {
            return JockeyDAO.DeleteJockey(id);
        }
    }
}
