﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Calculator
{
    public partial class Form1 : Form
    {
        double totalSum = 0;
        string inputvalue;
        bool operationCondition = false;
        int counter = 0;
        double lastInputNumber;
        double beforeLastInputNumber;
        string number;
        bool a = true;
        // Declaración de las listas
        private List<string> historyList = new List<string>();
        private List<string> memoryList = new List<string>();
        private bool showingHistory = true; // Para alternar entre historial y memoria
        ///
        int num_of_input_operation = 0;
        double firstNum;
        double total;// used for sum of first "x (inputOperation) y = total

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            // Establece el foco inicial en el TextBox de entrada
            textBox_OutPutValue.Focus();
            textBox_OutPutValue.Select(textBox_OutPutValue.Text.Length, 0);

            // Hace que el TextBox sea de solo lectura para evitar entrada directa
            textBox_OutPutValue.ReadOnly = true;
        }
        Point lastPoint;
        //1. x (input operation) y = z for the first time -> onother operation without equals// calculate the current sum without "Btn_Equals_OnClick" method
        private double Calculation(string inputvalue, double firstNum, double secondNum)
        {
            double sum = 0;
            switch (inputvalue)
            {
                case "+":
                    sum = firstNum + secondNum;
                    break;

                case "-":
                    sum = firstNum - secondNum;
                    break;

                case "x":
                    sum = firstNum * secondNum;
                    break;

                case "/":
                    if (secondNum == 0)
                    {
                        ShowError("Cannot divide by zero");
                        return 0; // Devuelve 0 o el valor que consideres adecuado
                    }
                    sum = firstNum / secondNum;
                    break;
                case "√":
                    if (totalSum < 0)
                    { 
                        operationCondition = false;
                    }
                    else
                    {
                        sum = Math.Sqrt(totalSum);
                        textBox_OutPutValue.Text = sum.ToString();
                    }
                    break;

                default:
                    Lbl_1.Text = "Invalid argument!";
                    break;
            }
            return sum;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            a = true;
            if (textBox_OutPutValue.Text == "0" || operationCondition)
            {
                textBox_OutPutValue.Clear();
            }

            operationCondition = false;

            if (((Button)sender).Text == ".")
            {
                if (!textBox_OutPutValue.Text.Contains("."))
                {
                    textBox_OutPutValue.Text += ((Button)sender).Text;
                }
            }
            else
            {
                if (counter != 0)
                {
                    textBox_OutPutValue.Text = ((Button)sender).Text;
                    counter = 0;
                }
                else textBox_OutPutValue.Text += ((Button)sender).Text;
            }

            lastInputNumber = double.Parse(textBox_OutPutValue.Text);

            number = ((Button)sender).Text;
            ///1.
            if (num_of_input_operation == 0)
            {
                firstNum = double.Parse(textBox_OutPutValue.Text);
            }
            if (num_of_input_operation >= 1)// the condition is ">=1" in order to calculate the following operation/operations without the method "Btn_Equals_OnClick" !
            {
                total = Calculation(inputvalue, firstNum, lastInputNumber);
            }
        }

        private void Btn_Clear(object sender, EventArgs e)
        {
            textBox_OutPutValue.Font = new Font("Nirmala UI", 24, FontStyle.Bold);
            Lbl_1.Font = new Font("Nirmala UI", 12, FontStyle.Bold);
            textBox_OutPutValue.Text = "0";
            Lbl_1.Text = null;
            counter = 0;
            a = true;
            inputvalue = null;
            beforeLastInputNumber = 0;///
            num_of_input_operation = 0;///
            total = 0;
            //
            number = null;
            operationCondition = false;
            firstNum = 0;
        }

        // Método auxiliar para mostrar errores
        private void ShowError(string errorMessage)
        {
            textBox_OutPutValue.Text = "Error";
            Lbl_1.Text = errorMessage;
            AddToHistory("Error", errorMessage);
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            a = true;
            counter = 0;
            inputvalue = ((Button)sender).Text;//input operation
            totalSum = double.Parse(textBox_OutPutValue.Text);// current value
            operationCondition = true;
            //1. check for "x + y * z must give t."
            if (num_of_input_operation >= 1)
            {
                textBox_OutPutValue.Text = total.ToString();
                firstNum = total;
                totalSum = total;
            }

            if (((Button)sender).Text != "√")
            {
                Lbl_1.Text = $"{textBox_OutPutValue.Text} {inputvalue} ";
            }
            else // √
            {
                Lbl_1.Text = $"{inputvalue}({totalSum.ToString()})";
            }

            num_of_input_operation++;
            beforeLastInputNumber = double.Parse(textBox_OutPutValue.Text);// for example: x + y... ,  beforeLastInputNumber = x

            if (textBox_OutPutValue.Text.Length >= 14)
            {
                textBox_OutPutValue.Font = new Font("Nirmala UI", 17, FontStyle.Bold);
                Lbl_1.Font = new Font("Nirmala UI", 9, FontStyle.Bold);
            }
        }


        private void Btn_Equals_OnClick(object sender, EventArgs e)
        {
            if ((textBox_OutPutValue.Text != "0" && a && (!operationCondition || (operationCondition && inputvalue == "√") || (operationCondition && num_of_input_operation > 0))) || (textBox_OutPutValue.Text == "0" && a && !operationCondition /*&& counter != 0*/))
            {

                if (operationCondition)
                {
                    if (num_of_input_operation > 0)
                    {
                        Lbl_1.Text += $"{textBox_OutPutValue.Text} =";
                        operationCondition = false;
                    }
                    else Lbl_1.Text += " =";
                }
                else
                {
                    if (counter == 0)
                    {
                        Lbl_1.Text += $"{textBox_OutPutValue.Text} =";
                    }
                    else
                    {
                        if (inputvalue == "√")
                        {
                            Lbl_1.Text = $"{inputvalue}({totalSum.ToString()}) =";
                        }
                        else
                        {
                            Lbl_1.Text = $"{textBox_OutPutValue.Text} {inputvalue} {lastInputNumber} =";
                        }
                    }
                }

                switch (inputvalue)
                {
                    case "+":
                        if (counter == 0)
                        {
                            lastInputNumber = double.Parse(textBox_OutPutValue.Text);//1
                            textBox_OutPutValue.Text = (totalSum + double.Parse(textBox_OutPutValue.Text)).ToString();
                        }
                        else
                        {
                            textBox_OutPutValue.Text = (lastInputNumber + double.Parse(textBox_OutPutValue.Text)).ToString();
                        }
                        a = true;
                        break;

                    case "-":
                        if (counter == 0)
                        {
                            lastInputNumber = double.Parse(textBox_OutPutValue.Text);//1
                            textBox_OutPutValue.Text = (totalSum - double.Parse(textBox_OutPutValue.Text)).ToString();
                        }
                        else
                        {
                            textBox_OutPutValue.Text = (double.Parse(textBox_OutPutValue.Text) - lastInputNumber).ToString();
                        }
                        a = true;
                        break;

                    case "x":
                        if (counter == 0)
                        {
                            lastInputNumber = double.Parse(textBox_OutPutValue.Text);//1
                            textBox_OutPutValue.Text = (totalSum * double.Parse(textBox_OutPutValue.Text)).ToString();
                        }
                        else
                        {
                            textBox_OutPutValue.Text = (double.Parse(textBox_OutPutValue.Text) * lastInputNumber).ToString();
                        }
                        a = true;
                        break;

                    case "/":
                        if (counter == 0)
                        {
                            if (!operationCondition && num_of_input_operation > 0)
                            {
                                lastInputNumber = double.Parse(textBox_OutPutValue.Text);
                                textBox_OutPutValue.Text = (totalSum / double.Parse(textBox_OutPutValue.Text)).ToString();
                                Console.WriteLine("123456789Hello World");
                            }
                        }
                        else
                        {
                            textBox_OutPutValue.Text = (double.Parse(textBox_OutPutValue.Text) / lastInputNumber).ToString();
                        }
                        a = true;
                        break;

                    case "√":
                        if (totalSum < 0)
                        {
                            ShowError("Cannot evalute a negative");
                            operationCondition = false;
                        }
                        else
                        {
                            textBox_OutPutValue.Text = Math.Sqrt(totalSum).ToString();
                            operationCondition = false;
                        }
                        break;

                    default:
                        Lbl_1.Text = "Invalid argument!";
                        break;
                }
                counter++;
            }
            else
            {
                if (inputvalue != "√")
                {
                    if (number == null || inputvalue == null)//looks for case: 0 -> =
                    {
                        Lbl_1.Text = "0 =";
                    }
                    else
                    {
                        Lbl_1.Text = $"{totalSum.ToString()} {inputvalue} 0 =";
                    }
                }
                else // √
                {
                    Lbl_1.Text = $"{inputvalue}({totalSum.ToString()}) =";
                }

                textBox_OutPutValue.Text = "0";
                if (counter != 0) a = false;
            }

            if (textBox_OutPutValue.Text.Length >= 14)
            {
                textBox_OutPutValue.Font = new Font("Nirmala UI", 17, FontStyle.Bold);
                Lbl_1.Font = new Font("Nirmala UI", 9, FontStyle.Bold);
            }
            num_of_input_operation = 0;
            listBox1.Items.Add(Lbl_1.Text + textBox_OutPutValue.Text); // Añadir
            historyList.Add(Lbl_1.Text + textBox_OutPutValue.Text);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Números
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                string number = (e.KeyCode >= Keys.NumPad0) ? (e.KeyCode - Keys.NumPad0).ToString() : (e.KeyCode - Keys.D0).ToString();
                SimulateButtonClick(number);
            }
            // Punto decimal
            else if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                SimulateButtonClick(".");
            }
            // Operaciones
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                SimulateButtonClick("+");
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                SimulateButtonClick("-");
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                SimulateButtonClick("x");
            }
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion)
            {
                SimulateButtonClick("/");
            }
            // Igual (Enter)
            else if (e.KeyCode == Keys.Enter)
            {
                Btn_Equals_OnClick(sender, e);
                //listBox1.Items.Add(Lbl_1.Text + textBox_OutPutValue.Text); // Añadir al ListBox
            }
            // Borrar último dígito (Backspace o Delete)
            else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                DeleteLastDigit();
            }
            // Nuevas teclas para las funciones trigonométricas y logarítmicas
            else if (e.KeyCode == Keys.S)
            {
                Btn_Sen_Click(sender, e);
            }
            else if (e.KeyCode == Keys.C)
            {
                Btn_Cos_Click(sender, e);
            }
            else if (e.KeyCode == Keys.T)
            {
                Btn_Tan_Click(sender, e);
            }
            else if (e.KeyCode == Keys.L)
            {
                Btn_Log_Click(sender, e);
            }
            else if (e.KeyCode == Keys.N)
            {
                Btn_Ln_Click(sender, e);
            }
            // Nuevas teclas para Pi y cambio de signo
            else if (e.KeyCode == Keys.P)
            {
                Btn_Pi_Click(sender, e);
            }
            // Previene que la tecla presionada cambie el foco o realice acciones no deseadas
            e.Handled = true;
            e.SuppressKeyPress = true;

            // Mantiene el foco en el TextBox después de cada operación
            textBox_OutPutValue.Focus();
            textBox_OutPutValue.Select(textBox_OutPutValue.Text.Length, 0);
        }

        private void SimulateButtonClick(string buttonText)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Text == buttonText)
                {
                    if (buttonText == "=")
                    {
                        Btn_Equals_OnClick(button, new EventArgs());
                    }
                    else
                    {
                        button.PerformClick();
                    }
                    return;
                }
            }
        }

        private void DeleteLastDigit()
        {
            if (textBox_OutPutValue.Text.Length > 0)
            {
                textBox_OutPutValue.Text = textBox_OutPutValue.Text.Substring(0, textBox_OutPutValue.Text.Length - 1);
                if (textBox_OutPutValue.Text.Length == 0 || textBox_OutPutValue.Text == "-")
                {
                    textBox_OutPutValue.Text = "0";
                    operationCondition = false;
                }
                lastInputNumber = double.Parse(textBox_OutPutValue.Text);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Método para añadir al historial y actualizar el ListBox
        private void AddToHistory(string operation, string result)
        {
            string entry = $"{operation} = {result}";
            historyList.Add(entry);

            if (showingHistory)
            {
                listBox1.Items.Add(entry);
            }
        }

        // Modificar los botones de memoria (M+, M-, MR, MC) para actualizar la lista de memoria
        private void button20_Click(object sender, EventArgs e) // M+
        {
            double currentValue = double.Parse(textBox_OutPutValue.Text);
            double memoryValue = Convert.ToDouble(textBox_OutPutValue.Tag ?? "0");
            memoryValue += currentValue;
            textBox_OutPutValue.Tag = memoryValue;

            memoryList.Add($"{memoryValue}");
        }

        private void button21_Click(object sender, EventArgs e) // M-
        {
            double currentValue = double.Parse(textBox_OutPutValue.Text);
            double memoryValue = Convert.ToDouble(textBox_OutPutValue.Tag ?? "0");
            memoryValue -= currentValue;
            textBox_OutPutValue.Tag = memoryValue;

            memoryList.Add($"{memoryValue}");
        }

        private void button22_Click(object sender, EventArgs e) // MR
        {
            textBox_OutPutValue.Text = (textBox_OutPutValue.Tag ?? "0").ToString();
            memoryList.Add($"{textBox_OutPutValue.Text}");
        }

        private void button19_Click(object sender, EventArgs e) // MC
        {
            textBox_OutPutValue.Tag = "0";
            memoryList.Add("Memory cleared.");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Botón de History: muestra el historial
        private void button3_Click(object sender, EventArgs e)
        {
            showingHistory = true;
            listBox1.Items.Clear();
            foreach (string entry in historyList)
            {
                listBox1.Items.Add(entry);
            }
        }

        // Botón de Memory: muestra la memoria
        private void button4_Click(object sender, EventArgs e)
        {
            showingHistory = false;
            listBox1.Items.Clear();
            foreach (string entry in memoryList)
            {
                listBox1.Items.Add(entry);
            }
        }

        private void Btn_Backspace_Click_Click(object sender, EventArgs e)
        {
            DeleteLastDigit();
        }

        private void Btn_Square_Click_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(textBox_OutPutValue.Text);
            double squaredValue = Math.Pow(currentValue, 2);
            textBox_OutPutValue.Text = squaredValue.ToString();
            Lbl_1.Text = $"{currentValue}² = {squaredValue}";
            AddToHistory($"{currentValue}²", squaredValue.ToString());
        }

        private void Btn_NthRoot_Click_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(textBox_OutPutValue.Text);
            double nthRootValue = Math.Pow(currentValue, 1.0 / 3);  // Cambia el "3" por cualquier otro valor si quieres una raíz enésima diferente.
            textBox_OutPutValue.Text = nthRootValue.ToString();
            Lbl_1.Text = $"√{currentValue} = {nthRootValue}";
            AddToHistory($"√{currentValue}", nthRootValue.ToString());
        }

        private void Btn_Expo_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(textBox_OutPutValue.Text);
            double exponentialValue = Math.Exp(currentValue);
            textBox_OutPutValue.Text = exponentialValue.ToString();
            Lbl_1.Text = $"exp({currentValue}) = {exponentialValue}";
            AddToHistory($"exp({currentValue})", exponentialValue.ToString());
        }

        private void Btn_Ln_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(textBox_OutPutValue.Text);
            if (currentValue <= 0)
            {
                ShowError("El logaritmo natural solo acepta números positivos");
                return;
            }
            double lnValue = Math.Log(currentValue);
            textBox_OutPutValue.Text = lnValue.ToString();
            Lbl_1.Text = $"ln({currentValue}) = {lnValue}";
            AddToHistory($"ln({currentValue})", lnValue.ToString());
        }

        private void Btn_Log_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(textBox_OutPutValue.Text);
            if (currentValue <= 0)
            {
                ShowError("El logaritmo solo acepta números positivos");
                return;
            }
            double logValue = Math.Log10(currentValue);
            textBox_OutPutValue.Text = logValue.ToString();
            Lbl_1.Text = $"log({currentValue}) = {logValue}";
            AddToHistory($"log({currentValue})", logValue.ToString());
        }

        private void Btn_Tan_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(textBox_OutPutValue.Text);
            double tanValue = Math.Tan(currentValue);
            if (double.IsInfinity(tanValue))
            {
                ShowError("Tangente indefinida para este ángulo");
                return;
            }
            textBox_OutPutValue.Text = tanValue.ToString();
            Lbl_1.Text = $"tan({currentValue}) = {tanValue}";
            AddToHistory($"tan({currentValue})", tanValue.ToString());
        }

        private void Btn_Cos_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(textBox_OutPutValue.Text);
            double cosValue = Math.Cos(currentValue);
            textBox_OutPutValue.Text = cosValue.ToString();
            Lbl_1.Text = $"cos({currentValue}) = {cosValue}";
            AddToHistory($"cos({currentValue})", cosValue.ToString());
        }

        private void Btn_Sen_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(textBox_OutPutValue.Text);
            double sinValue = Math.Sin(currentValue);
            textBox_OutPutValue.Text = sinValue.ToString();
            Lbl_1.Text = $"sin({currentValue}) = {sinValue}";
            AddToHistory($"sin({currentValue})", sinValue.ToString());
        }

        private void Btn_Pi_Click(object sender, EventArgs e)
        {
            textBox_OutPutValue.Text = Math.PI.ToString();
            Lbl_1.Text = "π";
            AddToHistory("π", Math.PI.ToString());
        }

        private void Btn_ChangeSign_Click(object sender, EventArgs e)
        {
            if (textBox_OutPutValue.Text != "0")
            {
                double currentValue = double.Parse(textBox_OutPutValue.Text);
                double newValue = -currentValue;
                textBox_OutPutValue.Text = newValue.ToString();
                Lbl_1.Text = $"±({currentValue}) = {newValue}";
                AddToHistory($"±({currentValue})", newValue.ToString());
            }
        }
    }
}
