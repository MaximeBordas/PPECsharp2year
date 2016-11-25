using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPEV2BO
{
    public class Course
    {
        // ATTRIBUTS
        private int id;
        private string nom;
        private string lieu;
        private int nbrMax;
        private int price;
        private int first;
        private int second;
        private int third;
        private int fourth;
        private int fifth;
        private Hippodrome hip;

        // NE PAS OUBLIER D'ASSIGNER ID HIPPODROME

        // PROPRIETES
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Lieu
        {
            get { return lieu; }
            set { lieu = value; }
        }
        public int NbrMax
        {
            get { return nbrMax; }
            set { nbrMax = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public int First
        {
            get { return first; }
            set { first = value; }
        }
        public int Second
        {
            get { return second; }
            set { second = value; }
        }
        public int Third
        {
            get { return third; }
            set { third = value; }
        }
        public int Fourth
        {
            get { return fourth; }
            set { fourth = value; }
        }
        public int Fifth
        {
            get { return fifth; }
            set { fifth = value; }
        }
        public Hippodrome Hip
        {
            get { return hip; }
            set { hip = value; }
        }

        //CONSTRUCTEUR
        public Course(int unId, string unNom, string unLieu,int unNbrMax, int unPrice, int unFirst, int unSecond, int unThird, int unFourth, int unFifth, Hippodrome unHip)
        {
            id = unId;
            nom = unNom;
            lieu = unLieu;
            nbrMax = unNbrMax;
            price = unPrice;
            first = unFirst;
            second = unSecond;
            third = unThird;
            fourth = unFourth;
            fifth = unFifth;
            hip = unHip;
        }
        public Course(string unNom, string unLieu, int unNbrMax, int unPrice, int unFirst, int unSecond, int unThird, int unFourth, int unFifth, Hippodrome unHip)
        {
            nom = unNom;
            lieu = unLieu;
            nbrMax = unNbrMax;
            price = unPrice;
            first = unFirst;
            second = unSecond;
            third = unThird;
            fourth = unFourth;
            fifth = unFifth;
            hip = unHip;
        }


    }
}
