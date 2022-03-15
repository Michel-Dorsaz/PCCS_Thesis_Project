using BLL;
using DTO;
using Serilog;

namespace UI.Ingredients
{
    /// <summary>
    /// This UserControl is used to display and manage the ingredients and their category 
    /// inside a treeView.
    /// </summary>
    public partial class IngredientsTreeviewControl : UserControl
    {
        private ISelection Selection; // The class that handle the selected TreeElement
        private Label InfoLabel;
        private Panel Panel; // The panel in which the UserControl is displayed
        private TreeManager TreeManager;
        private TreeNode CurrentSelectedNode;

        /// <summary>
        /// This constructor Load the data from the DB and use the Show method directly.
        /// <para />
        /// The left and right panels of the parameter FormEdit are used to display this class and
        /// the Selection in each panels respectively
        /// </summary>
        /// <param name="formEdit"></param>
        public IngredientsTreeviewControl(FormEdit formEdit)
        {          
            InitializeComponent();
            SetUpEventHandlers(formEdit);

            Panel = formEdit.GetLeftPanel();
            InfoLabel = formEdit.GetInfoLabel();

            InfoLabel.Text = "Loading...";

            Selection = new IngredientSelectionHandler(this, formEdit.GetRightPanel(), formEdit.GetInfoLabel());
            TreeManager = new TreeManager(treeView);

            Dock = DockStyle.Fill;

            Show();

            LoadData();

            // Pre-select the first node of the treeview to make it displayed in the selection panel
            CurrentSelectedNode = treeView.Nodes[0];
            treeView.SelectedNode = CurrentSelectedNode;

            InfoLabel.Text = "Ready to work!";
        }

        /// <summary>
        /// Clear the panel in which the TreeView is, clear the TreeView nodes and
        /// load the ingredients and ingredientsCategories into the TreeView.
        /// </summary>
        private void LoadData()
        {
            Log.Information("IngredientTreeViewControl - LoadData()");
            InfoLabel.Text = "Loading treeview...";

            Panel.Controls.Clear();
            Panel.Controls.Add(this);         

            TreeElement[]? treeElements = IngredientsManager.GetTreeElements();

            TreeManager.SetTreeElements(treeElements);

            InfoLabel.Text = "Ready to work!";
        }

        /// <summary>
        /// Update the all information about the current node selected.
        /// </summary>
        /// <param name="newNode"></param>
        public void UpdateCurrentNode(TreeElement newNode)
        {
            CurrentSelectedNode = newNode;
        }

        /// <summary>
        /// Update the text of the current node selected.
        /// <para />
        /// This method differ from the UpdateCurrentNode in the fact that only the text is modified.
        /// </summary>
        /// <param name="text"></param>
        public void UpdateCurrentNodeText(string text)
        {
            CurrentSelectedNode.Text = text;
        }


        /// <summary>
        /// Setup the many Evenhandlers needed to improve the User Experience.
        /// </summary>
        /// <param name="formEdit"></param>
        private void SetUpEventHandlers(FormEdit formEdit)
        {
            // Initiate the drag of a new element
            buttonNewIngredient.MouseDown += new MouseEventHandler(ButtonIngredient_MouseDown);
            buttonNewCategory.MouseDown += new MouseEventHandler(ButtonCategory_MouseDown);

            // Display an image of the dragged element on drag
            buttonNewIngredient.GiveFeedback += (sender, e) => DragControl(buttonNewIngredient, e, true);
            buttonNewCategory.GiveFeedback += (sender, e) => DragControl(buttonNewCategory, e, true);

            // Manage the drag and drop inside the treeView
            treeView.AllowDrop = true;
            treeView.ItemDrag += new ItemDragEventHandler(TreeView_ItemDrag);
            treeView.DragEnter += new DragEventHandler(TreeView_DragEnter);
            treeView.DragDrop += new DragEventHandler(TreeView_DragDrop);
            treeView.DragLeave += new EventHandler(TreeView_DragLeave);
            treeView.DragOver += new DragEventHandler(TreeView_DragOver);
            treeView.KeyDown +=  new KeyEventHandler(KeyEventHandler);

            // Magage the drag and drop over the delete button
            buttonDelete.AllowDrop = true;
            buttonDelete.DragEnter += new DragEventHandler(ButtonDelete_DragEnter);
            buttonDelete.DragDrop += new DragEventHandler(ButtonDelete_DragDrop);
            buttonDelete.DragLeave += new EventHandler(ButtonDelete_DragLeave);          

            // Save data when the form is closing
            formEdit.FormClosing += new FormClosingEventHandler(Form_OnClosing);
        }

        /// <summary>
        /// Save data when the form is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form_OnClosing(object? sender, FormClosingEventArgs e)
        {
            Log.Information("IngredientTreeViewControl - FormEdit closing");
            InfoLabel.Text = "Saving...";

            Selection.Save();
        }

        /// <summary>
        /// When a new TreeElement is selected, the current one is saved and the
        /// Selection panel is updated with the information of the new TreeElement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;         

            // Save current selection
            InfoLabel.Text = "Saving...";
            Selection.Save();

            // Update selected Node
            CurrentSelectedNode = e.Node;

            // Update Selection panel

            InfoLabel.Text = "Updating...";

            Selection.Update((TreeElement) e.Node);
   
            InfoLabel.Text = "Ready to work!";
        }

        /// <summary>
        /// Supress the windows sound when pressing the enter key. The sound
        /// is due to input boxes not being multi-line, thus the program trigger a
        /// warning sound on return key as no additional line is allowed. The sound is
        /// removed because it is not clear for the user what it means.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void KeyEventHandler(object? sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char) Keys.Return)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        #region DragAndDrop

        /// <summary>
        /// Initiate the drag of a new Ingredient.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonIngredient_MouseDown(object? sender, MouseEventArgs e)
        {
            Ingredient newIngredient = new Ingredient();

            buttonNewIngredient.DoDragDrop(newIngredient, DragDropEffects.Copy);
        }

        /// <summary>
        /// Initiate the drag of a new Category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCategory_MouseDown(object? sender, MouseEventArgs e)
        {
            IngredientCategory newCategory = new IngredientCategory();

            buttonNewCategory.DoDragDrop(newCategory, DragDropEffects.Copy);
        }

        /// <summary>
        /// Manage the drag of an item by displaying an image of its control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_ItemDrag(object? sender, ItemDragEventArgs e)
        {
            if (e.Item == null)
                return;

            Label draggedItem = new Label();

            // The '+' is a somewhat representation of the all direction arrows to define
            // a draggable element
            draggedItem.Text = "+ " + ((TreeElement) e.Item).Text;
            draggedItem.BackColor = Color.White;

            // Display the control image during the drag
            draggedItem.GiveFeedback += (sender, e) => DragControl(draggedItem, e, false);

            draggedItem.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        /// <summary>
        /// When a drag enter the TreeView; the drag is allowed only for ingredients and their categories.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data == null)
                return;

            // The drag inside the treeView is allow only for ingredients and their categories
            if(GetTreeElementFromDataEvent(e) != null)
            {
                e.Effect = e.AllowedEffect;
                TreeManager.DragEnter();
            }        
        }

        /// <summary>
        /// When a drop happens inside the treeView, the node at target position is saved
        /// and the TreeManager will handle the drop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_DragDrop(object? sender, DragEventArgs e)
        {
            // Retrieve the node at drop position
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));
            TreeElement targetNode = (TreeElement)treeView.GetNodeAt(targetPoint);

            InfoLabel.Text = "Updating...";
            Log.Information("IngredientTreeViewControl - Drop at {Target}", targetNode);

            TreeManager.Drop(GetTreeElementFromDataEvent(e), targetNode);
            Selection.Save();

            InfoLabel.Text = "Ready to work!";
        }

        /// <summary>
        /// Reset the backcolor on drag leave.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_DragLeave(object? sender, EventArgs e)
        {
            TreeManager.ResetColor();
        }

        /// <summary>
        /// Manage the dragging over the treeView. It display colors according to the right of dropping
        /// the dragged element at the target position. The backcolor of the target position is changed to :
        /// <para/>
        /// Green if allowed to drop,
        /// <para />
        /// Red if not allowed to drop (if a drop is done nothing will happens then).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_DragOver(object? sender, DragEventArgs e)
        {
            // Retrieve the position of the drag
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));
            TreeElement targetNode = (TreeElement) treeView.GetNodeAt(targetPoint);

            
            // The TreeManager handle the target and display its backcolor accordingly
            TreeManager.DragOver(GetTreeElementFromDataEvent(e), targetNode);
        }

        /// <summary>
        /// Change the backcolor of the delete button area to green if allowed
        /// to drop an item to be deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_DragEnter(object? sender, DragEventArgs e)
        {


            TreeElement deletedElement = GetTreeElementFromDataEvent(e);

            // Check, if the deleted element is not null (meaning e.Data was of type Ingredient or IngredientCategory)
            if(deletedElement != null)
            {
                e.Effect = e.AllowedEffect;
                buttonDelete.BackgroundImage = Properties.Resources.delete_allow;
            }
        }

        /// <summary>
        /// Manage the drop of an element on the delete buttona area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_DragDrop(object? sender, DragEventArgs e)
        {
            // Change the backgound image back to normal
            buttonDelete.BackgroundImage = Properties.Resources.delete;

            /*
             * Only an EXISTING ingredient or a category can be deleted.
             * Thus, we create both and check whether they exist and correspond to 
             * appropried category
             */

            // Create both instances
            Ingredient? ingredient = (Ingredient) e.Data.GetData(typeof(Ingredient));
            IngredientCategory? category = (IngredientCategory) e.Data.GetData(typeof(IngredientCategory));           

            InfoLabel.Text = "Deleting...";
            Log.Information("IngredientTreeViewControl - Drop at delete button");

            // Check, if the instance is not null (meaning e.Data was that type)
            if (ingredient != null)
                IngredientsManager.Delete(ingredient);                      
            else if (category != null)
                IngredientsManager.Delete(category);

            // Ensure the selected node is not the one beeing deleted
            // To prevent being async with the Selection panel still displaying
            // a deleted item
            treeView.SelectedNode = treeView.Nodes[0];

            InfoLabel.Text = "Ready to work!";
        }

        /// <summary>
        /// Return the background image of the delete button back to normal
        /// when a drag leave its area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_DragLeave(object? sender, EventArgs e)
        {
            buttonDelete.BackgroundImage = Properties.Resources.delete;
        }

        #endregion

        /// <summary>
        /// This method create an image of the control parameter and replace the cursor 
        /// with this image while the FeedBack event is raised.
        /// <para />
        /// The boolean reduce allows to half the size of the image if true.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="e"></param>
        /// <param name="reduce"></param>
        public static void DragControl(Control control, GiveFeedbackEventArgs e, bool reduce)
        {
            // Create an image of the control
            Bitmap image = new Bitmap(control.ClientRectangle.Width, control.ClientRectangle.Height);
            control.DrawToBitmap(image, control.ClientRectangle);

            // Reduce the size if required
            if (reduce)
                image = new Bitmap(image, new Size(image.Width / 2, image.Height / 2));            

            // Modify the cursor to display the control image instead
            e.UseDefaultCursors = false;
            Cursor.Current = new Cursor(image.GetHicon());
        }

        private TreeElement GetTreeElementFromDataEvent(DragEventArgs e)
        {
            TreeElement ingredient = (TreeElement) e.Data.GetData(typeof(Ingredient));
            TreeElement category = (TreeElement)e.Data.GetData(typeof(IngredientCategory));

            if (ingredient != null)
                return ingredient;
            else
                return category;
        }
    }
}
