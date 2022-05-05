namespace DTO
{
    /// <summary>
    /// This class implements a TreeElement of type recipe.
    /// </summary>
    public class Recipe : TreeElement
    {

        /// <summary>
        /// Weight per portion
        /// </summary>
        public int WPP { get; set; }
        public int Portions { get; set; }

        /// <summary>
        /// This constructor is used to create an ingredient from existing data. To create a new recipe
        /// with default data, use the constructor with no parameters instead.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="categoryId"></param>
        /// <param name="nodeLevel"></param>
        /// <param name="glucid"></param>
        /// <param name="lipid"></param>
        /// <param name="protein"></param>
        public Recipe(int id, string name, int categoryId, int nodeLevel, int wpp, int portions)
        {
            Id = id;
            Name = name;
            WPP = wpp;
            Text = Name + " (WPP: " + WPP + ")";
            ParentId = categoryId;
            NodeLevel = nodeLevel;
            Portions = portions;

            ApplyDefaultColor();
        }

        /// <summary>
        /// This constructor is used to create a recipe that is not yet saved in the DB. The Id of the 
        /// recipe is set to -1, the text to 'New Recipe' and the Parent to treeView root.
        /// </summary>
        public Recipe()
        {
            Id = -1;
            Name = "New Recipe";
            WPP = 0;
            Text = Name + " (WPP: " + WPP + ")";
            ParentId = -1;
            Portions = 1;

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
            return false;
        }

        /// <summary>
        /// Override of the ApplyDefaultColor method from TreeElement to modify
        /// the default color of an ingredient in the TreeView.
        /// </summary>
        public override void ApplyDefaultColor()
        {
            BackColor = Color.White;
            ForeColor = Color.SaddleBrown;
        }

        public override string GetNodePath(TreeNode node)
        {
            if (node == null)
                return "";

            return GetNodePath(node.Parent) + node.Name + "/";
        }
    }
}
