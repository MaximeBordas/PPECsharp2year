using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using PPEV2DAL;

namespace PPEV2BLL
{
    class GestionParticipations
    {
        private GestionParticipations UneGestionParticipations;

        public GestionParticipations GetGestionParticipations()
        {
            if (UneGestionParticipations == null)
            {
                UneGestionParticipations = new GestionParticipations();
            }
            return UneGestionParticipations;
        }
        // Méthode qui renvoit une List d'objets Participe en faisant appel à la méthode GetParticipation() de la DAL
        public static List<Participe> GetParticipations()
        {
            return ParticipeDAO.GetParticipation();
        }
        //crée une participation
        public static int CreerParticipation(Cheval unChe, Course uneCo, Jockey unJo, DateTime date, int unClassement)
        {
            Participe par = new Participe(unChe, uneCo, unJo, date, unClassement);
            return ParticipeDAO.AjoutParticipation(par);
        }
        //modifier une participation
        public static int ModifierParticipation(Cheval unChe, Course uneCo, Jockey unJo, DateTime date, int unClassement)
        {
            Participe par = new Participe(unChe, uneCo, unJo, date, unClassement);
            return ParticipeDAO.UpdateParticipation(par);
        }
        //supprimer une participation
        public static int DeleteParticipation(int id)
        {
            return ParticipeDAO.DeleteParticipation(id);
        }
    }
}
