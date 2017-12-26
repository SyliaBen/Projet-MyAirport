using Client.Formlhm.ServiceReferencePim;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;

namespace Client.Formlhm
{
    public partial class Form1 : Form
    {
        // Formulaire de selection du bagage (multiples bagage avec le même code iata) 
        Form2 formBaggageSelect;



        // Bagage à afficher dans l'IHM 
        public BagageDefinition finalBag; 

        // Service ref 
        ServiceReferencePim.ServicePimClient proxy = null;

        public event PimStateEventHandler PimStateChanged;

        private PimState state = PimState.Deconnecter;
        private PimState State
        {
            get { return this.state; }
            set { OnPimStateChanged(value); }
        }

        public Form1()
        {
            InitializeComponent();
            this.PimStateChanged += PIM_PimStateChanged;
            State = PimState.AttenteBagage;
            proxy = new ServiceReferencePim.ServicePimClient();
        }

        #region PimChange
        private void OnPimStateChanged(PimState newState)
        {
            if (newState != this.state)
            {
                this.state = newState;
                if (this.PimStateChanged != null)
                {
                    PimStateChanged(this, this.state);
                }
            }
        }

        void PIM_PimStateChanged(object sender, PimState state)
        {
            switch(state)
            {
                case PimState.AffichageBagage:
                    afficherBagage(); 
                    break;
                case PimState.AttenteBagage:
                    attenteBagage(); 
                    break;
                case PimState.CreationBagage:
                    creationBagage(); 
                    break;
                case PimState.Deconnecter:
                    break;
                case PimState.SelectionBagage:
                    break; 
                    
            }
        }

        #endregion

        #region DisplayFunction

        /// <summary>
        /// Définit le bagage à afficher. 
        /// Une fois le bagage définit ->changement d'état : Mode Affichage Bagage 
        /// </summary>
        /// <param name="bag"></param>
        public void definitionFinalBagage(BagageDefinition bag)
        {
            this.finalBag = bag;
            State = PimState.AffichageBagage; 
        }

        /// <summary>
        /// Modifie le visuel du formulaire afin d'afficher les paramètres du bagage entré/selectionné 
        /// </summary>
        public void afficherBagage()
        {
            // Reset empty box 
            resetEmptyBoxColor(); 

            // Init visibilité 
            groupBoxVol.Visible = true;
            groupBoxBagage.Visible = true;

            // Compagnie 
            textBoxCompagnie.Text = finalBag.Compagnie;
            Console.WriteLine(finalBag.Compagnie); 
            textBoxCompagnie.ReadOnly = true; 
            // Ligne
            textBoxLigne.Text = finalBag.Ligne;
            textBoxLigne.ReadOnly = true;
            // Date
            textBoxJour.Visible = true; 
            textBoxJour.Text = finalBag.DateVol.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            textBoxJour.ReadOnly = true;
            // Itinéraire
            textBoxItineraire.Text = finalBag.Itineraire;
            textBoxItineraire.ReadOnly = true;
            // Prioritaire
            checkBoxPrioritaire.Enabled = false; 
            if(finalBag.Prioritaire == true)
            {
                checkBoxPrioritaire.Checked = true; 
            }
            else
            {
                checkBoxPrioritaire.Checked = false;
            }
            // Continuation
            checkBoxContinuation.Enabled = false; 
            if (finalBag.EnContinuation == true)
            {
                checkBoxContinuation.Checked = true;
            }
            else
            {
                checkBoxContinuation.Checked = false;
            }
            // Rush
            checkBoxRush.Enabled = false; 
            if (finalBag.Rush == true)
            {
                checkBoxRush.Checked = true;
            }
            else
            {
                checkBoxRush.Checked = false;
            }

            // Grise la recherche + efface le bouton 
            textBoxRecherche.Enabled = false ;
            button3.Visible = false; 

            //Bouton enregistrer bagage 
            buttonEnregistrerBagage.Visible = false;

            // Bouton réinit visible 
            buttonReinit.Visible = true;

            // Status 
            StatusEtat.Text = "Affichage de bagage"; 
 

        }

        /// <summary>
        /// textBoxRecherche + BoutonRecherche accessibles 
        /// </summary>
        public void attenteBagage()
        {
            // Hide GroupBox Vol
            groupBoxVol.Visible = false;
            // Hide GroupBox Bagage 
            groupBoxBagage.Visible = false;
           // Hide button Reinit 
            buttonReinit.Visible = false;

            // Dégriser le bouton rechercher + textBox 
            button3.Visible = true;
            textBoxRecherche.Enabled = true;

            // Status 
            StatusEtat.Text = "Attente de bagage";


        }

        /// <summary>
        /// Modification du visuel de la fenêtre : enable + clear les textbox 
        /// </summary>
        public void creationBagage()
        {
            // Visible GroupBox Vol 
            groupBoxVol.Visible = true;
            // Visible GroupBox Bagage 
            groupBoxBagage.Visible = true;
            // Visible bouton enregistrer bagage 
            buttonEnregistrerBagage.Visible = true;

            //Nettoye textBox  + writable 
            // Compagnie 
            textBoxCompagnie.Clear();
            textBoxCompagnie.ReadOnly = false;
            // Ligne
            textBoxLigne.Clear();
            textBoxLigne.ReadOnly = false;
            // Jour
            labelJour.Visible = false; 
            textBoxJour.Clear();
            textBoxJour.Visible = false;
            // Itinéraire
            textBoxItineraire.Clear();
            textBoxItineraire.ReadOnly = false;
            // Prioritaire 
            checkBoxPrioritaire.Enabled = true; 
            checkBoxPrioritaire.Checked = false;
            // Continuation 
            checkBoxContinuation.Enabled = true;
            checkBoxContinuation.Checked = false;
            //Rush 
            checkBoxRush.Enabled = true;
            checkBoxRush.Checked = false;
            // Status 
            StatusEtat.Text = "Creation de bagage";


        }

#endregion

        #region button

        /// <summary>
        /// Cette fonction permet d'appeler la fonction "GetBagageByCodeIata" via le proxy
        /// Une fois la fonction appelée, 3 états sont possibles :
        ///1) si aucun bagage n'est retournée : mode CreationBagage 
        ///2) si un bagage est retourné : mode AfficherBagage 
        ///3) si plusieurs bagages sont retournés : exception + mode AttenteBagage --> Affichage d'une nouvelle fenêtre pour selectionner le bagage souhaité
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_RechercheBagageIata(object sender, EventArgs e)
        {
            // Récupère le codeIata donné par l'utilisateur dans textBox
            string txt = textBoxRecherche.Text;

            try
            {

                var bagageReturn = proxy.GetBagageByCodeIata(txt);

                if (bagageReturn == null )
                {
                    State = PimState.CreationBagage;    
                }
                else 
                {
                    definitionFinalBagage(bagageReturn);

                }

            }
            catch (FaultException<MultipleBagagesFault> excp)
            {
                 State = PimState.AttenteBagage; 
                List <BagageDefinition> lst = excp.Detail.ListBagages.OfType<BagageDefinition>().ToList();
                // Création d'un nouveau formulaire pour selectionner le bagage parmis une liste 
                formBaggageSelect = new Form2(lst, this);
            }
            catch (CommunicationException excp)
            {
                 Console.WriteLine("Type Une erreur de communication c'est produite dans le traitement de votre demande \nType: " + excp.GetType().ToString() + "\nMessage: " + excp.Message); 

            }
            catch (Exception excp)
            {
               Console.WriteLine("Une erreur de communication c'est produite dans le traitement de votre demande \nType: " + excp.GetType().ToString() + "\nMessage: " + excp.Message);
            }



        }

        /// <summary>
        /// Cette fonction permet d'enregistrer un nouveau bagage en appelant la fonction "CreateBagage" via le proxy. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_EnregistrerBagage(object sender, EventArgs e)
        {
            // Vérifie que toutes les informations sont entrées 
            if(string.IsNullOrWhiteSpace(textBoxCompagnie.Text) || string.IsNullOrWhiteSpace(textBoxLigne.Text) || string.IsNullOrWhiteSpace(textBoxItineraire.Text))
            {
                // Remettre les labels au mode : normal
                resetEmptyBoxColor();
                // Gestion des textBox vides 
                emptyTextBox(); 
            }
            else
            {
                // Enregistrer les informations : Ajouter dans BDD 
                BagageDefinition bag = new BagageDefinition();

                bag.CodeIata = this.textBoxRecherche.Text;
                bag.Compagnie = this.textBoxCompagnie.Text;
                bag.Itineraire = this.textBoxItineraire.Text;
                bag.Rush = this.checkBoxRush.Checked;
                bag.EnContinuation= this.checkBoxContinuation.Checked;
                bag.Prioritaire = this.checkBoxPrioritaire.Checked;
                bag.Ligne = textBoxLigne.Text;

                // Crée le bagage 
                proxy.CreateBagage(bag);


                // Remettre les labels au mode : normal
                resetEmptyBoxColor();

                // Rend les groupBox Vol et Bagage invisible 
                groupBoxVol.Visible = false;
                groupBoxBagage.Visible = false;
                textBoxRecherche.Clear();

                // Change mode user 
                State = PimState.AttenteBagage; 

            }
        }

        /// <summary>
        /// Permet la réinitialisation de l'interface (mode attente de bagage) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReinit_Click(object sender, EventArgs e)
        {
            State = PimState.AttenteBagage;
        }

        #endregion

        #region label 
        /// <summary>
        /// Cette fonction permet de bloquer l'insertion de caractères autres que des chiffres dans la recherche de code_iata 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// Permet de reset la couleur des label en noir 
        /// </summary>
        public void resetEmptyBoxColor()
        {
            labelCompagnie.ForeColor = Color.Black;
            labelLigne.ForeColor = Color.Black;
            labelItineraire.ForeColor = Color.Black;
            labelChampsManquants.Visible = false;
        }
        public void emptyTextBox()
        {
            labelChampsManquants.Visible = true;

            if (string.IsNullOrWhiteSpace(textBoxCompagnie.Text))
            {
                labelCompagnie.ForeColor = Color.Red;
            }
            if (string.IsNullOrWhiteSpace(textBoxLigne.Text))
            {
                labelLigne.ForeColor = Color.Red;
            }
            if (string.IsNullOrWhiteSpace(textBoxItineraire.Text))
            {
                labelItineraire.ForeColor = Color.Red;
            }
        }

    }
    #endregion


}
