﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPEV2BO;
using MySql.Data.MySqlClient;

namespace PPEV2DAL
{
    public class CoursesDAO
    {
        private CoursesDAO uneCourseDAO;

        public CoursesDAO GetUneCourseDAO()
        {
            if (uneCourseDAO == null)
            {
                uneCourseDAO = new CoursesDAO();
            }
            return uneCourseDAO;
        }

        public static List<Course> GetCourses()
        {
            List<Course> ListCourse = new List<Course>();
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql2 = "select * from course";
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            while (MaConnectionSql.MonLecteur.Read())
            {
                // recuperation de valeurs
                int crsId = (int)MaConnectionSql.MonLecteur["crs_id"];
                string crsNom = (string)MaConnectionSql.MonLecteur["crs_nom"];
                string crsLieu = (string)MaConnectionSql.MonLecteur["crs_lieu"];
                int crsnbrsMax = (int)MaConnectionSql.MonLecteur["crs_nbrmax"];
                int crsPrice = (int)MaConnectionSql.MonLecteur["crs_price"];
                int crsFirst = (int)MaConnectionSql.MonLecteur["crs_first"];
                int crsSecond = (int)MaConnectionSql.MonLecteur["crs_second"];
                int crsThird = (int)MaConnectionSql.MonLecteur["crs_third"];
                int crsFourth = (int)MaConnectionSql.MonLecteur["crs_fourth"];
                int crsFifth = (int)MaConnectionSql.MonLecteur["crs_fifth"];
                int courseHip = (int)MaConnectionSql.MonLecteur["hip_id"];
                int crsAgeMin = (int)MaConnectionSql.MonLecteur["crs_agemin"];
                int crsAgeMax = (int)MaConnectionSql.MonLecteur["crs_agemax"];
                string crsSexe = (string)MaConnectionSql.MonLecteur["crs_sexe"];
                string crsDate = (string)MaConnectionSql.MonLecteur["crs_date"];

                Course uneCourse = new Course(crsId, crsNom, crsLieu, crsnbrsMax, crsPrice, crsFirst, crsSecond, crsThird, crsFourth, crsFifth, courseHip, crsAgeMin, crsAgeMax, crsSexe, crsDate);

                ListCourse.Add(uneCourse);

            }
            MaConnectionSql.MonLecteur.Close();
            MaConnectionSql.CloseConnection();
            return ListCourse;
        }
        public static int AjoutCourse(Course uneCourse)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            // ok, la ligne suivante en sql fait un peu mal à la tête
            // merci de bien la vérifié au niveau de cheval.ent.id et cheval.pro.Id
            string stringSql = " insert into course (crs_nom, crs_lieu, crs_nbrmax, crs_price, crs_first, crs_second, crs_third, crs_fourth, crs_fifth, hip_id, crs_agemin, crs_agemax, crs_sexe, crs_date) VALUES ('" + uneCourse.Nom + "','" + uneCourse.Lieu + "'," + uneCourse.NbrMax + "," + uneCourse.Price + "," + uneCourse.First + "," + uneCourse.Second + "," + uneCourse.Third + "," + uneCourse.Fourth + "," + uneCourse.Fifth + "," + uneCourse.Hip + "," + uneCourse.AgeMin + "," + uneCourse.AgeMax + ",'" + uneCourse.Sexe + "','" + uneCourse.Date + "')";
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        public static int UpdateCourse(Course uneCourse)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "update course set crs_nom = '" + uneCourse.Nom + "', crs_lieu = '" + uneCourse.Lieu + "', crs_nbrmax = " + uneCourse.NbrMax + ", crs_price =" + uneCourse.Price + ", crs_first = " + uneCourse.First + ", crs_second = " + uneCourse.Second + ", crs_third = " + uneCourse.Third + ", crs_fourth = " + uneCourse.Fourth + ", crs_fifth = " + uneCourse.Fifth + ", hip_id = " + uneCourse.Hip + ", crs_agemin = " + uneCourse.AgeMin + ", crs_agemax = " + uneCourse.AgeMax + ", crs_sexe = '" + uneCourse.Sexe + "', crs_date = '" + uneCourse.Date + "' WHERE crs_id = " + uneCourse.Id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        public static int DeleteCourse(int id)
        {
            int nbEnr;
            // connexion à la BD
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql = "delete from course where crs_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql;
            nbEnr = MaConnectionSql.Cmd.ExecuteNonQuery();
            MaConnectionSql.CloseConnection();
            return nbEnr;
        }
        public static Course GetUneCourse(int id)
        {
            Course uneAutreCourse = null;

            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql2 = "select * from course where crs_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            // recuperation de valeurs
            if (MaConnectionSql.MonLecteur.Read())
            {
                int crsId = (int)MaConnectionSql.MonLecteur["crs_id"];
                string crsNom = (string)MaConnectionSql.MonLecteur["crs_nom"];
                string crsLieu = (string)MaConnectionSql.MonLecteur["crs_lieu"];
                int crsnbrsMax = (int)MaConnectionSql.MonLecteur["crs_nbrmax"];
                int crsPrice = (int)MaConnectionSql.MonLecteur["crs_price"];
                int crsFirst = (int)MaConnectionSql.MonLecteur["crs_first"];
                int crsSecond = (int)MaConnectionSql.MonLecteur["crs_second"];
                int crsThird = (int)MaConnectionSql.MonLecteur["crs_third"];
                int crsFourth = (int)MaConnectionSql.MonLecteur["crs_fourth"];
                int crsFifth = (int)MaConnectionSql.MonLecteur["crs_fifth"];
                int courseHip = (int)MaConnectionSql.MonLecteur["hip_id"];
                int crsAgeMin = (int)MaConnectionSql.MonLecteur["crs_agemin"];
                int crsAgeMax = (int)MaConnectionSql.MonLecteur["crs_agemax"];
                string crsSexe = (string)MaConnectionSql.MonLecteur["crs_sexe"];
                string crsDate = (string)MaConnectionSql.MonLecteur["crs_date"];


                uneAutreCourse = new Course(crsId, crsNom, crsLieu, crsnbrsMax, crsPrice, crsFirst, crsSecond, crsThird, crsFourth, crsFifth, courseHip, crsAgeMin, crsAgeMax, crsSexe, crsDate);

            }
            
            MaConnectionSql.CloseConnection();
            return uneAutreCourse;


        }
        public static List<Course> GetCourseDunHip(int id)
        {
            List<Course> ListCourse = new List<Course>();
            ConnexionDb MaConnectionSql = new ConnexionDb();
            MaConnectionSql.InitializeConnection();
            MaConnectionSql.OpenConnection();
            string stringSql2 = "select * from course where hip_id = " + id;
            MaConnectionSql.Cmd.CommandText = stringSql2;
            MaConnectionSql.MonLecteur = MaConnectionSql.Cmd.ExecuteReader();
            // recuperation de valeurs
            while (MaConnectionSql.MonLecteur.Read())
            {
                // recuperation de valeurs
                int crsId = (int)MaConnectionSql.MonLecteur["crs_id"];
                string crsNom = (string)MaConnectionSql.MonLecteur["crs_nom"];
                string crsLieu = (string)MaConnectionSql.MonLecteur["crs_lieu"];
                int crsnbrsMax = (int)MaConnectionSql.MonLecteur["crs_nbrmax"];
                int crsPrice = (int)MaConnectionSql.MonLecteur["crs_price"];
                int crsFirst = (int)MaConnectionSql.MonLecteur["crs_first"];
                int crsSecond = (int)MaConnectionSql.MonLecteur["crs_second"];
                int crsThird = (int)MaConnectionSql.MonLecteur["crs_third"];
                int crsFourth = (int)MaConnectionSql.MonLecteur["crs_fourth"];
                int crsFifth = (int)MaConnectionSql.MonLecteur["crs_fifth"];
                int courseHip = (int)MaConnectionSql.MonLecteur["hip_id"];
                int crsAgeMin = (int)MaConnectionSql.MonLecteur["crs_agemin"];
                int crsAgeMax = (int)MaConnectionSql.MonLecteur["crs_agemax"];
                string crsSexe = (string)MaConnectionSql.MonLecteur["crs_sexe"];
                string crsDate = (string)MaConnectionSql.MonLecteur["crs_date"];

                Course uneCourse = new Course(crsId, crsNom, crsLieu, crsnbrsMax, crsPrice, crsFirst, crsSecond, crsThird, crsFourth, crsFifth, courseHip, crsAgeMin, crsAgeMax, crsSexe, crsDate);

                ListCourse.Add(uneCourse);

            }
            MaConnectionSql.MonLecteur.Close();
            MaConnectionSql.CloseConnection();
            return ListCourse;
        }
    }
}
