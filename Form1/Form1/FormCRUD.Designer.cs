namespace Form1
{
    partial class FormCRUD
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
            this.lbNom = new System.Windows.Forms.Label();
            this.lbPrenom = new System.Windows.Forms.Label();
            this.lbFormation = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.tbPrenom = new System.Windows.Forms.TextBox();
            this.tbFormation = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNom
            // 
            this.lbNom.AutoSize = true;
            this.lbNom.Location = new System.Drawing.Point(28, 43);
            this.lbNom.Name = "lbNom";
            this.lbNom.Size = new System.Drawing.Size(32, 13);
            this.lbNom.TabIndex = 0;
            this.lbNom.Text = "Nom:";
            // 
            // lbPrenom
            // 
            this.lbPrenom.AutoSize = true;
            this.lbPrenom.Location = new System.Drawing.Point(28, 89);
            this.lbPrenom.Name = "lbPrenom";
            this.lbPrenom.Size = new System.Drawing.Size(46, 13);
            this.lbPrenom.TabIndex = 0;
            this.lbPrenom.Text = "Prenom:";
            // 
            // lbFormation
            // 
            this.lbFormation.AutoSize = true;
            this.lbFormation.Location = new System.Drawing.Point(28, 140);
            this.lbFormation.Name = "lbFormation";
            this.lbFormation.Size = new System.Drawing.Size(56, 13);
            this.lbFormation.TabIndex = 0;
            this.lbFormation.Text = "Formation:";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(144, 43);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(100, 20);
            this.tbNom.TabIndex = 1;
            // 
            // tbPrenom
            // 
            this.tbPrenom.Location = new System.Drawing.Point(144, 86);
            this.tbPrenom.Name = "tbPrenom";
            this.tbPrenom.Size = new System.Drawing.Size(100, 20);
            this.tbPrenom.TabIndex = 2;
            // 
            // tbFormation
            // 
            this.tbFormation.Location = new System.Drawing.Point(144, 140);
            this.tbFormation.Name = "tbFormation";
            this.tbFormation.Size = new System.Drawing.Size(100, 20);
            this.tbFormation.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(81, 234);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Location = new System.Drawing.Point(235, 234);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 4;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // FormCRUD
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(432, 272);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbFormation);
            this.Controls.Add(this.tbPrenom);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.lbFormation);
            this.Controls.Add(this.lbPrenom);
            this.Controls.Add(this.lbNom);
            this.Name = "FormCRUD";
            this.Text = "FormCRUD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNom;
        private System.Windows.Forms.Label lbPrenom;
        private System.Windows.Forms.Label lbFormation;
        private System.Windows.Forms.TextBox tbNom;

        public System.Windows.Forms.TextBox TbNom
        {
            get { return tbNom; }
            set { tbNom = value; }
        }
        private System.Windows.Forms.TextBox tbPrenom;

        public System.Windows.Forms.TextBox TbPrenom
        {
            get { return tbPrenom; }
            set { tbPrenom = value; }
        }
        private System.Windows.Forms.TextBox tbFormation;

        public System.Windows.Forms.TextBox TbFormation
        {
            get { return tbFormation; }
            set { tbFormation = value; }
        }
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnuler;
    }
}