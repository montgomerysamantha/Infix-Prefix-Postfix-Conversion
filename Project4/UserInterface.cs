using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4
{
    public partial class uxUserInterface : Form
    {
        public uxUserInterface()
        {
            InitializeComponent();
            List<string> s = new List<string>();
            s.Add("Infix");
            s.Add("Prefix");
            s.Add("Postfix");

            uxInitialTypeComboBox.DataSource = s;
            uxResultTypeComboBox.BindingContext = new BindingContext(); //make it so the comboboxes are seperate w/ same datasource
            uxResultTypeComboBox.DataSource = s;

            uxInitialTypeComboBox.SelectedItem = 0;
            uxResultTypeComboBox.SelectedItem = 0;
        }

        private void ConvertExpressionClick(object sender, EventArgs e)
        {
            //infix to postfix conversion
            if (uxInitialTypeComboBox.Text == "Infix" && uxResultTypeComboBox.Text == "Postfix")
            {
                Stack<Char> characters = new Stack<char>();
                StringBuilder result = new StringBuilder();
                string init = uxInitialExpressionTextBox.Text;

                for (int i = 0; i < init.Length; i++)
                {
                    if (Char.IsNumber(init[i])) //check to see if it's a number
                    {
                        //add to result
                        result.Append(init[i]);
                    }
                    else if (Regex.IsMatch(init[i].ToString(), "[+-/*]")) //if it's an operator
                    {
                        int cur = OpPreced(init[i]); //finding the operator precedence of the current character
                        if (characters.Count != 0)
                        {
                            int stackop = OpPreced(characters.Peek()); //op preced of stack character

                            while (stackop > cur) //while top stack is an operator whose precedence is greater than that of the current piece
                            {
                                result.Append(characters.Pop() + " "); //pop the top element from the stack onto result
                                if (characters.Count == 0 || characters.Peek() == '(' || characters.Peek() == ')') break;
                            }
                        }
                        characters.Push(init[i]); //push current piece onto stack
                    }
                    else if (init[i] == '(')
                    {
                        characters.Push(init[i]);
                    }
                    else if (init[i] == ')') //If the current piece is a ), 
                    {
                        while (characters.Peek() != '(') // pop items from the stack onto result until the top of the stack is a (
                        {
                            //pop items from stack onto result 
                            result.Append(characters.Pop() + " ");
                        }
                        characters.Pop(); //to get rid of '('
                    }
                    else
                    {
                        //whitespace
                        result.Append(" ");
                        continue;
                    }
                }

                result.Append(" ");

                while (characters.Count != 0) //If items remain on the stack, pop them all onto result
                {
                    result.Append(characters.Pop() + " ");
                }
                uxResultTextBox.Text = result.ToString();
            }
            else if (uxInitialTypeComboBox.Text == "Prefix" && uxResultTypeComboBox.Text == "Postfix")
            {
                Stack<string> s = new Stack<string>();
                char[] delims = { ' ' };
                string[] pieces = (uxInitialExpressionTextBox.Text).Split(delims, StringSplitOptions.RemoveEmptyEntries);

                for (int i = pieces.Length - 1; i >= 0; i--)
                {
                    //if current piece is a number, push it on the stack
                    if (Regex.IsMatch(pieces[i], @"^\d+$"))
                    {
                        s.Push(pieces[i].ToString() + " ");
                    }
                    //if the current piece is an operator
                    else if (Regex.IsMatch(pieces[i].ToString(), "[+-/*]"))
                    {
                        //pop the stack twice
                        String val1 = s.Pop();
                        String val2 = s.Pop();
                        StringBuilder sb = new StringBuilder();
                        sb.Append(val1 + " " + val2 + " " + pieces[i] + " ");
                        s.Push(sb.ToString());
                    }
                }
                uxResultTextBox.Text = s.Pop();
            }
        }

        //private string 
        private int OpPreced(char c)
        {
            if ('+' == c || '-' == c)
            {
                return 1;
            }
            else if ('*' == c || '/' == c)
            {
                return 2;
            }
            return 0; //not called on an operator
        }

        private void BuildTreeClick(object sender, EventArgs e)
        {

        }

        private void EvaluateClick(object sender, EventArgs e)
        {

        }
    }
}
