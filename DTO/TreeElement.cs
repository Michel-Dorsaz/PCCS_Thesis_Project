namespace DTO
{ 

    /// <summary>
    /// This class extends the TreeNode class to add additional information.
    /// </summary>
    public abstract class TreeElement : TreeNode, IComparable<TreeElement>
    {
        public int Id { get; set; } // Relative to the DB Id
        public int ParentId { get; set; } // The parent node's Id relative to the DB Id

        /// <summary>
        /// The tree level of the node is used to construct the hierarchy.
        /// The roots elements of the tree are the element with the node level 0.
        /// </summary>
        public int NodeLevel { get; set; }

        /// <summary>
        /// Returns true if the TreeElement parameter allows drop on him, false Otherwise
        /// </summary>
        /// <param name="droppedElement"></param>
        /// <returns></returns>
        public abstract bool AllowDrop(TreeElement droppedElement);

        /// <summary>
        /// Apply the default Color of the TreeElement : backcolor white and forecolor black
        /// <para />
        /// This method can be overrided to define other default colors.
        /// </summary>
        public virtual void ApplyDefaultColor()
        {
            BackColor = Color.White;
            ForeColor = Color.Black;
        }

        /// <summary>
        /// Implementation of the TreeElement comparator. It compares Treeelements
        /// based on their Nodelevel.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(TreeElement? other)
        {
            if(other == null)
                return 1;

            return this.NodeLevel - other.NodeLevel;
        }

        /// <summary>
        /// Return a string that represents the path to the node parameter.
        /// Each parent node text is added, starting from the root parent, separated
        /// with '/'. 
        /// <para />
        /// The parameter's node is included in the path. To get the path without the node, call 
        /// GetNodePath(node.Parent)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual string GetNodePath(TreeNode node)
        {
            if (node == null)
                return "";

            return GetNodePath(node.Parent) + node.Text + "/";
        }
    }
}
