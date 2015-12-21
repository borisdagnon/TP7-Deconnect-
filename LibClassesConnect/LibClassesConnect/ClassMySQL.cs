using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
namespace LibClassesConnect
{
    public class ClassMySQL
    {
        #region propriétés :
        public static MySqlConnection myConnection;

        private bool connopen = false;
        private bool errmaj = false;
        private char vaction, vtable;

        
        private ArrayList rapport = new ArrayList();
        public static bool errgrave = false;

        private bool chargement = false;


        private MySqlDataAdapter mySqlDataAdapterTP7 = new MySqlDataAdapter();
        private DataSet dataSetTP7 = new DataSet();
        private DataView dv_formation = new DataView(), dv_personne = new DataView();

        #endregion

        #region assesseurs:
        public DataView Dv_personne
        {
            get { return dv_personne; }
            set { dv_personne = value; }
        }

        public DataView Dv_formation
        {
            get { return dv_formation; }
            set { dv_formation = value; }
        }
        public bool Connopen
        {
            get { return connopen; }

        }
        public bool Chargement
        {
            get { return chargement; }

        }
        public ArrayList Rapport
        {
            get { return rapport; }
            set { rapport = value; }
        }
        public char Vaction
        {
            get { return vaction; }
            set { vaction = value; }
        }
        public char Vtable
        {
            get { return vtable; }
            set { vtable = value; }
        }
        public bool Errmaj
        {
            get { return errmaj; }
            set { errmaj = value; }
        }
        #endregion

        #region méthodes:
        public  void seconnecter()
        {
            string myConnectionString = "Database=bd_boris_bddeconnectee;Data Source=localhost;User Id=root;";
            myConnection = new MySqlConnection(myConnectionString);
            connopen = true;
            try //tentative
            {
                myConnection.Open();
            }
            catch (Exception err) //gestion des erreurs
            {
                connopen = false; 
                errgrave = true;
            }
        }

        public void sedeconnecter()
        {
            if (!connopen)
                return;
            try
            {
                myConnection.Close();
                myConnection.Dispose();
                connopen = false;
            }
            catch (Exception err)
            {
                
                errgrave = true;
            }
        }


        public void import()
        {
            if (!connopen) return;
            mySqlDataAdapterTP7.SelectCommand = new MySqlCommand("Select * from formation; select * from personne;", myConnection);
            try
            {
                dataSetTP7.Clear();
                mySqlDataAdapterTP7.Fill(dataSetTP7);
                MySqlCommand vcommand = myConnection.CreateCommand();

                vcommand.CommandText = "SELECT AUTO_INCREMENT as last_id FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'personne'";
                UInt64 der_personne = (UInt64)vcommand.ExecuteScalar();
                dataSetTP7.Tables[1].Columns[0].AutoIncrement = true;
                dataSetTP7.Tables[1].Columns[0].AutoIncrementSeed = Convert.ToInt64(der_personne);
                dataSetTP7.Tables[1].Columns[0].AutoIncrementStep = 1;

                MySqlCommand vcommand2 = myConnection.CreateCommand();

                UInt64 der_formation = (UInt64)vcommand.ExecuteScalar();
                dataSetTP7.Tables[0].Columns[0].AutoIncrement = true;
                dataSetTP7.Tables[0].Columns[0].AutoIncrementSeed = Convert.ToInt64(der_formation);
                dataSetTP7.Tables[0].Columns[0].AutoIncrementStep = 1;

                dv_formation = dataSetTP7.Tables[0].DefaultView;
                dv_personne = dataSetTP7.Tables[1].DefaultView;

                chargement = true;
            }
            catch (Exception err)
            {
                errgrave = true;
            }
        }

        private void OnRowUpdate(Object sender, MySqlRowUpdatedEventArgs args)
        {
            string msg = "";
            Int64 nb = 0;
            if (args.Status == UpdateStatus.ErrorsOccurred)
                
            {
                MySqlCommand vcommand = myConnection.CreateCommand();
                if (vtable == 'p')
                {
                    vcommand.CommandText = "Select count(*) from personne where IdPersonne='" + args.Row[0, DataRowVersion.Original] + "'";
                    nb = (Int64)vcommand.ExecuteScalar();

                }
                if (vaction == 'd')
                {
                    if (nb == 1)
                    {
                        if (vtable == 'p')
                        {
                            msg = "pour le numéro de personnes : " + args.Row[0, DataRowVersion.Original] + "impossible delete car enr modifié dans la base";

                        }
                        rapport.Add(msg);
                        errmaj = true;
                    }
                }
                if (vaction == 'u')
                {
                    if (nb == 1)
                    {
                        if (vtable == 'p')
                        {
                            msg = "pour le numéro de personne: " + args.Row[0, DataRowVersion.Original] + "impossible MAJ car modifié dans la base";

                        }
                        rapport.Add(msg);
                        errmaj = true;
                    }
                    else
                    {
                        if (vtable == 'p')
                        {
                            msg = "pour le numéro de personne : " + args.Row[0, DataRowVersion.Current] + "impossible ADD car erreur données";
                            rapport.Add(msg);
                            errmaj = true;
                        }
                    }
                }
            }
        }




        /******************************************************************************************************************************************/

        /*Méthodes pour expporter*/
        public void add_personne()
        {
            vaction = 'c';
            vtable = 'p';
            if (!connopen) return;
            //appel d'une méthode sur l'événement ajout d'un enr de la table
            //Cette série de code permet de prendre en main le OnRowUpdate pour le DataAdapter 
            mySqlDataAdapterTP7.RowUpdated += new MySqlRowUpdatedEventHandler(OnRowUpdate);
            mySqlDataAdapterTP7.InsertCommand = new MySqlCommand("INSERT INTO personne(nom,prenom,IdFormation) values (?nom,?prenom,?IdFormation)",myConnection);

            //on déclare ici les variables dont à besoin pour le commandbuilder
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?nom", MySqlDbType.Text, 65535, "nom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?prenom", MySqlDbType.Text, 65535, "prenom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?IdFomration", MySqlDbType.Int16,10,"IdFormation");
            
            //Même s'il y a une erreur de mise à jour on continu
            mySqlDataAdapterTP7.ContinueUpdateOnError = true;

            //La table concernnée est personne qui dans l'index[1] réprésente le deuxième, parce que formation est le premier [0]
            DataTable table = dataSetTP7.Tables[1];

            //on ne s'occupe que des enregistrement ajoutés en local
            mySqlDataAdapterTP7.Update(table.Select(null, null, DataViewRowState.Added));

            //désassocie la méthode sur l'évènement maj de la base
            mySqlDataAdapterTP7.RowUpdated -= new MySqlRowUpdatedEventHandler(OnRowUpdate);

        }

        public void maj_personne()
        {
            vaction = 'u';
            vtable = 'p';
            if (!connopen) return;
            //appel d'une méthode sur l'événement de mise à jour d'un enr de la table
            mySqlDataAdapterTP7.RowUpdated += new MySqlRowUpdatedEventHandler(OnRowUpdate);
            mySqlDataAdapterTP7.UpdateCommand = new MySqlCommand("UPDATE personne set nom=?nom,prenom=?prenom,IdFormation=?IdFormation where IdPersonne= ?num;", myConnection);

            //on déclare ici les variables dont à besoin pour le commandbuilder
            
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?nom", MySqlDbType.Text, 65535, "nom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?prenom", MySqlDbType.Text, 65535, "prenom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?IdFomration", MySqlDbType.Int16, 10, "IdFormation");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?num", MySqlDbType.Int16, 10, "IdPersonne");

            //Même s'il y a une erreur de mise à jour on continu
            mySqlDataAdapterTP7.ContinueUpdateOnError = true;

             //La table concernnée est personne qui dans l'index[1] réprésente le deuxième, parce que formation est le premier [0]
            DataTable table = dataSetTP7.Tables[1];

            //on ne s'occupe que des enregistrement mise à jour en local
            mySqlDataAdapterTP7.Update(table.Select(null, null, DataViewRowState.ModifiedCurrent));

            //désassocie la méthode sur l'évènement maj de la base
            mySqlDataAdapterTP7.RowUpdated -= new MySqlRowUpdatedEventHandler(OnRowUpdate);
        }


        public void supp_personne()
        {
            vaction = 'd';
            vtable = 'p';
            if (!connopen) return;
            //appel d'une méthode sur l'événement de mise à jour d'un enr de la table
            mySqlDataAdapterTP7.RowUpdated += new MySqlRowUpdatedEventHandler(OnRowUpdate);
            mySqlDataAdapterTP7.DeleteCommand = new MySqlCommand("DELETE FROM personne where IdPersonne='?num')", myConnection);

            //on déclare ici les variables dont à besoin pour le commandbuilder
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?nom", MySqlDbType.Text, 65535, "nom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?prenom", MySqlDbType.Text, 65535, "prenom");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?IdFomration", MySqlDbType.Int16, 10, "IdFormation");
            mySqlDataAdapterTP7.InsertCommand.Parameters.Add("?num", MySqlDbType.Int16, 10, "IdPersonne");
            //Même s'il y a une erreur de mise à jour on continu
            mySqlDataAdapterTP7.ContinueUpdateOnError = true;

            //La table concernnée est personne qui dans l'index[1] réprésente le deuxième, parce que formation est le premier [0]
            DataTable table = dataSetTP7.Tables[1];

            //on ne s'occupe que des enregistrement supprimés en local
            mySqlDataAdapterTP7.Update(table.Select(null, null, DataViewRowState.Deleted));

            //désassocie la méthode sur l'évènement maj de la base
            mySqlDataAdapterTP7.RowUpdated -= new MySqlRowUpdatedEventHandler(OnRowUpdate);
        }

        public void export()
        {
            if (!connopen) return;
            try
            {
                add_personne();
                maj_personne();
                supp_personne();
            }
            catch(Exception err)
            {
                errgrave = true;
            }
           
        }
        #endregion

    }
}
