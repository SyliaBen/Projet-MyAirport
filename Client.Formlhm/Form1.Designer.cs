namespace Client.Formlhm
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRecherche = new System.Windows.Forms.TextBox();
            this.groupBoxVol = new System.Windows.Forms.GroupBox();
            this.labelJour = new System.Windows.Forms.Label();
            this.labelLigne = new System.Windows.Forms.Label();
            this.labelCompagnie = new System.Windows.Forms.Label();
            this.textBoxJour = new System.Windows.Forms.TextBox();
            this.textBoxLigne = new System.Windows.Forms.TextBox();
            this.textBoxCompagnie = new System.Windows.Forms.TextBox();
            this.groupBoxBagage = new System.Windows.Forms.GroupBox();
            this.labelChampsManquants = new System.Windows.Forms.Label();
            this.buttonEnregistrerBagage = new System.Windows.Forms.Button();
            this.checkBoxPrioritaire = new System.Windows.Forms.CheckBox();
            this.checkBoxRush = new System.Windows.Forms.CheckBox();
            this.checkBoxContinuation = new System.Windows.Forms.CheckBox();
            this.labelItineraire = new System.Windows.Forms.Label();
            this.textBoxItineraire = new System.Windows.Forms.TextBox();
            this.buttonReinit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusEtat = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBoxVol.SuspendLayout();
            this.groupBoxBagage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxRecherche);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1417, 130);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recherche";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F);
            this.button3.Location = new System.Drawing.Point(1074, 47);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(317, 68);
            this.button3.TabIndex = 2;
            this.button3.Text = "Rechercher Bagage";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_RechercheBagageIata);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F);
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "CodeIata";
            // 
            // textBoxRecherche
            // 
            this.textBoxRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRecherche.Location = new System.Drawing.Point(171, 61);
            this.textBoxRecherche.MaxLength = 12;
            this.textBoxRecherche.Name = "textBoxRecherche";
            this.textBoxRecherche.Size = new System.Drawing.Size(874, 40);
            this.textBoxRecherche.TabIndex = 0;
            this.textBoxRecherche.Text = "005725273500";
            this.textBoxRecherche.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // groupBoxVol
            // 
            this.groupBoxVol.Controls.Add(this.labelJour);
            this.groupBoxVol.Controls.Add(this.labelLigne);
            this.groupBoxVol.Controls.Add(this.labelCompagnie);
            this.groupBoxVol.Controls.Add(this.textBoxJour);
            this.groupBoxVol.Controls.Add(this.textBoxLigne);
            this.groupBoxVol.Controls.Add(this.textBoxCompagnie);
            this.groupBoxVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.groupBoxVol.Location = new System.Drawing.Point(12, 177);
            this.groupBoxVol.Name = "groupBoxVol";
            this.groupBoxVol.Size = new System.Drawing.Size(795, 507);
            this.groupBoxVol.TabIndex = 3;
            this.groupBoxVol.TabStop = false;
            this.groupBoxVol.Text = "Vol";
            // 
            // labelJour
            // 
            this.labelJour.AutoSize = true;
            this.labelJour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F);
            this.labelJour.Location = new System.Drawing.Point(15, 269);
            this.labelJour.Name = "labelJour";
            this.labelJour.Size = new System.Drawing.Size(213, 31);
            this.labelJour.TabIndex = 7;
            this.labelJour.Text = "Date de création";
            // 
            // labelLigne
            // 
            this.labelLigne.AutoSize = true;
            this.labelLigne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F);
            this.labelLigne.Location = new System.Drawing.Point(15, 185);
            this.labelLigne.Name = "labelLigne";
            this.labelLigne.Size = new System.Drawing.Size(80, 31);
            this.labelLigne.TabIndex = 6;
            this.labelLigne.Text = "Ligne";
            // 
            // labelCompagnie
            // 
            this.labelCompagnie.AutoSize = true;
            this.labelCompagnie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F);
            this.labelCompagnie.Location = new System.Drawing.Point(15, 99);
            this.labelCompagnie.Name = "labelCompagnie";
            this.labelCompagnie.Size = new System.Drawing.Size(152, 31);
            this.labelCompagnie.TabIndex = 3;
            this.labelCompagnie.Text = "Compagnie";
            // 
            // textBoxJour
            // 
            this.textBoxJour.Location = new System.Drawing.Point(261, 264);
            this.textBoxJour.MaxLength = 12;
            this.textBoxJour.Name = "textBoxJour";
            this.textBoxJour.Size = new System.Drawing.Size(475, 40);
            this.textBoxJour.TabIndex = 5;
            // 
            // textBoxLigne
            // 
            this.textBoxLigne.Location = new System.Drawing.Point(261, 180);
            this.textBoxLigne.MaxLength = 5;
            this.textBoxLigne.Name = "textBoxLigne";
            this.textBoxLigne.Size = new System.Drawing.Size(475, 40);
            this.textBoxLigne.TabIndex = 4;
            this.textBoxLigne.Text = "076";
            // 
            // textBoxCompagnie
            // 
            this.textBoxCompagnie.Location = new System.Drawing.Point(261, 94);
            this.textBoxCompagnie.MaxLength = 3;
            this.textBoxCompagnie.Name = "textBoxCompagnie";
            this.textBoxCompagnie.Size = new System.Drawing.Size(475, 40);
            this.textBoxCompagnie.TabIndex = 3;
            this.textBoxCompagnie.Text = "EK";
            // 
            // groupBoxBagage
            // 
            this.groupBoxBagage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBagage.Controls.Add(this.labelChampsManquants);
            this.groupBoxBagage.Controls.Add(this.buttonEnregistrerBagage);
            this.groupBoxBagage.Controls.Add(this.checkBoxPrioritaire);
            this.groupBoxBagage.Controls.Add(this.checkBoxRush);
            this.groupBoxBagage.Controls.Add(this.checkBoxContinuation);
            this.groupBoxBagage.Controls.Add(this.labelItineraire);
            this.groupBoxBagage.Controls.Add(this.textBoxItineraire);
            this.groupBoxBagage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.groupBoxBagage.Location = new System.Drawing.Point(851, 177);
            this.groupBoxBagage.Name = "groupBoxBagage";
            this.groupBoxBagage.Size = new System.Drawing.Size(577, 507);
            this.groupBoxBagage.TabIndex = 4;
            this.groupBoxBagage.TabStop = false;
            this.groupBoxBagage.Text = "Bagage";
            // 
            // labelChampsManquants
            // 
            this.labelChampsManquants.AutoSize = true;
            this.labelChampsManquants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F);
            this.labelChampsManquants.ForeColor = System.Drawing.Color.Red;
            this.labelChampsManquants.Location = new System.Drawing.Point(62, 371);
            this.labelChampsManquants.Name = "labelChampsManquants";
            this.labelChampsManquants.Size = new System.Drawing.Size(446, 31);
            this.labelChampsManquants.TabIndex = 3;
            this.labelChampsManquants.Text = "Remplir le(s) champ(s) manquant(s)";
            this.labelChampsManquants.Visible = false;
            // 
            // buttonEnregistrerBagage
            // 
            this.buttonEnregistrerBagage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F);
            this.buttonEnregistrerBagage.Location = new System.Drawing.Point(133, 415);
            this.buttonEnregistrerBagage.Name = "buttonEnregistrerBagage";
            this.buttonEnregistrerBagage.Size = new System.Drawing.Size(319, 66);
            this.buttonEnregistrerBagage.TabIndex = 14;
            this.buttonEnregistrerBagage.Text = "Enregistrer Bagage";
            this.buttonEnregistrerBagage.UseVisualStyleBackColor = true;
            this.buttonEnregistrerBagage.Click += new System.EventHandler(this.button_EnregistrerBagage);
            // 
            // checkBoxPrioritaire
            // 
            this.checkBoxPrioritaire.AutoSize = true;
            this.checkBoxPrioritaire.Location = new System.Drawing.Point(216, 165);
            this.checkBoxPrioritaire.Name = "checkBoxPrioritaire";
            this.checkBoxPrioritaire.Size = new System.Drawing.Size(173, 37);
            this.checkBoxPrioritaire.TabIndex = 13;
            this.checkBoxPrioritaire.Text = "Prioritaire";
            this.checkBoxPrioritaire.UseVisualStyleBackColor = true;
            // 
            // checkBoxRush
            // 
            this.checkBoxRush.AutoSize = true;
            this.checkBoxRush.Location = new System.Drawing.Point(216, 289);
            this.checkBoxRush.Name = "checkBoxRush";
            this.checkBoxRush.Size = new System.Drawing.Size(115, 37);
            this.checkBoxRush.TabIndex = 12;
            this.checkBoxRush.Text = "Rush";
            this.checkBoxRush.UseVisualStyleBackColor = true;
            // 
            // checkBoxContinuation
            // 
            this.checkBoxContinuation.AutoSize = true;
            this.checkBoxContinuation.Location = new System.Drawing.Point(216, 226);
            this.checkBoxContinuation.Name = "checkBoxContinuation";
            this.checkBoxContinuation.Size = new System.Drawing.Size(210, 37);
            this.checkBoxContinuation.TabIndex = 11;
            this.checkBoxContinuation.Text = "Continuation";
            this.checkBoxContinuation.UseVisualStyleBackColor = true;
            // 
            // labelItineraire
            // 
            this.labelItineraire.AutoSize = true;
            this.labelItineraire.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F);
            this.labelItineraire.Location = new System.Drawing.Point(21, 99);
            this.labelItineraire.Name = "labelItineraire";
            this.labelItineraire.Size = new System.Drawing.Size(120, 31);
            this.labelItineraire.TabIndex = 8;
            this.labelItineraire.Text = "Itinéraire";
            // 
            // textBoxItineraire
            // 
            this.textBoxItineraire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItineraire.Location = new System.Drawing.Point(187, 94);
            this.textBoxItineraire.MaxLength = 3;
            this.textBoxItineraire.Name = "textBoxItineraire";
            this.textBoxItineraire.Size = new System.Drawing.Size(285, 40);
            this.textBoxItineraire.TabIndex = 8;
            this.textBoxItineraire.Text = "DXB";
            // 
            // buttonReinit
            // 
            this.buttonReinit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReinit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F);
            this.buttonReinit.Location = new System.Drawing.Point(13, 708);
            this.buttonReinit.Name = "buttonReinit";
            this.buttonReinit.Size = new System.Drawing.Size(1416, 59);
            this.buttonReinit.TabIndex = 3;
            this.buttonReinit.Text = "Réinitialiser";
            this.buttonReinit.UseVisualStyleBackColor = true;
            this.buttonReinit.Click += new System.EventHandler(this.buttonReinit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.StatusEtat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 780);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1441, 37);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 32);
            this.toolStripStatusLabel1.Text = "Etat";
            // 
            // StatusEtat
            // 
            this.StatusEtat.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StatusEtat.Name = "StatusEtat";
            this.StatusEtat.Size = new System.Drawing.Size(67, 32);
            this.StatusEtat.Text = "Arret";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 817);
            this.Controls.Add(this.buttonReinit);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxBagage);
            this.Controls.Add(this.groupBoxVol);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1467, 1000);
            this.MinimumSize = new System.Drawing.Size(1467, 830);
            this.Name = "Form1";
            this.Text = "Bagage";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxVol.ResumeLayout(false);
            this.groupBoxVol.PerformLayout();
            this.groupBoxBagage.ResumeLayout(false);
            this.groupBoxBagage.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxVol;
        private System.Windows.Forms.GroupBox groupBoxBagage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRecherche;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelCompagnie;
        private System.Windows.Forms.TextBox textBoxJour;
        private System.Windows.Forms.TextBox textBoxLigne;
        private System.Windows.Forms.TextBox textBoxCompagnie;
        private System.Windows.Forms.Label labelLigne;
        private System.Windows.Forms.Label labelJour;
        private System.Windows.Forms.Label labelItineraire;
        private System.Windows.Forms.TextBox textBoxItineraire;
        private System.Windows.Forms.CheckBox checkBoxRush;
        private System.Windows.Forms.CheckBox checkBoxContinuation;
        private System.Windows.Forms.CheckBox checkBoxPrioritaire;
        private System.Windows.Forms.Button buttonEnregistrerBagage;
        private System.Windows.Forms.Label labelChampsManquants;
        private System.Windows.Forms.Button buttonReinit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatusEtat;
    }
}

