using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea09
{
    public partial class FormCalculator : Form
    {
        private double totalSum = 0;
        private string inputOperator;
        private double firstNum, secondNum;
        private bool operationPerformed = false;
        private bool isResultShown = false;

        public FormCalculator()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, EventArgs e)
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

            txtDisplay.Text += button.Text;
            operationPerformed = false;
        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual y abre el formulario principal.
            FormMain mainForm = new FormMain();
            mainForm.Show();
            this.Close(); // Cierra el formulario actual
        }


        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            inputOperator = button.Text;
            firstNum = double.Parse(txtDisplay.Text);
            txtDisplay.Clear();
        }

        private void btnEquals_Click(object sender, EventArgs e)
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
                        txtDisplay.Text = "Cannot divide by zero";
                        return;
                    }
                    totalSum = firstNum / secondNum;
                    break;
                default:
                    break;
            }

            txtDisplay.Text = totalSum.ToString();
            isResultShown = true;
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            txtDisplay.Text = "0";
            firstNum = 0;
            secondNum = 0;
            totalSum = 0;
        }

        private void Btn_Backspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            if (txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }

        private void Btn_9_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Añadir el número al TextBox
                txtDisplay.Text += btn.Text; // txtScreen es tu TextBox
            }
        }

        private void Btn_8_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Añadir el número al TextBox
                txtDisplay.Text += btn.Text; // txtScreen es tu TextBox
            }
        }

        private void Btn_7_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Añadir el número al TextBox
                txtDisplay.Text += btn.Text; // txtScreen es tu TextBox
            }
        }

        private void Btn_6_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Añadir el número al TextBox
                txtDisplay.Text += btn.Text; // txtScreen es tu TextBox
            }
        }

        private void Btn_5_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Añadir el número al TextBox
                txtDisplay.Text += btn.Text; // txtScreen es tu TextBox
            }
        }

        private void Btn_4_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Añadir el número al TextBox
                txtDisplay.Text += btn.Text; // txtScreen es tu TextBox
            }
        }

        private void Btn_3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Añadir el número al TextBox
                txtDisplay.Text += btn.Text; // txtScreen es tu TextBox
            }
        }

        private void Btn_2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Añadir el número al TextBox
                txtDisplay.Text += btn.Text; // txtScreen es tu TextBox
            }
        }

        private void Btn_1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Añadir el número al TextBox
                txtDisplay.Text += btn.Text; // txtScreen es tu TextBox
            }
        }

        private void Btn_0_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Añadir el número al TextBox
                txtDisplay.Text += btn.Text; // txtScreen es tu TextBox
            }
        }

        private void Btn_Dot_Click(object sender, EventArgs e)
        {
            // Verificar que no haya ya un punto en el número
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Guardar el primer número y el operador
                firstNum = double.Parse(txtDisplay.Text);
                inputOperator = btn.Text; // El texto del botón será el operador (+, -, *, /)
                txtDisplay.Clear();   // Limpiar el TextBox para el siguiente número
            }
        }

        private void btnSubstract_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Guardar el primer número y el operador
                firstNum = double.Parse(txtDisplay.Text);
                inputOperator = btn.Text; // El texto del botón será el operador (+, -, *, /)
                txtDisplay.Clear();   // Limpiar el TextBox para el siguiente número
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Guardar el primer número y el operador
                firstNum = double.Parse(txtDisplay.Text);
                inputOperator = btn.Text; // El texto del botón será el operador (+, -, *, /)
                txtDisplay.Clear();   // Limpiar el TextBox para el siguiente número
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Guardar el primer número y el operador
                firstNum = double.Parse(txtDisplay.Text);
                inputOperator = btn.Text; // El texto del botón será el operador (+, -, *, /)
                txtDisplay.Clear();   // Limpiar el TextBox para el siguiente número
            }
        }
    }
}
