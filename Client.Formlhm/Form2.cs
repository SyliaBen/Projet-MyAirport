using Client.Formlhm.ServiceReferencePim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Formlhm
{
    public partial class Form2 : Form
    {
        // Formulaire principal 
        Form1 principalForm; 

        // Liste de bagages 
        List<BagageDefinition> listBags;

        // Liste Bagages info 
        List<RadioButton> listRb = new List<RadioButton>();
        List<Label> listLbIdBagage= new List<Label>();
        List<Label> listLbICompanie = new List<Label>();
        List<Label> listLbLigne = new List<Label>();
        List<Label> listLbDepart = new List<Label>();
        List<Label> listLbArrivee = new List<Label>();
        List<Label> listLbEscale = new List<Label>();
        List<Label> listLbRush = new List<Label>();
        List<Label> listLbPrioritaire = new List<Label>();

        public Form2(List<BagageDefinition> list, Form1 principalForm)
        {
            this.listBags = list;
            this.principalForm = principalForm; 

            InitializeComponent();
            this.Show();

        }
        /// <summary>
        /// Cette fonction permet d'initialiser un label dans l'interface 
        /// </summary>
        /// <param name="listLb">Liste des labels</param>
        /// <param name="lbText">Texte du label</param>
        /// <param name="xPosition">Position x du label dans la fenêtre </param>
        /// <param name="yPosition">Position y du label dans la fenêtre</param>
        /// <param name="i">Indice du label dans la liste listLb</param>
        private void initLabel(List<Label> listLb, string lbText, int xPosition, int yPosition, int i)
        {
            // Création du composant 
            listLb.Add(new Label());

             // Paramètres du composant 
             listLb[i].AutoSize = true;
             listLb[i].Location = new System.Drawing.Point(xPosition, yPosition);
             listLb[i].Size = new System.Drawing.Size(118, 25);
             listLb[i].TabIndex = 1;
             listLb[i].Text = lbText;

            // Ajout dans le panel 
            this.panelBagage.Controls.Add(listLb[i]); 

        }

        /// <summary>
        /// Cette fonction permet d'initialiser la position d'un radiobutton (bagage) dans le formulaire 
        /// </summary>
        /// <param name="i">indice du bagage (1 = premier bagage dans la liste)</param>
        /// <param name="yPosition">Position y dans l'interface</param>
        private void initRadioButton(int i, int yPosition)
        {
            // Création du composant 
            this.listRb.Add(new RadioButton()); 

            // Définition des paramètres 
            this.listRb[i].AutoSize = true;
            this.listRb[i].Location = new System.Drawing.Point(24, yPosition);
            this.listRb[i].Size = new System.Drawing.Size(153, 29);
            this.listRb[i].TabIndex = 0;
            this.listRb[i].TabStop = true;
            this.listRb[i].Text = "Bagage " + (i+1);
            this.listRb[i].UseVisualStyleBackColor = true;

            // Affichage 
            this.panelBagage.Controls.Add(this.listRb[i]);
        }
     private void Form2_Load(object sender, EventArgs e)
     {
         int yPosition = 18; 

         this.panelBagage.SuspendLayout();
         // To do  
         for (int i =0; i<this.listBags.Count; i++)
         {
            // 
            // RADIOBUTTON 
            // 
            initRadioButton(i, yPosition);

            // 
            // LABEL 
            // 
            // label IdBagage
            initLabel(this.listLbIdBagage, this.listBags[i].IdBagage.ToString(), 120, yPosition, i);
            // label Compagnie 
            initLabel(this.listLbICompanie,this.listBags[i].Compagnie, 188, yPosition, i);
            // label Ligne
            initLabel(this.listLbLigne, this.listBags[i].Ligne, 300, yPosition, i);
            // label Depart
            initLabel(this.listLbDepart, this.listBags[i].DateVol.ToString(), 360, yPosition, i);
            // label Arrivée 
            initLabel(this.listLbArrivee, this.listBags[i].Itineraire, 500, yPosition, i);
            // label Escale 
            if(this.listBags[i].EnContinuation)
                initLabel(this.listLbEscale,"OUI", 590, yPosition, i);
            else
                initLabel(this.listLbEscale, "NON", 590, yPosition, i);
            // label Rush 
            if (this.listBags[i].Rush)
                initLabel(this.listLbRush, "OUI", 665, yPosition, i);
            else
                initLabel(this.listLbRush, "NON", 665, yPosition, i);
            // label Prioritaire 
            if (this.listBags[i].Prioritaire)
                initLabel(this.listLbPrioritaire, "OUI", 730, yPosition, i);
            else
                initLabel(this.listLbPrioritaire, "NON",730, yPosition, i);  

                //Modifie la position Y 
                yPosition += 30; 
            } 

            this.panelBagage.ResumeLayout(false); 

        }

        /// <summary>
        /// Cette fonction détermine quel bagage a été selectionné par l'utilisateur. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonValider_Click(object sender, EventArgs e)
        {
            int i = 0; 
            bool found = false; 
            while(found == false)
            {
                if (this.listRb[i].Checked)
                {
                    found = true;
                    this.principalForm.definitionFinalBagage(this.listBags[i]);
                    this.Hide(); 
                }
                else
                    i++; 
            }
        }
    }
}
