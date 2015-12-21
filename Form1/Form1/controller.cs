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
            else

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

                   
                    try
                    {
                        newRow["IdFormation"] = Convert.ToInt32( FC.TbFormation.Text);
                        
                    }
                    catch
                    {
                        MessageBox.Show("Veuillez insérer un nombre ou un chiffre");
                        FC.ShowDialog();
                        newRow.CancelEdit();
                    }
                    newRow.EndEdit();
                   
                }

                if (c == 'u')
                {
                    System.Data.DataRowView up = vdmodel.Dv_personne.AddNew();
                    vdmodel.Dv_personne[index]["nom"] = FC.TbNom.Text;
                    vdmodel.Dv_personne[index]["prenom"] = FC.TbPrenom.Text;
                    try
                    {
                        vdmodel.Dv_personne[index]["IdFormation"] = Convert.ToInt32( FC.TbFormation.Text);
                        
                    }
                    catch
                    {
                        MessageBox.Show("Veuillez insérer un nombre ou un chiffre");
                        FC.ShowDialog();
                        up.CancelEdit();
                    }
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


        /*-------------------------------------------------------------------------------------------------------------------------------------*/

       

        public static void crud_formation(char c , string cle)
    {
        int index = 0;
        FormCRUDFormation FCM = new FormCRUDFormation();
            if(c=='c')
            {
                Int32 n;
                FCM.TbIntitule.Text = String.Empty;
                FCM.TbNbAnnee.Text = String.Empty;
               
            }
            else

            if(c=='u'|| c=='d')
            {
                
                string sortExpression = "IdFormation";
                vdmodel.Dv_formation.Sort = sortExpression;
                index = vdmodel.Dv_formation.Find(cle);
                FCM.TbIntitule.Text = vdmodel.Dv_formation[index][1].ToString();
                FCM.TbNbAnnee.Text = vdmodel.Dv_formation[index][2].ToString();
               
                    FCM.ShowDialog();
                
                
            }

            FCM.ShowDialog();

            if (FCM.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                

                        if (c == 'c')
                        {
                            System.Data.DataRowView newRow = vdmodel.Dv_formation.AddNew();
                            newRow["Intitule"] = FCM.TbIntitule.Text;
                            try
                            {
                                newRow["NbAnnee"] = Convert.ToInt32( FCM.TbNbAnnee.Text);
                            }
                            catch
                            {
                                MessageBox.Show("Veuillez insérer un nombre ou un chiffre");
                                newRow.CancelEdit();
                            }
                            newRow.EndEdit();
                         
                        }

                        if (c == 'u')
                        {
                            System.Data.DataRowView up = vdmodel.Dv_formation.AddNew();
                            vdmodel.Dv_formation[index]["Intitule"] = FCM.TbIntitule.Text;
                            try
                            {
                                vdmodel.Dv_formation[index]["NbAnnee"] = FCM.TbNbAnnee.ToString();
                            }
                            catch
                            {
                                MessageBox.Show("Veuillez insérer un nombre ou un chiffre");
                                up.CancelEdit();
                            }
                            
                            up.EndEdit();
                        }
                        if (c == 'd')
                        {
                            System.Data.DataRowView del = vdmodel.Dv_formation.AddNew();
                            vdmodel.Dv_formation[index].Delete();
                            del.EndEdit();
                        }
                        MessageBox.Show("OK : données enregistrés");
                        FCM.Dispose();
                    }
            
    }

    }
}
