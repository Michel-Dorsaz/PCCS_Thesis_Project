using BLL;
using DTO;
using NUnit.Framework;
using System.Drawing;
using System.Windows.Forms;

namespace Unit_Tests
{
    public class TreeManager_Test
    {
        public TreeView TreeView { get; set; }
        public TreeManager TreeManager { get; set; }

        [SetUp]
        public void Setup()
        {
            TreeView = new TreeView();
            TreeManager = new TreeManager(TreeView);
        }

        [Test]
        public void Drop_Success_Test()
        {

            // Drop on root

            IngredientCategory c = new IngredientCategory();
            TreeManager.Drag(c);
            TreeManager.Drop(null);

            Assert.IsTrue(TreeView.Nodes[0] == c);

            // Drop on category

            Ingredient i = new Ingredient();
           
            TreeManager.Drag(i);
            TreeManager.Drop(c);

            Assert.IsTrue(c.Nodes.Contains(i));
        }

        [Test]
        public void Drop_Fail_Test()
        {
            Ingredient i = new Ingredient();
            TreeView.Nodes.Add(i);

            IngredientCategory c = new IngredientCategory();

            TreeManager.Drag(c);
            TreeManager.Drop(i);

            Assert.IsFalse(i.Nodes.Contains(c));
        }

        [Test]
        public void DragOver_Test()
        {
            IngredientCategory c = new IngredientCategory();
            TreeView.Nodes.Add(c);

            Ingredient i = new Ingredient();

            TreeManager.Drag(i);
            TreeManager.DragOver(c);

            Assert.IsTrue(c.BackColor == Color.LightGreen);
        }
    }
}
