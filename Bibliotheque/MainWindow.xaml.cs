using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Bibliotheque
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Livre livre1 = new Livre("L1", "Les aventures de Superman");
        Livre livre2 = new Livre("L2", "Tintin et le lac aux requins");
        Livre livre3 = new Livre("L3", "Des requins sur la lune");
        Livre livre4 = new Livre("L4", "Les dents du requin");
        Livre livre5 = new Livre("L5", "Naruto:L'attaque des ninjas");
        Livre livre6 = new Livre("L6", "Naruto et Baruto");
        List<Livre>listlivres = new List<Livre>();
        public MainWindow()
        {
            InitializeComponent();
            listlivres.Add(livre1);
            listlivres.Add(livre2);
            listlivres.Add(livre3);
            listlivres.Add(livre4);
            listlivres.Add(livre5);
            listlivres.Add(livre6);
        }

        private List<Livre> RechercherLivres(string recherche)
        {
            List<Livre> resultats = new List<Livre>();

            // Parcourir tous les livres
            foreach (Livre livre in listlivres)
            {
                // Vérifier si le titre contient la recherche
                if (livre.Titre.ToLower().Contains(recherche))
                {
                    resultats.Add(livre);
                }
            }

            return resultats;
        }

        private void btn_rechercher_Click(object sender, RoutedEventArgs e)
        {
            string recherche = txt_recherche.Text.ToLower();
            List<Livre> resultats = RechercherLivres(recherche);

            // Afficher les titres des livres dans le TextBox
            txt_afficher.Text = string.Join(Environment.NewLine, resultats);

        }

        private void btn_afficher_Click(object sender, RoutedEventArgs e)
        {
            
            string livresText = string.Join(Environment.NewLine, listlivres);

            // Afficher les livres dans le TextBox
            txt_afficher.Text = livresText;

        }
    }
}
