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
    public partial class listeCourse : Form
    {
        public listeCourse()
        {
            InitializeComponent();

            //Permet de récupérer les Courses et de les insérer dans le DataGridView
            List<PPEV2BO.Course> uneListe = new List<PPEV2BO.Course>();
            uneListe = GestionCourses.GetCourses();
            dataGridView1.DataSource = uneListe;
            //pour ne pas montrer l'id de la course Logique quoi
            this.dataGridView1.Columns[0].Visible = false;

            //Permet d'avoir la liste d'hippodrome dans la comboBox
            List<PPEV2BO.Hippodrome> listeHippodrome = new List<PPEV2BO.Hippodrome>();
            listeHippodrome = GestionHippodrome.GetHippodrome();
            foreach (PPEV2BO.Hippodrome hipp in listeHippodrome)
            {
                nomHippComboBox.Items.Add(hipp.Nom);
                nomHippComboBox.MaxDropDownItems = listeHippodrome.Count();
            }

        }
        //Bouton de retour 
        private void button1_Click(object sender, EventArgs e)
        {
            Menu m = new PPEV2.Menu();
            m.Show();
            this.Hide();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                //On met le contenu des cases du DataGridView dans des variables.
                int idSelected = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string nomSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                string lieuSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                string nbrMaxSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                string totalpriceSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[4]);
                string firstSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[5]);
                string secondSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[6]);
                string thirdSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[7]);
                string fourthSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[8]);
                string fifthSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[9]);
                int idHippSelected = Convert.ToInt32(dataGridView1.CurrentRow.Cells[10]);

                PPEV2BO.Hippodrome unHipp = new PPEV2BO.Hippodrome();
                unHipp = GestionHippodrome.GetUnHippodrome(idHippSelected);
                //assignation des variables au informations pour la modification et la suppression
                
                nomCourseTextBox.Text = nomSelected;
                lieuCourseTextBox.Text = lieuSelected;
                nbrMaxTextBox.Text = nbrMaxSelected;
                CashTextBox.Text = totalpriceSelected;
                gain1TextBox.Text = firstSelected;
                gain2TextBox.Text = secondSelected;
                gain3TextBox.Text = thirdSelected;
                gain4TextBox.Text = fourthSelected;
                gain5TextBox.Text = fifthSelected;
                nomHippComboBox.Text = unHipp.Nom;

            }
        }

        private void btnajout_Click(object sender, EventArgs e)
        {

        }

        private void btnmodif_Click(object sender, EventArgs e)
        {

        }

        private void btnsuppr_Click(object sender, EventArgs e)
        {

        }
    }
}
