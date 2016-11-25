using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPEV2BO
{
    public class Participe
    {
        // ATTRIBUTS
        private Cheval chvl;
        private Course crs;
        private Jockey jck;
        private DateTime dateCourue;
        private int classement;
        

        // PROPRIETES
        public DateTime DateCourue
        {
            get { return dateCourue; }
            set { dateCourue = value; }
        }
        public Cheval Cheval
        {
            get { return chvl; }
            set { chvl = value; }
        }
        public Course Course
        {
            get { return crs; }
            set { crs = value; }
        }
        public Jockey Jockey
        {
            get { return jck; }
            set { jck = value; }
        }
        public int Clas
        {
            get { return classement; }
            set { classement = value; }
        }


        // CONSTRUCTEUR
        public Participe(Cheval unCheval, Course uneCourse, Jockey unJockey, DateTime uneDate, int unClas)
        {
            chvl = unCheval;
            crs = uneCourse;
            jck = unJockey;
            dateCourue = uneDate;
            classement = unClas;
        }
    }
}
