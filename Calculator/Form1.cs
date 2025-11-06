using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private Print _print;
        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon; // <- set the icon from resources

            _print = new Print(this.input);
        }

        // Numbers from 0 to 9
        private void Print_0_Click(object sender, EventArgs e) { _print.Number(0); }
        private void Print_1_Click(object sender, EventArgs e) { _print.Number(1); }
        private void Print_2_Click(object sender, EventArgs e) { _print.Number(2); }
        private void Print_3_Click(object sender, EventArgs e) { _print.Number(3); }
        private void Print_4_Click(object sender, EventArgs e) { _print.Number(4); }
        private void Print_5_Click(object sender, EventArgs e) { _print.Number(5); }
        private void Print_6_Click(object sender, EventArgs e) { _print.Number(6); }
        private void Print_7_Click(object sender, EventArgs e) { _print.Number(7); }
        private void Print_8_Click(object sender, EventArgs e) { _print.Number(8); }
        private void Print_9_Click(object sender, EventArgs e) { _print.Number(9); }

        // Operators        
        private void Print_Plus_Click(object sender, EventArgs e) { _print.Operator('+'); }        
        private void Print_Minus_Click(object sender, EventArgs e) { _print.Operator('-'); }
        private void Print_Asterisk_Click(object sender, EventArgs e) { _print.Operator('*'); }
        private void Print_Slash_Click(object sender, EventArgs e) { _print.Operator('/'); }
        
        // Dot .
        private void Print_Dot_Click(object sender, EventArgs e) { _print.Dot(); }

        // Symbols E & π
        private void Print_PI_Click(object sender, EventArgs e) { _print.Symbol('π'); }
        private void Print_E_Click(object sender, EventArgs e) { _print.Symbol('e'); }

        // The input is selected when the form is loaded so the user can start typing the question immediately
        private void Form1_Load(object sender, EventArgs e)
        {
            input.Select();
        }

        // Clears input and output
        private void Clear_Click(object sender, EventArgs e)
        {
            input.Text = string.Empty;
            ResultLabel.Text = string.Empty;
        }
        // Clears all of the history
        private void ClearHistory_Click(object sender, EventArgs e)
        {
            output.Clear();
        }
        // Deletes The last letter from the input
        private void Delete_Click(object sender, EventArgs e)
        {
            if (input.Text.Length > 0 && input.Text.Length != 1)
            {
                input.Text = input.Text.Substring(0, input.Text.Length - 1);
            }
            else if (input.Text.Length == 1)
            {
                input.Text = input.Text.Substring(0, input.Text.Length - 1);
                ResultLabel.Text = string.Empty;
            }
        }

        // The answer will be copied if the user clicks on the result label
        private void ResultLabel_Click(object sender, EventArgs e)
        {
            var text = ResultLabel.Text;
            if (string.IsNullOrWhiteSpace(text))
                return;

            try
            {
                Clipboard.SetText(text);
                MessageBox.Show("Answer copied to clipboard");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to copy to clipboard: " + ex.Message, "Clipboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2 methods for instant calculation
        private void input_TextChanged(object sender, EventArgs e)
        {
            string processed_input = "";
            for (int i = 0; i <= input.Text.Length - 1; i++)
            {
                switch (input.Text[i])
                {
                    case 'π':
                        processed_input += Math.PI;
                        break;

                    case 'e':
                        processed_input += Math.E;
                        break;

                    default:
                        if (char.IsDigit(input.Text[i]) || input.Text[i] == '+' || input.Text[i] == '-' || input.Text[i] == '*' || input.Text[i] == '/' || input.Text[i] == 'π' || input.Text[i] == 'e')
                            processed_input += input.Text[i];
                        break;
                }
            }
            string input_history = "";
            for (int i = 0; i <= input.Text.Length - 1; i++)
            {
                if (char.IsDigit(input.Text[i]) || input.Text[i] == '+' || input.Text[i] == '-' || input.Text[i] == '*' || input.Text[i] == '/' || input.Text[i] == 'π' || input.Text[i] == 'e')
                    input_history += input.Text[i];
            }
            if (input_history.Length - 1 > 0)
            {
                switch (input_history[input_history.Length - 1])
                {
                    case '/':
                    case '*':
                    case '-':
                    case '+':
                        input_history = input_history.Substring(0, input_history.Length - 1);
                        break;
                    default:
                        break;
                }
            }
            if (input_history.Length - 1 > 0)
            {
                switch (processed_input[processed_input.Length - 1])
                {
                    case '/':
                    case '*':
                    case '-':
                    case '+':
                        processed_input = processed_input.Substring(0, processed_input.Length - 1);
                        break;
                }
            }

            string question = processed_input;

            string num1 = "";
            string num2 = "";
            bool num2_exists = false;

            char op = '\0';
            bool op_exists = false;
            for (int i = 0; i < question.Length; i++)
            {
                char c = question[i];

                if ((c == '+' || c == '-' || c == '*' || c == '/') && !op_exists)
                {
                    op = c;
                    op_exists = true;
                }
                else if ((c == '+' || c == '-' || c == '*' || c == '/') && op_exists && num2_exists)
                {
                    double.TryParse(num1, out double int_num1);
                    double.TryParse(num2, out double int_num2);
                    switch (op)
                    {
                        case '+':
                            int_num1 = int_num1 + int_num2;
                            int_num2 = 0;
                            break;

                        case '-':
                            int_num1 = int_num1 - int_num2;
                            int_num2 = 0;
                            break;

                        case '*':
                            int_num1 = int_num1 * int_num2;
                            int_num2 = 0;
                            break;

                        case '/':
                            int_num1 = int_num1 / int_num2;
                            int_num2 = 0;
                            break;
                    }
                    num1 = int_num1.ToString();

                    op = c;

                    num2 = "";
                    num2_exists = false;
                }
                else if (char.IsDigit(c) || c == '.')
                {
                    if (!op_exists) num1 += c;
                    else
                    {
                        num2 += c;
                        num2_exists = true;
                    }
                }
            }

            //calculating
            double result = 0;
            double.TryParse(num1, out double n1);
            double.TryParse(num2, out double n2);
            switch (op)
            {
                case '+':
                    result = n1 + n2;
                    break;

                case '-':
                    result = n1 - n2;
                    break;

                case '*':
                    result = n1 * n2;
                    break;

                case '/':
                    result = n1 / n2;
                    break;
            }
            if (!op_exists) double.TryParse(processed_input, out result);
            ResultLabel.Text = input_history + " = " + result.ToString();
        }
        private void Calculate_Click(object sender, EventArgs e)
        {
            string processed_input = "";
            for (int i = 0; i <= input.Text.Length - 1; i++)
            {
                switch (input.Text[i])
                {
                    case 'π':
                        processed_input += Math.PI;
                        break;

                    case 'e':
                        processed_input += Math.E;
                        break;

                    default:
                        processed_input += input.Text[i];
                        break;
                }
            }
            string input_history = "";
            for (int i = 0; i <= input.Text.Length - 1; i++)
            {
                if (char.IsDigit(input.Text[i]) || input.Text[i] == '+' || input.Text[i] == '-' || input.Text[i] == '*' || input.Text[i] == '/' || input.Text[i] == 'π' || input.Text[i] == 'e')
                    input_history += input.Text[i];
            }
            switch (input_history[input_history.Length - 1])
            {
                case '/':
                case '*':
                case '-':
                case '+':
                    input_history = input_history.Substring(0, input_history.Length - 1);
                    break;
            }
            switch (processed_input[processed_input.Length - 1])
            {
                case '/':
                case '*':
                case '-':
                case '+':
                    processed_input = processed_input.Substring(0, processed_input.Length - 1);
                    break;
            }

            string question = processed_input;

            string num1 = "";
            string num2 = "";
            bool num2_exists = false;

            char op = '\0';
            bool op_exists = false;
            for (int i = 0; i < question.Length; i++)
            {
                char c = question[i];

                if ((c == '+' || c == '-' || c == '*' || c == '/') && !op_exists)
                {
                    op = c;
                    op_exists = true;
                }
                else if ((c == '+' || c == '-' || c == '*' || c == '/') && op_exists && num2_exists)
                {
                    double.TryParse(num1, out double int_num1);
                    double.TryParse(num2, out double int_num2);
                    switch (op)
                    {
                        case '+':
                            int_num1 = int_num1 + int_num2;
                            int_num2 = 0;
                            break;

                        case '-':
                            int_num1 = int_num1 - int_num2;
                            int_num2 = 0;
                            break;

                        case '*':
                            int_num1 = int_num1 * int_num2;
                            int_num2 = 0;
                            break;

                        case '/':
                            int_num1 = int_num1 / int_num2;
                            int_num2 = 0;
                            break;
                    }
                    num1 = int_num1.ToString();

                    op = c;

                    num2 = "";
                    num2_exists = false;
                }
                else if (char.IsDigit(c) || c == '.')
                {
                    if (!op_exists) num1 += c;
                    else
                    {
                        num2 += c;
                        num2_exists = true;
                    }
                }
            }

            //calculating
            double result = 0;
            double.TryParse(num1, out double n1);
            double.TryParse(num2, out double n2);
            switch (op)
            {
                case '+':
                    result = n1 + n2;
                    break;

                case '-':
                    result = n1 - n2;
                    break;

                case '*':
                    result = n1 * n2;
                    break;

                case '/':
                    result = n1 / n2;
                    break;
            }
            if (!op_exists) result = double.Parse(processed_input);
            output.Text = input_history + " = " + result.ToString() + "\r\n" + output.Text;
        }        
    }
}
