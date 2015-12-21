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
    public partial class FormPersonne : Form
    {
        private BindingSource bindingSource1 = new BindingSource();

        public void chargedgv()
        {
            List<KeyValuePair<int, string>> FList = new List<KeyValuePair<int, string>>();
            FList.Add(new KeyValuePair<int, string>(0, "Toutes les formations"));
            cbFormation.Items.Add("Toutes les formations");

            for (int i = 0; i < controller.Vdmodel.Dv_formation.ToTable().Rows.Count; i++)
            {
                FList.Add(new KeyValuePair<int,
                string>((int)controller.Vdmodel.Dv_formation.ToTable().Rows[i][0],
                controller.Vdmodel.Dv_formation.ToTable().Rows[i][1].ToString()));
            }
            // on lie la liste à la comboBox
            cbFormation.DataSource = FList;
            cbFormation.ValueMember = "Key";
            cbFormation.DisplayMember = "Value";
            cbFormation.Text = cbFormation.Items[0].ToString();
            cbFormation.DropDownStyle = ComboBoxStyle.DropDownList;


            bindingSource1.DataSource = controller.Vdmodel.Dv_personne;
            dataGV.DataSource = bindingSource1;

            dataGV.Columns[0].Visible = false;

            int vwidth = dataGV.RowHeadersWidth;
            for(int i =0; i<dataGV.Columns.Count; i++)
            {
                if(dataGV.Columns[i].Visible)
                
                    vwidth = vwidth + dataGV.Columns[i].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, false);

                
            }
            if(dataGV.ScrollBars.Equals(ScrollBars.Both)| dataGV.ScrollBars.Equals(ScrollBars.Vertical))
            {
                dataGV.Width += 20;
            }
            dataGV.Refresh();

            
        }

        public void changefiltre()
        {
            string num = cbFormation.SelectedValue.ToString();
            int n = Convert.ToInt32(num);
            if (n == 0)
                controller.Vdmodel.Dv_personne.RowFilter = "";
            else
            {
                string Filter = "IdFormation = '" + n + "'";
                controller.Vdmodel.Dv_personne.RowFilter = Filter;
            }
            dataGV.Refresh();
        }
        public FormPersonne()
        {
           
            InitializeComponent(); 
            chargedgv();
            dataGV.AllowUserToAddRows = false;
            dataGV.AllowUserToDeleteRows = false;
            dataGV.SelectionMode= DataGridViewSelectionMode.FullRowSelect;

           
            
        }

       
        
        private void cbFormation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            changefiltre();
        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
           
            if (dataGV.SelectedRows.Count == 1)
            {
                controller.crud_personne('c', dataGV.Rows[dataGV.SelectedRows[0].Index].Cells[0].Value.ToString());

                bindingSource1.MoveLast();
                bindingSource1.MoveFirst();
                dataGV.Refresh();
            }
           
        }

        private void btnmodifier_Click(object sender, EventArgs e)
        {
            if (dataGV.SelectedRows.Count == 1)
            {
                controller.crud_personne('u', dataGV.Rows[dataGV.SelectedRows[0].Index].Cells[0].Value.ToString());
                bindingSource1.MoveLast();
                bindingSource1.MoveFirst();
                dataGV.Refresh();
            }
            else
            {
                MessageBox.Show("Selectionner une ligne à modifier");
            }
        }
        

        private void supprimer_Click(object sender, EventArgs e)
        {
            if (dataGV.SelectedRows.Count == 1)
            {
                string i;
                i = "Stéphanie";
                controller.crud_personne('d', dataGV.Rows[dataGV.SelectedRows[0].Index].Cells[0].Value.ToString());
                bindingSource1.MoveLast();
                bindingSource1.MoveFirst();
                dataGV.Refresh();
            }
            else
            {
                MessageBox.Show("Selectionner une ligne à supprimer");
            }
        }

       

        

       
           

        
    }
}
