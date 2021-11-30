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

namespace Hadanky
{
    public partial class MainWindow : Window
    {
        Random random;

        List<int> hadaneHodnoty;
        int maxHodnota = 0;
        int pokus = 0;
        int hledanaHodnota;
        int hadanaHodnota;

        public MainWindow()
        {
            random = new Random();

            InitializeComponent();
        }

        private void ZacitClick(object sender, RoutedEventArgs e)
        {
            hadaneHodnoty = new List<int>();
            maxHodnota = int.Parse(maxHodnotaComboBox.Text);
            tipTextBox.Text = "";
            mensiVetsiTextBlock.Text = "Myslím si nové číslo, hádej!";
            hledanaHodnota = random.Next(0, maxHodnota + 1);
            pokus = 0;
        }

        private void TipnoutClick(object sender, RoutedEventArgs e)
        {

            if (maxHodnota == 0 || tipTextBox.Text == "")
                return;


            if (!int.TryParse(tipTextBox.Text, out hadanaHodnota))
                return;

            hadaneHodnoty.Add(hadanaHodnota);

            pokus++;

            if (hadanaHodnota > hledanaHodnota)
                mensiVetsiTextBlock.Text = "Hledané číslo je menší!";
            else if (hadanaHodnota < hledanaHodnota)
                mensiVetsiTextBlock.Text = "Hledané číslo je větší!";
            else
            {
                mensiVetsiTextBlock.Text = "";

                MessageBox.Show("UHODL JSI!" +
                                "\n\nČíslo " + hledanaHodnota + " jsi uhodl na " + pokus + ". pokus" +
                                "\n\nTvé tipy: " + string.Join(" ", hadaneHodnoty));

                maxHodnota = 0;
            }
        }
    }
}
