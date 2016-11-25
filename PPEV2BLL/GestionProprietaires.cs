using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using PPEV2DAL;

namespace PPEV2BLL
{
    public class GestionProprietaires
    {
        private GestionProprietaires uneGestionProprietaire;

        public GestionProprietaires GetGestionProprietaire()
        {
            if (uneGestionProprietaire == null)
            {
                uneGestionProprietaire = new GestionProprietaires();
            }
            return uneGestionProprietaire;
        }
        // Méthode qui renvoit une List d'objets Utilisateur en faisant appel à la méthode GetUtilisateurs() de la DAL
        public static List<Proprietaire> GetProprietaire()
        {
            return ProprietaireDAO.GetProprietaire();
        }
        //crée un propriétaire
        public static int CreerProprietaire(string nom, string prenom, string civilite)
        {
            Proprietaire pro = new Proprietaire(nom, prenom, civilite);
            return ProprietaireDAO.AjoutProprietaire(pro);
        }
        //modifie un propriétaire
        public static int ModifierProprietaire(string nom, string prenom, string civilite)
        {
            Proprietaire pro = new Proprietaire(nom, prenom, civilite);
            return ProprietaireDAO.UpdateProprietaire(pro);
        }
        //supprime un proprietaire
        public static int SupprimerProprietaire(int id)
        {
            return ProprietaireDAO.DeleteProprietaire(id);
        }
    }

}
