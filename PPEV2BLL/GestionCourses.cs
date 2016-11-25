﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using PPEV2DAL;

namespace PPEV2BLL
{
    class GestionCourses
    {
        private GestionCourses uneGestionCourses;

        public GestionCourses GetGestionCourses()
        {
            if (uneGestionCourses == null)
            {
                uneGestionCourses = new GestionCourses();
            }
            return uneGestionCourses;
        }
        //Crée une list de course
        public static List<Course> GetCourses()
        {
            return CoursesDAO.GetCourses();
        }
        //crée une course
        public static int CreerCourse(string nom, string lieu, int nbrMax, int unPrice, int unFirst, int unSecond, int unThird, int unFourth, int unFifth, Hippodrome unHip)
        {
            Course crs = new Course(nom, lieu, nbrMax, unPrice, unFirst, unSecond, unThird, unFourth, unFifth, unHip);
            return CoursesDAO.AjoutCourse(crs);
        }
        //modifie une course
        public static int ModifierCourse(string nom, string lieu, int nbrMax, int unPrice, int unFirst, int unSecond, int unThird, int unFourth, int unFifth, Hippodrome unHip)
        {
            Course crs = new Course(nom, lieu, nbrMax, unPrice, unFirst, unSecond, unThird, unFourth, unFifth, unHip);
            return CoursesDAO.UpdateCourse(crs);
        }
        //supprimer une course
        public static int SupprimerCourse(int id)
        {
            return CoursesDAO.DeleteCourse(id);
        }
    }
}