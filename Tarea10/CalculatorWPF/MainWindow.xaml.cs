using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorWPF
{
    public partial class MainWindow : Window
    {
        private double totalSum = 0;
        private string inputOperator;
        private double firstNum, secondNum;
        private bool operationPerformed = false;
        private bool isResultShown = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (isResultShown)
            {
                txtDisplay.Clear();
                isResultShown = false;
            }

            Button button = (Button)sender;
            if (txtDisplay.Text == "0" || operationPerformed)
            {
                txtDisplay.Clear();
            }

            txtDisplay.Text += button.Content.ToString();
            operationPerformed = false;
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                inputOperator = button.Content.ToString();
                firstNum = double.Parse(txtDisplay.Text);
                txtDisplay.Clear();
            }
            catch (FormatException)
            {
                txtDisplay.Text = "Invalid input";
            }
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                secondNum = double.Parse(txtDisplay.Text);
                switch (inputOperator)
                {
                    case "+":
                        totalSum = firstNum + secondNum;
                        break;
                    case "-":
                        totalSum = firstNum - secondNum;
                        break;
                    case "*":
                        totalSum = firstNum * secondNum;
                        break;
                    case "/":
                        if (secondNum == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        totalSum = firstNum / secondNum;
                        break;
                    default:
                        txtDisplay.Text = "Error";
                        return;
                }

                txtDisplay.Text = totalSum.ToString();
                isResultShown = true;
            }
            catch (FormatException)
            {
                txtDisplay.Text = "Invalid input";
            }
            catch (DivideByZeroException)
            {
                txtDisplay.Text = "Cannot divide by zero";
            }
        }

        private void Btn_Dot_Click(object sender, RoutedEventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Clear();
            txtDisplay.Text = "0";
            firstNum = 0;
            secondNum = 0;
            totalSum = 0;
        }
    }
}
