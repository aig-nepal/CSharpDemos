using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Implementation
{
    /// <summary>
    /// a tree
    /// </summary>
    /// <typeparam name="T"> type of values stored in tree </typeparam>
    public class Tree<T>
    {
        #region Fields
        TreeNode<T> _root = null;
        List<TreeNode<T>> _nodes = new List<TreeNode<T>>();

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"> value of the root node </param>
        public Tree(T value)
        {
            _root = new TreeNode<T>(value, null);
            _nodes.Add(_root);
        }

        #endregion Constructor


        #region Properties

        /// <summary>
        /// Gets the number of nodes in the tree 
        /// </summary>
        public int Count { get { return _nodes.Count; } }

        /// <summary>
        /// Gets the root of the tree 
        /// </summary>
        public TreeNode<T> Root { get { return _root; } }


        #endregion Properties

        #region Methods

        /// <summary>
        /// Clears all the nodes from the tree
        /// </summary>
        void Clear()
        {

            // remove all the children from each node
            // so nodes can be garbage collected
            foreach (TreeNode<T> node in _nodes)
            {
                node.Parent = null;
                node.RemoveAllChildren();
            }

            // now remove all the nodes from the tree and set root to null
            for (int i = _nodes.Count - 1; i >= 0; i--)
            {
                _nodes.RemoveAt(i);
            }
            _root = null;
        }


        /// <summary>
        ///  Adds the given node to the tree. if the given node is 
        ///  null the method returns false. if the parent node is null
        ///  or isn't in the tree the method returns false. if the given 
        ///  node is already a child of the parent node the methods return false
        /// </summary>
        /// <param name="node"> node to add</param>
        /// <returns> true if the node is added, false otherwise  </returns>
        public bool AddNode(TreeNode<T> node)
        {
            if (node == null ||
                node.Parent == null ||
                !_nodes.Contains(node.Parent))
            {
                return false;
            }
            else if (node.Parent.Children.Contains(node))
            {
                //node already a child of parent
                return false;
            }
            else
            {
                // add child as tree node and as a child to parent
                _nodes.Add(node);
                return node.Parent.AddChild(node);

            }
        }


        /// <summary>
        /// Remove the given node from the tree. if the node isn't 
        /// found in the tree, the method returns false.
        /// 
        /// Note: that the subtree with the node to remove as its
        /// root is pruned from the tree
        /// </summary>
        /// <param name="removeNode"> node to remove</param>
        /// <returns> true if the node is removed, false otherwise </returns>
        public bool RemoveNode(TreeNode<T> removeNode)
        {
            if (removeNode == null)
            {
                return false;
            }
            else if (removeNode == _root)
            {
                // removing the root clears the tree
                Clear();
                return true;
            }
            else
            {
                // remove as child of parent
                bool success = removeNode.Parent.RemoveChild(removeNode);

                if (!success)
                {
                    return false;
                }

                // remove node from tree
                success = _nodes.Remove(removeNode);
                if (!success)
                {
                    return false;
                }

                // check for branch node
                if (removeNode.Children.Count > 0)
                {
                    // recursively prune subtree
                    IList<TreeNode<T>> children = removeNode.Children;
                    for (int i = children.Count - 1; i >= 0; i--)
                    {
                        RemoveNode(children[i]);
                    }
                }

                return true;

            }

        }



        /// <summary>
        /// Finds a tree node with the given value. if there
        /// are multiple tree nodes with the given value the 
        /// method returns the first one it finds
        /// </summary>
        /// <param name="value">value to find</param>
        /// <returns> tree node or null if not found </returns>
        public TreeNode<T> Find(T value)
        {
            foreach (TreeNode<T> node in _nodes)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }


        /// <summary>
        /// Converts the tree to a  comma-separated string of nodes
        /// </summary>
        /// <returns> comma-separated string of nodes</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Root: ");
            if (_root != null)
            {
                stringBuilder.Append(_root.Value + " ");
            }
            else
            {
                stringBuilder.Append("null");
            }

            for (int i = 0; i < Count; i++)
            {
                stringBuilder.Append(_nodes[i].ToString());
                if (i < Count - 1)
                {
                    stringBuilder.Append(" , ");
                }
            }

            // return base.ToString();
            return stringBuilder.ToString();
        }

        #endregion Methods
    }
}

