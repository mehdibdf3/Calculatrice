using System;
using System.Windows;
using System.Windows.Controls;


namespace calculatriceexam1
{
    
    public partial class MainWindow : Window
    {
        // Déclaration des variables 
        private double lastNumber, result;
        private string selectedOperator;

        // Constructeur de la classe MainWindow
        public MainWindow()
        {
            InitializeComponent(); // Initialisation des composants 
        }

        // Gestionnaire d'evenements pour les clics pour les button de numero
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender is Button button) 
            {
                selectedValue = int.Parse(button.Content.ToString()); 
            }

            
            if (Display.Text == "0")
            {
                Display.Text = selectedValue.ToString();
            }
            else
            {
                Display.Text += selectedValue.ToString();
            }
        }

        // Gestionnaire d'evenements pour les clics sur les boutons operator
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button) 
            {
                selectedOperator = button.Content.ToString(); 
                lastNumber = double.Parse(Display.Text); 
                Display.Text = "0";
            }
        }

        // Gestionnaire d'evenements pour le clic sur le bouton =
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber = double.Parse(Display.Text); 
            // Calcule du resultat 
            switch (selectedOperator)
            {
                case "+":
                    Display.Text = (lastNumber + newNumber).ToString();
                    break;
                case "-":
                    Display.Text = (lastNumber - newNumber).ToString();
                    break;
                case "*":
                    Display.Text = (lastNumber * newNumber).ToString();
                    break;
                case "/":
                    if (newNumber == 0)
                    {
                        MessageBox.Show("La division par zéro n'est pas autorisée.");
                    }
                    else
                    {
                        Display.Text = (lastNumber / newNumber).ToString();
                    }
                    break;
                default:
                    break;
            }
        }

        // Gestionnaire d'evenements pour le clic sur le bouton AC
        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0"; 
        }

        // Gestionnaire d'evenements pour le clic sur le bouton +/- 
        private void PlusMinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Display.Text, out double number)) 
            {
                number = number * -1; 
                Display.Text = number.ToString(); 
            }
        }

        // Gestionnaire d'evenements pour le clic sur le bouton % 
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Display.Text, out double number))
            {
                number = number / 100; 
                Display.Text = number.ToString(); 
            }
        }

        // Gestionnaire d'evenements pour les clics sur les boutons de fonctions speciales 
        private void SpecialFunctionButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button) 
            {
                switch (button.Content.ToString())
                {
                    case "!":
                        if (int.TryParse(Display.Text, out int number)) 
                        {
                            Display.Text = CalculateFactorial(number).ToString(); 
                        }
                        break;
                    case "1/x":
                        if (double.TryParse(Display.Text, out double numberInv) && numberInv != 0)
                        {
                            Display.Text = (1 / numberInv).ToString(); 
                        }
                        break;
                    case "X²":
                        if (double.TryParse(Display.Text, out double numberSqr))
                        {
                            Display.Text = (numberSqr * numberSqr).ToString(); 
                        }
                        break;
                    case "√":
                        if (double.TryParse(Display.Text, out double numberSqrt) && numberSqrt >= 0)
                        {
                            Display.Text = Math.Sqrt(numberSqrt).ToString(); 
                        }
                        break;
                }
            }
        }

        // Fonction pour calculer le factoriel d'un nombre
        private long CalculateFactorial(int number)
        {
            if (number == 0 || number == 1)
            {
                return 1; 
            }
            long result = 1;
            for (int i = 2; i <= number; i++) 
            {
                result *= i;
            }
            return result; 
        }

        // Gestionnaire d'evenements pour le clic sur le bouton Close
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); 
        }
    }
}
