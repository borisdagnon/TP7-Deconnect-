namespace Form1
{
    partial class FormPersonne
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFormation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnajouter = new System.Windows.Forms.Button();
            this.btnmodifier = new System.Windows.Forms.Button();
            this.supprimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGV
            // 
            this.dataGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGV.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Location = new System.Drawing.Point(0, 84);
            this.dataGV.MultiSelect = false;
            this.dataGV.Name = "dataGV";
            this.dataGV.Size = new System.Drawing.Size(588, 264);
            this.dataGV.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "LISTE DES PERSONNES";
            // 
            // cbFormation
            // 
            this.cbFormation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormation.FormattingEnabled = true;
            this.cbFormation.Location = new System.Drawing.Point(177, 47);
            this.cbFormation.Name = "cbFormation";
            this.cbFormation.Size = new System.Drawing.Size(191, 21);
            this.cbFormation.TabIndex = 2;
            this.cbFormation.SelectionChangeCommitted += new System.EventHandler(this.cbFormation_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filtrer par formation";
            // 
            // btnajouter
            // 
            this.btnajouter.Location = new System.Drawing.Point(77, 391);
            this.btnajouter.Name = "btnajouter";
            this.btnajouter.Size = new System.Drawing.Size(75, 23);
            this.btnajouter.TabIndex = 4;
            this.btnajouter.Text = "ajouter";
            this.btnajouter.UseVisualStyleBackColor = true;
            this.btnajouter.Click += new System.EventHandler(this.btnajouter_Click);
            // 
            // btnmodifier
            // 
            this.btnmodifier.Location = new System.Drawing.Point(251, 391);
            this.btnmodifier.Name = "btnmodifier";
            this.btnmodifier.Size = new System.Drawing.Size(75, 23);
            this.btnmodifier.TabIndex = 5;
            this.btnmodifier.Text = "modifier";
            this.btnmodifier.UseVisualStyleBackColor = true;
            this.btnmodifier.Click += new System.EventHandler(this.btnmodifier_Click);
            // 
            // supprimer
            // 
            this.supprimer.Location = new System.Drawing.Point(404, 391);
            this.supprimer.Name = "supprimer";
            this.supprimer.Size = new System.Drawing.Size(75, 23);
            this.supprimer.TabIndex = 5;
            this.supprimer.Text = "supprimer";
            this.supprimer.UseVisualStyleBackColor = true;
            this.supprimer.Click += new System.EventHandler(this.supprimer_Click);
            // 
            // FormPersonne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 441);
            this.Controls.Add(this.supprimer);
            this.Controls.Add(this.btnmodifier);
            this.Controls.Add(this.btnajouter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFormation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGV);
            this.Name = "FormPersonne";
            this.Text = "Gestion des Personnes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFormation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnajouter;
        private System.Windows.Forms.Button btnmodifier;
        private System.Windows.Forms.Button supprimer;
    }
}