using DTO.Interfaces;

namespace DTO
{
    /// <summary>
    /// This class implements a TreeElement of type recipe's category.
    /// </summary>
    public class RecipeCategory : TreeElement, ICategory
    {

        public int WPP { get; set; }

        /// <summary>
        /// This constructor is used to create a category from existing data. To create a new category
        /// with default data, use the constructor with no parameters instead.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="parentCategory"></param>
        /// <param name="nodeLevel"></param>
        public RecipeCategory(int id, string name, int parentCategory, int nodeLevel, int wpp)
        {
            Id = id;
            Name = name;
            WPP = wpp;
            Text = Name + " (WPP: " + WPP + ")";
            ParentId = parentCategory;
            NodeLevel = nodeLevel;

            ApplyDefaultColor();
        }

        /// <summary>
        /// This constructor is used to create a category that is not yet saved in the DB. The Id of the 
        /// category is set to -1, the text to 'New Category' and the Parent to treeView root.
        /// </summary>
        public RecipeCategory()
        {
            Id = -1;
            Name = "New Category";
            WPP = 0;
            Text = Name + " (WPP: " + WPP + ")";
            ParentId = -1;
            NodeLevel = 0;

            ApplyDefaultColor();
        }

        /// <summary>
        /// Override of the AllowDrop method of a TreeElement. A category allows dropping only if the 
        /// dropped element is not itself or a parent of the drop target.
        /// <para />
        /// Returns true if the drop is allowed, false otherwise.
        /// </summary>
        /// <param name="droppedElement"></param>
        /// <returns></returns>
        public override bool AllowDrop(TreeElement droppedElement)
        {
            return (droppedElement != this && !Contains(droppedElement, this))
                && (droppedElement is Recipe || droppedElement is RecipeCategory);
        }

        /// <summary>
        /// Implementation of the Contains method of a ICategory.
        /// This method checks if a TreeElement contains another one in is children or the children of
        /// its children.
        /// <para />
        /// Returns true if the parent contains the potential child, false otherwise.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="potentialChild"></param>
        /// <returns></returns>
        public bool Contains(TreeElement parent, TreeElement potentialChild)
        {
            if (parent.Nodes.Contains(potentialChild))
                return true;

            foreach (TreeElement child in parent.Nodes)
            {
                if (Contains(child, potentialChild))
                    return true;
            }

            return false;
        }

        public override string GetNodePath(TreeNode node)
        {
            if (node == null)
                return "";

            return GetNodePath(node.Parent) + node.Name + "/";
        }
    }

}
