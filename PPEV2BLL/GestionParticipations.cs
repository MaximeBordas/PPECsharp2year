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
        public static List<Participe> GetParticipations()
        {
            return ParticipeDAO.GetParticipation();
        }
        public static int CreerParticipation(Cheval unChe, Course uneCo, Jockey unJo, DateTime date, int unClassement)
        {
            Participe par = new Participe(unChe, uneCo, unJo, date, unClassement);
            return ParticipeDAO.AjoutParticipation(par);
        }
        public static int ModifierParticipation(Cheval unChe, Course uneCo, Jockey unJo, DateTime date, int unClassement)
        {
            Participe par = new Participe(unChe, uneCo, unJo, date, unClassement);
            return ParticipeDAO.UpdateParticipation(par);
        }
        public static int ModifierParticipation(int id)
        {
            return ParticipeDAO.DeleteParticipation(id);
        }
    }
}
