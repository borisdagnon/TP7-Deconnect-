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
    public partial class FormFormation : Form
    {
        private BindingSource BS = new BindingSource();
        public FormFormation()
        {
            InitializeComponent();
            remplirDGV();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void remplirDGV()
        {
            BS.DataSource = controller.Vdmodel.Dv_formation;
            dataGridView1.DataSource = BS;
            dataGridView1.Columns[0].Visible = false;

            int vwidth = dataGridView1.RowHeadersWidth;
            for(int i=0; i<dataGridView1.Columns.Count;i++)
            {
                if (dataGridView1.Columns[i].Visible)
                    vwidth = vwidth + dataGridView1.Columns[i].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells,false);
            }
            if(dataGridView1.ScrollBars.Equals(ScrollBars.Both)| dataGridView1.ScrollBars.Equals(ScrollBars.Vertical))
            {
                dataGridView1.Width+=20;
            }
            dataGridView1.Refresh();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==1)
            {
                controller.crud_formation('c', dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
                BS.MoveLast();
                BS.MoveFirst();
                dataGridView1.Refresh();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==1)
            {
                controller.crud_formation('u', dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
                BS.MoveLast();
                BS.MoveFirst();
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Sélectionnez une une à modifier");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==1)
            {
            
            controller.crud_formation('d',dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            BS.MoveFirst();
            BS.MoveLast();
            dataGridView1.Refresh();
        }
        else
    {
        MessageBox.Show("Sélectionnez une ligne à supprimer");
    }
        }

        


        
    }
}
