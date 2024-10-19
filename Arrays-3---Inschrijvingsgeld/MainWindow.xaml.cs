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

namespace Arrays_3___Inschrijvingsgeld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            float baseAmount = 0.0f;
            int studies = studiesCombobox.SelectedIndex;
            switch (studies)
            {
                case -1: // Niks gekozen...
                    MessageBox.Show("Selecteer een opleiding!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                case 2: // "Internet of Things"
                case 4: // "Drone opleiding"
                    baseAmount = 520.80f;
                    break;
                case 3: // "Digitale vormgever"
                    baseAmount = 750.80f;
                    break;
                default: // De rest (programmeren of netwerkbeheer)
                    baseAmount = 920.80f;
                    break;
            }

            float payFactor = 1.0f; // standaard bachelor
            if (secundaryRadioButton.IsChecked == true)
            {
                payFactor = 0.7f; // 30% korting, dus 70% betalen
            }
            else if (graduaatRadioButton.IsChecked == true)
            {
                payFactor = 0.8f; // 20% korting, dus 80% betalen
            }
            else if (masterRadioButton.IsChecked == true)
            {
                payFactor = 1.1f; // 10% extra betalen (toeslag)
            }

            // Wie werkzoekend is krijgt nog eens 50% korting op het totale bedrag
            bool isJobSeeker = (jobSeekerCheckBox.IsChecked == true);
            if (isJobSeeker)
                payFactor /= 2;

            float subscription = baseAmount * payFactor;

            resultTextBox.Text =
                $"INSCHRIJVINGSBEDRAG VOOR: {nameTextBox.Text}\r\n\r\nBasisbedrag:{baseAmount:c}\r\nTe betalen: {subscription:c}";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            nameTextBox.Clear();
            resultTextBox.Clear();
            studiesCombobox.Text = string.Empty;

            // Selectievak uitschakelen
            jobSeekerCheckBox.IsChecked = false;
            // Keuzerondjes inschakelen
            bachelorRadioButton.IsChecked = true;
            // ComboBox op eerste keuze zetten
            studiesCombobox.SelectedIndex = 0;

            nameTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        // Hebben we onderstaande eventprocedures wel nodig?
        // Je kan deze eens uittesten als je wil.

        private void studiesCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void jobSeekerCheckBox_Click(object sender, RoutedEventArgs e)
        {

        }

        private void secundaryRadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void graduaatRadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bachelorRadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void masterRadioButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
