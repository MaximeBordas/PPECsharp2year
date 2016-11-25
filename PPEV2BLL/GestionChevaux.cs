using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using PPEV2DAL;

namespace PPEV2BLL
{
    class GestionChevaux
    {
        private GestionChevaux uneGestionChevaux;

        public GestionChevaux GetGestionChevaux()
        {
            if (uneGestionChevaux == null)
            {
                uneGestionChevaux = new GestionChevaux();
            }
            return uneGestionChevaux;
        }
        //List contenant tout les chevaux
        public static List<Cheval> GetChevaux()
        {
            return ChevalDAO.GetChevaux();
        }
        //Crée un cheval
        public static int CreerCheval(string nom, string couleur, int age, string specialite, string nompere, string nommere, string sexe, Entraineur unEnt, Proprietaire unPro)
        {
            Cheval ch = new Cheval(nom, couleur, age, specialite, nompere, nommere, sexe, unEnt, unPro);
            return ChevalDAO.AjoutCheval(ch);
        }
        //modifier un cheval
        public static int ModifierCheval(string nom, string couleur, int age, string specialite, string nompere, string nommere, string sexe, Entraineur unEnt, Proprietaire unPro)
        {
            Cheval ch = new Cheval(nom, couleur, age, specialite, nompere, nommere, sexe, unEnt, unPro);
            return ChevalDAO.UpdateCheval(ch);
        }
        //supprimer un cheval
        public static int SupprimerCheval(int id)
        {
            return EntraineurDAO.DeleteEntraineur(id);
        }

    }
}
