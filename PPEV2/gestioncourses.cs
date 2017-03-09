using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPEV2BLL;

namespace PPEV2
{
    public partial class gestioncourses : Form
    {
        public gestioncourses()
        {
            InitializeComponent();

            HippodromeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CourseComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            List<PPEV2BO.Hippodrome> listeHip = new List<PPEV2BO.Hippodrome>();
            listeHip = GestionHippodrome.GetHippodrome();
            foreach (PPEV2BO.Hippodrome Hip in listeHip)
            {
                HippodromeComboBox.Items.Add(Hip.Nom);
                HippodromeComboBox.MaxDropDownItems = listeHip.Count();
            }

            List<PPEV2BO.Cheval> uneListeDeChevaux = new List<PPEV2BO.Cheval>();
            uneListeDeChevaux = GestionChevaux.GetChevaux();
            foreach (PPEV2BO.Cheval Che in uneListeDeChevaux)
            {
                comboBox1.Items.Add(Che.Nom);
                comboBox1.MaxDropDownItems = uneListeDeChevaux.Count();
            }

            List<PPEV2BO.Jockey> uneListeJockey = new List<PPEV2BO.Jockey>();
            uneListeJockey = GestionJockeys.GetJockeys();
            foreach (PPEV2BO.Jockey Jck in uneListeJockey)
            {
                comboBox2.Items.Add(Jck.Nom);
                comboBox2.MaxDropDownItems = uneListeJockey.Count();
            }

        }

        private void NomEntComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CourseComboBox.Items.Clear();
            int hip = 0;
            string hipSelect = HippodromeComboBox.Text;
            List<PPEV2BO.Hippodrome> listeHippodrome = new List<PPEV2BO.Hippodrome>();
            listeHippodrome = GestionHippodrome.GetHippodrome();
            foreach (PPEV2BO.Hippodrome Hip in listeHippodrome)
            {
                if (Hip.Nom == hipSelect)
                {
                    hip = Hip.Id;
                }
            }

            List<PPEV2BO.Course> listeCou = new List<PPEV2BO.Course>();
            listeCou = GestionCourses.GetCourseDunHip(hip);
            foreach (PPEV2BO.Course Cou in listeCou)
            {
                CourseComboBox.Items.Add(Cou.Nom);
                CourseComboBox.MaxDropDownItems = listeCou.Count();
            }
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

        private void CourseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int crs = 0;
            string crsSelect = CourseComboBox.Text;
            List<PPEV2BO.Course> listeCourse = new List<PPEV2BO.Course>();
            listeCourse = GestionCourses.GetCourses();
            foreach (PPEV2BO.Course Cou in listeCourse)
            {
                if (Cou.Nom == crsSelect)
                {
                    crs = Cou.Id;
                }
            }
            List<PPEV2BO.Cheval> uneListe = new List<PPEV2BO.Cheval>();
            uneListe = GestionChevaux.GetChevauxDuneCourse(crs);
            dataGridView1.DataSource = uneListe;

            
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[8].Visible = false;
            this.dataGridView1.Columns[9].Visible = false;
        }

        private void btnajout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("êtes vous sur de vouloir ajouter le cheval selectionné ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // RECUPERATION DE l'ID DE LA COURSE ET DE LA DATE
                int crs = 0;
                string laDate = "x";
                string crsSelect = CourseComboBox.Text;
                List<PPEV2BO.Course> listeCourse = new List<PPEV2BO.Course>();
                listeCourse = GestionCourses.GetCourses();
                foreach (PPEV2BO.Course Cou in listeCourse)
                {
                    if (Cou.Nom == crsSelect)
                    {
                        crs = Cou.Id;
                        laDate = Cou.Date.ToString();
                    }
                }

                // RECUPERATION DE L'ID DU CHEVAL
                int chv = 0;
                string chvSelect = comboBox1.Text;
                List<PPEV2BO.Cheval> listeChevaux = new List<PPEV2BO.Cheval>();
                listeChevaux = GestionChevaux.GetChevaux();
                foreach (PPEV2BO.Cheval Chv in listeChevaux)
                {
                    if (Chv.Nom == chvSelect)
                    {
                        chv = Chv.Id;
                    }
                }

                /// RECUPERATION DE L'ID DU JOCKEY
                int jck = 0;
                string jckSelect = comboBox2.Text;
                List<PPEV2BO.Jockey> listeJockey = new List<PPEV2BO.Jockey>();
                listeJockey = GestionJockeys.GetJockeys();
                foreach (PPEV2BO.Jockey Jck in listeJockey)
                {
                    if (Jck.Nom == jckSelect)
                    {
                        jck = Jck.Id;
                    }
                }
                // -----------------------------------------------------------
                // VERIFICATION DE SAISIE !! LIKE A BOSS !!!!!
                // -----------------------------------------------------------

                PPEV2BO.Cheval unCheval = GestionChevaux.GetUnChevaux(chv);
                PPEV2BO.Course uneCourse = GestionCourses.GetUneCourse(crs);

                if (unCheval.Age < uneCourse.AgeMin && unCheval.Age > uneCourse.AgeMax)
                {
                    MessageBox.Show("Impossible ! Le Cheval séléctionné ne peux pas faire partie de cette course à cause de son age.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (GestionChevaux.GetUnChevaux(chv).Sexe != GestionCourses.GetUneCourse(crs).Sexe && GestionCourses.GetUneCourse(crs).Sexe != "X")
                {
                    MessageBox.Show("Impossible ! Le Cheval séléctionné ne peux pas faire partie de cette course à cause de son sexe.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                List<PPEV2BO.Cheval> uneListe = new List<PPEV2BO.Cheval>();
                uneListe = GestionChevaux.GetChevauxDuneCourse(crs);
                dataGridView1.DataSource = uneListe;
                if (uneListe.Count() >= GestionCourses.GetUneCourse(crs).NbrMax)
                {
                    MessageBox.Show("Impossible ! La course a atteint son maximum de chevaux.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (PPEV2BO.Cheval unChevalTest in uneListe)
                {
                    if (unChevalTest.Id == GestionChevaux.GetUnChevaux(chv).Id)
                    {
                        MessageBox.Show("Impossible ! Ce cheval est déja dans la liste.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                List<PPEV2BO.Participe> uneListedeParticipation = new List<PPEV2BO.Participe>();
                uneListedeParticipation = GestionParticipations.GetParticipations();

                foreach (PPEV2BO.Participe uneParticipation in uneListedeParticipation)
                {
                    if (uneParticipation.Jockey == GestionJockeys.GetUnJockey(jck).Id && uneParticipation.Course == GestionCourses.GetUneCourse(crs).Id)
                    {
                        MessageBox.Show("Impossible ! Ce Jockey est déja dans a assigné à un Cheval de la liste.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                // -------------------------------------------------------------

                GestionParticipations.CreerParticipation(chv, crs, jck, 0);
                MessageBox.Show(comboBox1.Text + " a bien été ajouté", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);


                uneListe = GestionChevaux.GetChevauxDuneCourse(crs);
                dataGridView1.DataSource = uneListe;


                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[8].Visible = false;
                this.dataGridView1.Columns[9].Visible = false;




            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
