using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;
using System.Windows.Forms;

namespace Project4
{
    public class ExpressionTree<T> : ITree, IColorizer where T : IComparable<T>
    {
        private T _key;
        private ExpressionTree<T> _left;
        private ExpressionTree<T> _right;
        public static ExpressionTree<T> NIL = new ExpressionTree<T>();
        private int _height;

        public ExpressionTree(T key)
        {
            _key = key;
            _right = NIL;
            _left = NIL;
            _height = 0;
        }

        public ExpressionTree(T key, ExpressionTree<T> left, ExpressionTree<T> right)
        {
            _key = key;
            _left = left;
            _right = right;
            _height = Math.Max(_left.Height, _right.Height) + 1;
        }

        public ExpressionTree()
        {
            _key = default(T);
            _right = NIL;
            _left = NIL;
            _height = -1;
        }

        public virtual string Preorder(ExpressionTree<T> tree)
        {
            if (tree == NIL) return "";
            try
            {
                string order = tree.Key.ToString();
                return " " + order + " " + Preorder(tree.Left) + " " + Preorder(tree.Right) + " ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: please reformat your initial expression.");
                return "";
            }
        }

        public virtual string Postorder(ExpressionTree<T> tree)
        {
            if (tree == NIL) return "";
            try
            {
                string data = tree.Key.ToString();
                return " " + Postorder(tree.Left) + " " + Postorder(tree.Left) + " " + data + " ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: please reformat your initial expression.");
                return "";
            }
        }

        public virtual string Inorder(ExpressionTree<T> tree)
        {
            if (tree == NIL) return "";
            try
            {
                string data = tree.Key.ToString();
                return "(" + Inorder(tree.Left) + " " + data + " " + Inorder(tree.Right) + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: please reformat your initial expression.");
                return "";
            }
        }
        object ITree.Root
        {
            get
            {
                return this;
            }
        }

        public ITree[] Children
        {
            get
            {
                ITree[] children = new ITree[2];
                children[0] = _left;
                children[1] = _right;
                return children;
            }
        }

        public virtual int SolveTree()
        {
            try
            {
                if (this == NIL) return 0;
                if (this.Key.ToString() == "+") //add
                {
                    return this._left.SolveTree() + this._right.SolveTree();
                }
                else if (this.Key.ToString() == "-") //subtract
                {
                    return this._left.SolveTree() - this._right.SolveTree();
                }
                else if (this.Key.ToString() == "*") //multiply
                {
                    return this._left.SolveTree() * this._right.SolveTree();
                }
                else //if (this.Key == "/") //divide
                {
                    return this._left.SolveTree() / this._right.SolveTree();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: please reformat before attempting to evaluate!");
                return 0;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (this == NIL) return true;
                else return false;
            }
        }

        private void RotateRight()
        {
            //NEED TO COMPLETE
            //rotate right about THIS root
            Right = new ExpressionTree<T>(Key, Left.Right, Right);
            Key = Left.Key;
            Left = Left.Left;
            Height = 1 + Math.Max(Right.Height, Left.Height);
        }

        private void RotateLeft()
        {
            //NEED TO COMPLETE
            //rotate left about THIS root
            Left = new ExpressionTree<T>(Key, Left, Right.Left);
            Key = Right.Key;
            Right = Right.Right;
            Height = 1 + Math.Max(Right.Height, Left.Height);
        }

        private void Rebalance()
        {
            //either rotate left, or rotate right then left (1 or 3)
            if (Left.Height + 1 < Right.Height)
            {
                //case 3
                if (Right.Left.Height > Right.Right.Height)
                {
                    //NEED TO COMPLETE
                    //need to rotate right about our right
                    Right.RotateRight();
                }
                //NEED TO COMPLETE
                //in both cases 1 and 3, rotate left
                RotateLeft();
            }
            //either rotate right, or rotate left then right (2 or 4)
            else if (Right.Height + 1 < Left.Height)
            {
                //case 4
                if (Left.Right.Height > Left.Left.Height)
                {
                    //NEED TO COMPLETE
                    //need to rotate left about our left
                    Left.RotateLeft();
                }
                //NEED TO COMPLETE
                //in both cases 2 and 4, rotate right
                RotateRight();
            }
        }
        public ExpressionTree<T> Insert(T c)
        {
            //Create a tree with one node
            if (this == NIL) return new ExpressionTree<T>(c);

            //Add it to the right subtree
            if (Key.CompareTo(c) < 0)
            {
                Right = Right.Insert(c);
            }

            //Add it to the left subtree
            if (Key.CompareTo(c) > 0)
            {
                Left = Left.Insert(c);
            }
            Height = 1 + Math.Max(Left.Height, Right.Height);
            Rebalance();
            return this;
        }

        public T Contains(T c)
        {
            if (this == NIL) return default(T);
            if (Key.Equals(c)) return Key;
            if (Key.CompareTo(c) < 0) return Right.Contains(c);
            return Left.Contains(c);
        }

        private T Min()
        {
            if (Left == NIL) return Key;
            else return Left.Min();
        }

        public ExpressionTree<T> Delete(T c)
        {
            //The value is not in the tree
            if (this == NIL) return this;

            //Search right
            if (Key.CompareTo(c) < 0)
            {
                Right = Right.Delete(c);
            }

            //Search left
            else if (Key.CompareTo(c) > 0)
            {
                Left = Left.Delete(c);
            }

            //Found it!
            else
            {
                //No children – make it the empty tree
                if (Left == NIL && Right == NIL) return NIL;

                //Move the right subtree up
                else if (Left == NIL)
                {
                    return Right;
                }

                //Move the left subtree up
                else if (Right == NIL)
                {
                    return Left;
                }

                //Replace it with the min of the right subtree
                else
                {
                    T small = Right.Min();
                    Right = Right.Delete(small);
                    Key = small;
                }
            }

            Height = 1 + Math.Max(Left.Height, Right.Height);
            Rebalance();
            return this;
        }

        public void DrawTree()
        {
            new TreeForm(this, 100, this).Show();
        }

        public override string ToString()
        {
            try
            {
                return _key.ToString();
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Error: please reformat!");
                return "";
            }
        }

        public T Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public ExpressionTree<T> Left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
            }
        }

        public ExpressionTree<T> Right
        {
            get
            {
                return _right;
            }
            set
            {
                _right = value;
            }
        }
        public Color GetColor(object obj)
        {
            return Color.Black;
        }
    }
}
