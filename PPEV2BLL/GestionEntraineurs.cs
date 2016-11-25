using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using PPEV2DAL;

namespace PPEV2BLL
{
    public class GestionEntraineurs
    {
        private GestionEntraineurs uneGestionEntraineurs;

        public GestionEntraineurs GetGestionEntraineurs()
        {
            if (uneGestionEntraineurs == null)
            {
                uneGestionEntraineurs = new GestionEntraineurs();
            }
            return uneGestionEntraineurs;
        }

        // Méthode qui renvoit une List d'objets Utilisateur en faisant appel à la méthode GetUtilisateurs() de la DAL
        public static List<Entraineur> GetEntraineurs()
        {
            return EntraineurDAO.GetEntraineurs();
        }
        //crée un entraineur
        public static int CreerEntraineur(string nom, string prenom, int age, string civilite, string localisation)
        {
            Entraineur et = new Entraineur(nom, prenom, age, civilite, localisation);
            return EntraineurDAO.AjoutEntraineur(et);
        }
        //modifie un entraineur
        public static int ModifierEntraineur(string nom, string prenom, int age, string civilite, string localisation)
        {
            Entraineur et = new Entraineur(nom, prenom, age, civilite, localisation);
            return EntraineurDAO.UpdateEntraineur(et);
        }
        //supprimer un entraineur
        public static int SupprimerEntraineur(int id)
        {
            return EntraineurDAO.DeleteEntraineur(id);
        }
    }
}
