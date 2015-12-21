using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClassesConnect;
using System.Windows.Forms;

namespace Form1
{
    public static class controller
    {
        private static  LibClassesConnect.ClassMySQL vdmodel;
        #region assesseurs
        public static LibClassesConnect.ClassMySQL Vdmodel
{
  get { return controller.vdmodel; }
  set { controller.vdmodel = value; }
}
        #endregion
        public static void init()
        {
            vdmodel = new ClassMySQL();
           
        }

        public static void crud_personne(char c, string cle)
        {
            int index = 0;
            FormCRUD FC = new FormCRUD();
            if (c == 'c')
            {
                FC.TbNom.Text = String.Empty;
                FC.TbPrenom.Text = String.Empty;
                FC.TbFormation.Text = String.Empty;
            }

            if (c == 'u' || c == 'd')
            {
                string sortExpression = "IdPersonne";
                vdmodel.Dv_personne.Sort = sortExpression;

                index = vdmodel.Dv_personne.Find(cle);
                FC.TbNom.Text = vdmodel.Dv_personne[index][1].ToString();
                FC.TbPrenom.Text = vdmodel.Dv_personne[index][2].ToString();
                FC.TbFormation.Text = vdmodel.Dv_personne[index][3].ToString();

            }

            FC.ShowDialog();

            if (FC.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (c == 'c')
                {
                    System.Data.DataRowView newRow = vdmodel.Dv_personne.AddNew();
                    
                    newRow["nom"] = FC.TbNom.Text;
                    newRow["prenom"] = FC.TbPrenom.Text;
                    newRow["IdFormation"] = FC.TbFormation.Text;
                    newRow.EndEdit();
                }

                if (c == 'u')
                {
                    System.Data.DataRowView up = vdmodel.Dv_personne.AddNew();
                    vdmodel.Dv_personne[index]["nom"] = FC.TbNom.Text;
                    vdmodel.Dv_personne[index]["prenom"] = FC.TbPrenom.Text;
                    vdmodel.Dv_personne[index]["IdFormation"] = FC.TbFormation.Text;
                    up.EndEdit();
                }
                if (c == 'd')
                {
                    System.Data.DataRowView del = vdmodel.Dv_personne.AddNew();
                    vdmodel.Dv_personne[index].Delete();
                    del.EndEdit();
                }
                MessageBox.Show("OK : données enregistrés");
                FC.Dispose();
            }
            else
            {
                MessageBox.Show("Annulation : aucune donnée enregistrée");
                FC.Dispose();
            }
        }
    }
}
