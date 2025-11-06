using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    internal class Print
    {
        private readonly TextBox _input;

        public Print(TextBox input)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
        }
        public void Number(int number)
        {
            if (_input.Text.Length > 0 && (_input.Text[_input.Text.Length - 1] == 'π' || _input.Text[_input.Text.Length - 1] == 'e'))
            {
                _input.Text += $"*{number}";
            }
            else _input.Text += number;
        }
        public void Operator(char operation)
        {
            if (_input.Text.Length > 0)
            {
                switch (_input.Text[_input.Text.Length - 1])
                {
                    case '*':
                    case '+':
                    case '-':
                    case '/':
                        _input.Text = _input.Text.Substring(0, _input.Text.Length - 1);
                        _input.Text += operation;
                        break;

                    default:
                        _input.Text += operation;
                        break;
                }
            }
        }
        public void Dot()
        {
            if (_input.Text.Length == 0) _input.Text += "0.";
            else if (_input.Text.Length > 0)
            {
                switch (_input.Text[_input.Text.Length - 1])
                {
                    case '/':
                    case '*':
                    case '-':
                    case '+':
                        _input.Text += "0.";
                        break;

                    default:
                        _input.Text += ".";
                        break;
                }
            }
        }
        public void Symbol(char symbol)
        {
            if (_input.Text.Length > 0)
            {
                switch (_input.Text[_input.Text.Length - 1])
                {
                    case '*':
                    case '+':
                    case '-':
                    case '/':
                        _input.Text += symbol;
                        break;

                    default:
                        _input.Text += $"*{symbol}";
                        break;
                }
            }
            else _input.Text += symbol;
        }
    }
}
