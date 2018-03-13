using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    class ExpressionTreeLeaf<T> : ExpressionTree<T> where T : IComparable<T>
    {
        private string _leafdata;

        public ExpressionTreeLeaf(T key): base (key)
        {
            _leafdata = key.ToString();
        }

        public override string Inorder(ExpressionTree<T> tree)
        {
            return _leafdata;
        }

        public override string Postorder(ExpressionTree<T> tree)
        {
            return _leafdata;
        }

        public override string Preorder(ExpressionTree<T> tree)
        {
            return _leafdata;
        }
    }
}
