using BLL;
using DTO;
using NUnit.Framework;

namespace Unit_Tests
{
    public class IngredientManager_Test
    {

        [Test]
        public void GetTreeElements_Test()
        {
            Assert.IsNotEmpty(IngredientsManager.GetTreeElements());
        }

        public void UpdateChildrenNodeLevel_Test()
        {
            TreeElement parent = new IngredientCategory()
            {
                NodeLevel = 1
            };
            TreeElement child = new IngredientCategory()
            {
                NodeLevel = 9
            };

            parent.Nodes.Add(child);

            IngredientsManager.UpdateChildrenNodeLevel(parent);

            Assert.IsTrue(child.NodeLevel == parent.NodeLevel + 1);
        }
    }
}
