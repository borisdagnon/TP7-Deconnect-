using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gestionDesPersonnesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonne FM = new FormPersonne();
            FM.MdiParent=this;
            FM.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.Vdmodel.sedeconnecter();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            controller.init();
            controller.Vdmodel.seconnecter();
            if(!controller.Vdmodel.Connopen)
            {
                MessageBox.Show("Erreur de Connetion", "La connetion n'a pu avoir lieu",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Success Connetion", "Connetion OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                controller.Vdmodel.import();
                if ( controller.Vdmodel.Chargement==true)
                {
                    MessageBox.Show("Success Import", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gestionDesDonnéesToolStripMenuItem.Visible = true;
                }
                   

                else MessageBox.Show("Error Import", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            controller.Vdmodel.seconnecter();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gestionDesDonnéesToolStripMenuItem.Visible = false;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.Vdmodel.seconnecter();
            if(!controller.Vdmodel.Connopen)
            {
                MessageBox.Show("Erreur de Connetion", "La connetion n'a pu avoir lieu", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            else
            {
                MessageBox.Show("Success Connetion", "Connexion OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                controller.Vdmodel.export();
                MessageBox.Show("Success Export", "Données originale modifiées", MessageBoxButtons.OK, MessageBoxIcon.Information);
                controller.Vdmodel.sedeconnecter();
                MessageBox.Show("Success Deconnetion", "Déconnetion de la BDD OKAY", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        

       
    }
}
