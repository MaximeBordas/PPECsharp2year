using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using PPEV2DAL;

namespace PPEV2BLL
{
    class GestionHippodrome
    {
        private GestionHippodrome uneGestionHippodrome;

        public GestionHippodrome GetGestionHippodrome()
        {
            if (uneGestionHippodrome == null)
            {
                uneGestionHippodrome = new GestionHippodrome();
            }
            return uneGestionHippodrome;
        }

        // Méthode qui renvoit une List d'objets Hippodrome en faisant appel à la méthode GetHippodrome() de la DAL
        public static List<Hippodrome> GetHippodrome()
        {
            return HippodromeDAO.GetHippodromes();
        }
        //Crée un hippodrome
        public static int CreerHippodrome(string nom, string lieu)
        {
            Hippodrome hip = new Hippodrome(nom, lieu);
            return HippodromeDAO.AjoutHippodrome(hip);
        }
        //modifier un entraineur
        public static int ModifierHippodrome(string nom, string lieu)
        {
            Hippodrome hip = new Hippodrome(nom, lieu);
            return HippodromeDAO.UpdateHippodrome(hip);
        }
        //supprime un hippodrome
        public static int SupprimerHippodrome(int id)
        {
            return HippodromeDAO.DeleteHippodrome(id);
        }
    }
}
