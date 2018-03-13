﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using KansasStateUniversity.TreeViewer2;

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
            /*
             * Read in expression
             * Convert to postfix
             * Build an expression tree 
             */
            string expression = uxInitialExpressionTextBox.Text;

            //check if expression is empty or if there's any symbols, letters, or stuff
            if (expression == "" || RemoveSpaces(expression) == " ")
            {
                MessageBox.Show("Error: Please enter something for the initial expression!");
                uxInitialExpressionTextBox.Text = ""; //clear out textbox
                return;
            }
            else if (!IsProperFormat(expression))
            {
                MessageBox.Show("Error: Please remove letters and unsupported symbols from the initial expression!");
                uxInitialExpressionTextBox.Text = ""; //clear out textbox
                return;
            }


            //reformat with some spaces between operators
            StringBuilder sb = new StringBuilder(expression);
            foreach (char c in @"+-*/()")
                sb.Replace(c.ToString(), " " + c + " ");
            expression = sb.ToString();
            //now it's good

            string InitialType = uxInitialTypeComboBox.Text;
            string ResultType = uxResultTypeComboBox.Text;

            //find the initialtype selected in the combobox
            switch (InitialType)
            {
                case "Infix":
                    {
                        switch (ResultType)
                        {
                            case "Infix":
                                //update result box to expression
                                uxResultTextBox.Text = RemoveSpaces(expression);
                                break;
                            case "Prefix":
                                string postfix = InfixtoPost(expression); //convert to postfix                                            
                                ExpressionTree<string> t = TreeConversion(postfix); //convert to exp. tree
                                //do a preorder transversal
                                uxResultTextBox.Text = RemoveSpaces(t.Preorder(t));
                                break;
                            case "Postfix":
                                //convert to postfix, using function
                                //also remove any extra spaces and replace them with " "
                                uxResultTextBox.Text = RemoveSpaces(InfixtoPost(expression));
                                break;
                            default:
                                MessageBox.Show("Error: Invalid Option");
                                break;
                        }
                        break;
                    }
                case "Prefix":
                    {
                        string postfix = PretoPost(expression);  //convert to postfix
                        ExpressionTree<string> t = TreeConversion(postfix); //convert to exp. tree

                        switch (ResultType)
                        {
                            case "Infix":
                                //now do inorder transversal
                                uxResultTextBox.Text = RemoveSpaces(t.Inorder(t));
                                break;
                            case "Prefix":
                                //update result box to expression
                                uxResultTextBox.Text = RemoveSpaces(expression);
                                break;
                            case "Postfix":
                                //convert from prefix to postfix
                                uxResultTextBox.Text = RemoveSpaces(postfix);
                                break;
                            default:
                                MessageBox.Show("Error: Invalid Option");
                                break;
                        }
                        break;
                    }
                case "Postfix":
                    {
                        string postfix = expression; //should already be in postfix
                        ExpressionTree<string> t = TreeConversion(postfix); //convert to exp. tree
                        switch (ResultType)
                        {
                            case "Infix":
                                //now do inorder transversal
                                uxResultTextBox.Text = RemoveSpaces(t.Inorder(t));
                                break;
                            case "Prefix":
                                //do a preorder transversal
                                uxResultTextBox.Text = RemoveSpaces(t.Preorder(t));
                                break;
                            case "Postfix":
                                //update result box to expression
                                uxResultTextBox.Text = RemoveSpaces(expression);
                                break;
                            default:
                                MessageBox.Show("Error: Invalid Option");
                                break;
                        }
                        break;
                    }
                default:
                    MessageBox.Show("Error: Invalid Choice");
                    break;
            }

        }

        private ExpressionTree<string> TreeConversion(string postfix)
        {
            Stack<ExpressionTree<string>> s = new Stack<ExpressionTree<string>>();
            char[] delims = { ' ' };
            string[] pieces = (postfix).Split(delims, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < pieces.Length; i++)
            {
                if (Regex.IsMatch(pieces[i].ToString(), @"^\d+$")) //if the piece is a number
                {
                    //create a singleton tree and push it onto the stack
                    ExpressionTree<string> single = new ExpressionTree<string>(pieces[i].ToString());
                    s.Push(single);
                }
                //if the current piece is an operator
                else if (Regex.IsMatch(pieces[i].ToString(), "[+-/*]"))
                {
                    //pop the stack twice
                    ExpressionTree<string> tree1 = s.Pop();
                    ExpressionTree<string> tree2 = s.Pop();
                    ExpressionTree<string> newTree = new ExpressionTree<string>(pieces[i].ToString(), tree2, tree1);
                    s.Push(newTree);
                }
                else
                {
                    continue;
                    //whitespace
                }
            }
            return s.Pop();
        }

        private string InfixtoPost(string init)
        {
            Stack<Char> characters = new Stack<char>();
            StringBuilder result = new StringBuilder();

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
                            result.Append(" " + characters.Pop() + " "); //pop the top element from the stack onto result
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
                        result.Append(" " + characters.Pop() + " ");
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
            return result.ToString();
        }

        private string PretoPost(string init) //method for going from Prefix to Postfix
        {
            Stack<string> s = new Stack<string>();
            char[] delims = { ' ' };
            string[] pieces = (init).Split(delims, StringSplitOptions.RemoveEmptyEntries);

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
            return s.Pop();
        }
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

        private bool IsProperFormat(string expression)
        {
            foreach (char c in expression)
            {
                if (Regex.IsMatch(c.ToString(), @"^\d+$") || Regex.IsMatch(c.ToString(), "[+-/*]") || c == ' ') //if it's a number / operator / space it's allowed
                {
                    continue;
                }
                else //other things return false
                {
                    return false;
                }
            }
            return true;
        }

        private string RemoveSpaces(string s)
        {
            return Regex.Replace(s, @"\s+", " ");
        }

        private void BuildTreeClick(object sender, EventArgs e)
        {
            string expression = uxInitialExpressionTextBox.Text;

            //check if expression is empty or if there's any symbols, letters, or stuff
            if (expression == "" || RemoveSpaces(expression) == " ")
            {
                MessageBox.Show("Error: Please enter something for the initial expression!");
                uxInitialExpressionTextBox.Text = ""; //clear out textbox
                return;
            }
            else if (!IsProperFormat(expression))
            {
                MessageBox.Show("Error: Please remove letters and unsupported symbols from the initial expression!");
                uxInitialExpressionTextBox.Text = ""; //clear out textbox
                return;
            }

            //reformat with some spaces between operators
            StringBuilder sb = new StringBuilder(expression);
            foreach (char c in @"+=*/()")
                sb.Replace(c.ToString(), " " + c + " ");
            expression = sb.ToString();
            //now it's good

            string InitialType = uxInitialTypeComboBox.Text;

            switch(InitialType)
            {
                case "Infix":
                    {
                        string postfix = InfixtoPost(expression);
                        ExpressionTree<string> tree = TreeConversion(postfix);
                        tree.DrawTree();
                        break;
                    }
                case "Prefix":
                    {
                        string postfix = PretoPost(expression);
                        ExpressionTree<string> tree = TreeConversion(postfix);
                        tree.DrawTree();
                        break;
                    }
                case "Postfix":
                    {
                        ExpressionTree<string> tree = TreeConversion(expression);
                        tree.DrawTree();
                        break;
                    }
                default:
                    MessageBox.Show("Error: Invalid choice.");
                    break;
            }
        }

        private void EvaluateClick(object sender, EventArgs e)
        {

        }
    }
}
