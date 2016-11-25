using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using PPEV2DAL;

namespace PPEV2BLL
{
    class GestionCalendriers
    {
        private GestionCalendriers UneGestionCalendriers;

        public GestionCalendriers GetGestionCalendriers()
        {
            if (UneGestionCalendriers == null)
            {
                UneGestionCalendriers = new GestionCalendriers();
            }
            return UneGestionCalendriers;
        }
        //crée une list de calendrier
        public static List<Calendrier> GetCalendriers()
        {
            return CalendrierDAO.GetCalendrier();
        }
        //crée un calendrier
        public static int CreerCalendrier(DateTime date)
        {
            Calendrier cal = new Calendrier(date);
            return CalendrierDAO.AjoutCalendrier(cal);
        }
        //modifie un calendrier
        public static int ModifierCalendrier(DateTime date)
        {
            Calendrier cal = new Calendrier(date);
            return CalendrierDAO.UpdateCalendrier(cal);
        }
        //supprime un calendrier
        public static int SupprimerCalendrier(DateTime date)
        {
            return CalendrierDAO.DeleteCalendrier(date);
        }
    }
}
