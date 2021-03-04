using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Implementation
{

    public class TreeNode<T>
    {
        #region Fields
        T _value;
        TreeNode<T> _parent;
        List<TreeNode<T>> _children;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"> value for the node</param>
        /// <param name="parent"> parent for the node</param>
        public TreeNode(T value, TreeNode<T> parent)
        {
            this._value = value;
            this._parent = parent;
            this._children = new List<TreeNode<T>>();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// gets the value stored in the node
        /// </summary>
        public T Value { get { return _value; } }


        /// <summary>
        /// gets and sets the parent of the node
        /// </summary>
        public TreeNode<T> Parent
        {
            get { return _parent; }
            set { Parent = value; }
        }

        /// <summary>
        /// Gtes a read-only list of the children of the node
        /// </summary>
        public IList<TreeNode<T>> Children
        {
            get { return _children.AsReadOnly(); }
        }


        #endregion


        #region Methods

        /// <summary>
        /// adds the given node as a child this node
        /// </summary>
        /// <param name="child">child to add</param>
        /// <returns>true  if the child was added, false otherwise </returns>
        public bool AddChild(TreeNode<T> child)
        {


            if (_children.Contains(child))
            {
                //don't add duplicate children
                return false;
            }
            else if (child == this)
            {
                //don't add self as child
                return false;
            }
            else
            {
                //add as child and add self as parent
                _children.Add(child);
                child.Parent = this;

                return true;
            }



        }


        /// <summary>
        /// Removes the given node as a child this node
        /// </summary>
        /// <param name="child">child to remove</param>
        /// <returns> return true if the child was removed, return false otherwise </returns>
        public bool RemoveChild(TreeNode<T> child)
        {

            //only remove children in list 
            if (_children.Contains(child))
            {
                child.Parent = null;
                return _children.Remove(child);

            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Remove all the children for the node
        /// </summary>
        /// <returns> retrun true if the children ware removed, false otherwise </returns>
        public bool RemoveAllChildren()
        {
            for (int i = _children.Count - 1; i >= 0; i--)
            {
                _children[i].Parent = null;
                _children.RemoveAt(i);
            }

            return true;
        }


        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append("[Node Value: " + _value + " Parent: ");

            if (_parent != null)
            {
                nodeString.Append(_parent.Value);
            }
            else
            {
                nodeString.Append("null");
            }

            nodeString.Append("Children: ");
            for (int i = 0; i < _children.Count; i++)
            {
                nodeString.Append(_children[i].Value + " ");
            }
            nodeString.Append("]");

            //return base.ToString();
            return nodeString.ToString();
        }

        #endregion Methods
    }
}
