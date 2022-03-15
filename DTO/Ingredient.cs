
namespace DTO
{
    /// <summary>
    /// This class implements a TreeElement of type ingredient.
    /// </summary>
    public class Ingredient : TreeElement
    {
        public int QuantityTypeId { get; set; }
        public int Glucid { get; set; }
        public int Lipid { get; set; }
        public int Protein {  get; set; }
        /// <summary>
        /// This constructor is used to create an ingredient from existing data. To create a new ingredient
        /// with default data, use the constructor with no parameters instead.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="categoryId"></param>
        /// <param name="nodeLevel"></param>
        /// <param name="glucid"></param>
        /// <param name="lipid"></param>
        /// <param name="protein"></param>
        public Ingredient(int id, string name, int categoryId, int nodeLevel, int glucid, int lipid, int protein, int quantityTypeId)
        {
            Id = id;
            Text = name;
            ParentId = categoryId;
            NodeLevel = nodeLevel;
            Glucid = glucid;
            Lipid = lipid;
            Protein = protein;
            QuantityTypeId = quantityTypeId;

            

            ApplyDefaultColor();
        }

        /// <summary>
        /// This constructor is used to create a ingredient that is not yet saved in the DB. The Id of the 
        /// ingredient is set to -1, the text to 'New Ingredient' and the Parent to treeView root.
        /// </summary>
        public Ingredient()
        {
            Id = -1;
            Text = "New Ingredient";
            ParentId = -1;
            Glucid = 0;
            Lipid = 0;
            Protein = 0;
            QuantityTypeId = 1;

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
    }
}
