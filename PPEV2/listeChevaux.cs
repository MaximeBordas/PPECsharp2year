﻿using System;
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
    public partial class listeChevaux : Form
    {
        
        public listeChevaux()
        {
            InitializeComponent();
            List<PPEV2BO.Cheval> uneListe = new List<PPEV2BO.Cheval>();
            uneListe = GestionChevaux.GetChevaux();
            dataGridView1.DataSource = uneListe;
   

            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[8].Visible = false;
            this.dataGridView1.Columns[9].Visible = false;

            List<PPEV2BO.Entraineur> listeEntraineur = new List<PPEV2BO.Entraineur>();
            listeEntraineur = GestionEntraineurs.GetEntraineurs();
            foreach (PPEV2BO.Entraineur Ent in listeEntraineur)
            {
                NomEntComboBox.Items.Add(Ent.Nom);
                NomEntComboBox.MaxDropDownItems = listeEntraineur.Count();
            }
            List<PPEV2BO.Proprietaire> listeProprietaire = new List<PPEV2BO.Proprietaire>();
            listeProprietaire = GestionProprietaires.GetProprietaire();
            foreach (PPEV2BO.Proprietaire Pro in listeProprietaire)
            {
                NomProComboBox.Items.Add(Pro.Nom);
                NomEntComboBox.MaxDropDownItems = listeProprietaire.Count();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Etes vous sur de vouloir modifier le cheval selectionné ?", "Attention" ,MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int idSelected = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                int age = 0;
                Int32.TryParse(AGETextBox.Text, out age);
                string sexe = "X";

                int ent = 0;
                string entSelect = NomEntComboBox.Text;
                List<PPEV2BO.Entraineur> listeEntraineur = new List<PPEV2BO.Entraineur>();
                listeEntraineur = GestionEntraineurs.GetEntraineurs();
                foreach (PPEV2BO.Entraineur Ent in listeEntraineur)
                {
                    if (Ent.Nom == entSelect)
                    {
                        ent = Ent.Id;
                    }
                }

                int pro = 0;
                string proSelect = NomProComboBox.Text;
                List<PPEV2BO.Proprietaire> listeProprietaire = new List<PPEV2BO.Proprietaire>();
                listeProprietaire = GestionProprietaires.GetProprietaire();
                foreach (PPEV2BO.Proprietaire Pro in listeProprietaire)
                {
                    if (Pro.Nom == proSelect)
                    {
                        pro = Pro.Id;
                    }
                }


                if (HOMMEradio.Checked == true)
                {
                    sexe = "M";
                }
                else if (FEMMERadio.Checked == true)
                {
                    sexe = "F";
                }

                GestionChevaux.ModifierCheval(idSelected,NOMTextBox.Text, CouleurTextBox.Text, age, SpeListBox.Text, NOMPereTextBox.Text, NOMMereTextBox.Text, sexe, ent, pro);
                MessageBox.Show(NOMTextBox.Text + " a bien été modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Update();
                dataGridView1.Refresh();
                dataGridView1.DataSource = null;
                List<PPEV2BO.Cheval> uneListe = new List<PPEV2BO.Cheval>();
                uneListe = GestionChevaux.GetChevaux();
                dataGridView1.DataSource = uneListe;
                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[8].Visible = false;
                this.dataGridView1.Columns[9].Visible = false;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                // a = Convert.ToString(selectedRow.Cells["nom"].Value);
                int idSelected = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string nomSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                string couleurSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                string ageSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                string speSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                string nomPereSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                string nomMereSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
                string sexeSelected = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
                int idEntSelected = Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value);
                int idProSelected = Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value);


                PPEV2BO.Entraineur unEnt = new PPEV2BO.Entraineur();
                unEnt = GestionEntraineurs.GetUnEntraineurs(idEntSelected);
                NomEntComboBox.Text = unEnt.Nom;
                PPEV2BO.Proprietaire unPro = new PPEV2BO.Proprietaire();
                unPro = GestionProprietaires.GetUnProprietaire(idProSelected);
                NomProComboBox.Text = unPro.Nom;
                CouleurTextBox.Text = couleurSelected;
                NOMTextBox.Text = nomSelected;
                AGETextBox.Text = ageSelected;
                SpeListBox.Text = speSelected;
                if (sexeSelected == "M")
                {
                    HOMMEradio.Checked = true;
                    FEMMERadio.Checked = false;
                }
                else if (sexeSelected == "F")
                {
                    FEMMERadio.Checked = true;
                    HOMMEradio.Checked = false;
                }
                NOMPereTextBox.Text = nomPereSelected;
                NOMMereTextBox.Text = nomMereSelected;
            }
        }

        private void btnsuppr_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("êtes vous sur de vouloir supprimer le cheval selectionné ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int idSelected = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                GestionChevaux.SupprimerCheval(idSelected);
                
                MessageBox.Show("Le cheval numéro " + idSelected + " a bien été supprimé");
                dataGridView1.Update();
                dataGridView1.Refresh();
                dataGridView1.DataSource = null;
                List<PPEV2BO.Cheval> uneListe = new List<PPEV2BO.Cheval>();
                uneListe = GestionChevaux.GetChevaux();
                dataGridView1.DataSource = uneListe;
                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[8].Visible = false;
                this.dataGridView1.Columns[9].Visible = false;
            }
        }

        private void btnajout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("êtes vous sur de vouloir ajouter le cheval selectionné ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int idSelected = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                int age = 0;
                Int32.TryParse(AGETextBox.Text, out age);
                string sexe = "X";

                int ent = 0;
                string entSelect = NomEntComboBox.Text;
                List<PPEV2BO.Entraineur> listeEntraineur = new List<PPEV2BO.Entraineur>();
                listeEntraineur = GestionEntraineurs.GetEntraineurs();
                foreach (PPEV2BO.Entraineur Ent in listeEntraineur)
                {
                    if (Ent.Nom == entSelect)
                    {
                        ent = Ent.Id;
                    }
                }

                int pro = 0;
                string proSelect = NomProComboBox.Text;
                List<PPEV2BO.Proprietaire> listeProprietaire = new List<PPEV2BO.Proprietaire>();
                listeProprietaire = GestionProprietaires.GetProprietaire();
                foreach (PPEV2BO.Proprietaire Pro in listeProprietaire)
                {
                    if (Pro.Nom == proSelect)
                    {
                        pro = Pro.Id;
                    }
                }


                if (HOMMEradio.Checked == true)
                {
                    sexe = "M";
                }
                else if (FEMMERadio.Checked == true)
                {
                    sexe = "F";
                }

                GestionChevaux.CreerCheval(NOMTextBox.Text, CouleurTextBox.Text, age, SpeListBox.Text, NOMPereTextBox.Text, NOMMereTextBox.Text, sexe, ent, pro);
                MessageBox.Show(NOMTextBox.Text + " a bien été ajouté", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Update();
                dataGridView1.Refresh();
                dataGridView1.DataSource = null;
                List<PPEV2BO.Cheval> uneListe = new List<PPEV2BO.Cheval>();
                uneListe = GestionChevaux.GetChevaux();
                dataGridView1.DataSource = uneListe;
                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[8].Visible = false;
                this.dataGridView1.Columns[9].Visible = false;
            }
        }
    }
}
