using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Collections.Specialized.BitVector32;

namespace BilletDeTrain
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //label.Content = ((ComboBoxItem)comboBox.SelectedItem).Content;
        }

        private void btn_quitter_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir quitter l'application ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btn_calculer_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer le prix de base saisi par l'utilisateur
            if (!decimal.TryParse(txt_prix.Text, out decimal prixBase))
            {
                MessageBox.Show("Veuillez entrer un prix de base valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Calculer le prix hors taxe
            decimal prixHorsTaxe = prixBase;

            // Calculer le montant de la taxe (20%)
            decimal montantTaxe = prixBase * 0.2m;

            // Calculer le prix toutes taxes comprises
            decimal prixTTC = prixBase + montantTaxe;

            // Appliquer les réductions selon les cartes sélectionnées
            if (rb_deuxiemeClasse.IsChecked == true)
            {
                // Pas de réduction pour la deuxième classe
            }
            else if (rb_premierClasse.IsChecked == true)
            {
                // Ajouter 20% au prix de base pour la première classe
                prixTTC += prixBase * 0.2m;
            }

            if (comboBox.Text == "Carte jeune")
            {
                // Réduction de 40% pour la carte jeune
                prixTTC -= prixTTC * 0.4m;
            }
            else if (comboBox.Text == "Carte adulte")
            {
                // Réduction de 30% pour la carte adulte
                prixTTC -= prixTTC * 0.3m;
            }
            else if (comboBox.Text == "Carte famille")
            {
                // Réduction de 50% pour la carte famille
                prixTTC -= prixTTC * 0.5m;
            }

            // Afficher les résultats
            txt_prixHT.Text = prixHorsTaxe.ToString("0.00");
            txt_montant_taxe.Text = montantTaxe.ToString("0.00");
            txt_montantTTC.Text = prixTTC.ToString("0.00");

        }

        private void btn_reinitialiser_Click(object sender, RoutedEventArgs e)
        {
            txt_prix.Text = string.Empty;
            comboBox.Text = string.Empty;
            txt_prixHT.Text= string.Empty;
            txt_montant_taxe.Text= string.Empty;
            txt_montantTTC.Text= string.Empty;
            if (rb_deuxiemeClasse.IsChecked == true)
            {
                rb_deuxiemeClasse.IsChecked = false;
            }
            else
                rb_premierClasse.IsChecked = false;
        }
    }
}
