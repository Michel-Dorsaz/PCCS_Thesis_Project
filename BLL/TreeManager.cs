using DTO;
using DTO.Interfaces;

namespace BLL
{
    /// <summary>
    /// This class manage a treeView and the action on it.
    /// </summary>
    public class TreeManager
    {
        private TreeView TreeView { get; set; }
        private TreeElement? DraggedOverElement { get; set; }

        public TreeManager(TreeView treeView)
        {
            TreeView = treeView;
        }

        /// <summary>
        /// Clear the treeView's nodes
        /// </summary>
        public void Clear()
        {
            TreeView.Nodes.Clear();
        }

        /// <summary>
        /// Manage the drop of a TreeElement on the target TreeElement of the treeView.
        /// </summary>
        /// <param name="target"></param>
        public void Drop(TreeElement draggedElement, TreeElement? target)
        {
            // Reset the previous color modification as the drag is ended
            ResetColor();

            // Cancel if the target does not allow drop
            if (draggedElement == null || (target != null && !target.AllowDrop(draggedElement)))
                return;

            // Remove the dragged element of the treeView
            TreeView.Nodes.Remove(draggedElement);

            // Add the dragged element to the target position
            if (target == null) // null means that the target is the root of the treeView
            {
                TreeView.Nodes.Add(draggedElement);
                draggedElement.ParentId = 1;
                draggedElement.NodeLevel = 0;
            }
            else
            {
                target.Nodes.Add(draggedElement);
                draggedElement.ParentId = target.Id;
                draggedElement.NodeLevel = target.NodeLevel + 1;
            }

            DraggedOverElement = null;

            // Select the dropped element to display it to the user
            TreeView.SelectedNode = draggedElement;
        }

        /// <summary>
        /// Change the background colors as the element is dragged over the TreeElement. The 
        /// color represents if the dragged element can be dropped at the target position :
        /// <para />
        /// Green means allowed, Red means not allowed.
        /// </summary>
        /// <param name="target"></param>
        public void DragOver(TreeElement draggedElement, TreeElement target)
        {

            // No change if same element, to reduce flickering
            if (target == DraggedOverElement)
                return;

            // Reset the color modification of the last TreeElement dragged over
            ResetColor();

            // Update dragged element
            DraggedOverElement = target;


            // Apply new warning color
            if (DraggedOverElement == null)
                TreeView.BackColor = Color.LightGreen;
            else
            {
                // Expend the treeView as the user drag on collapsed element to improve UX
                DraggedOverElement.Expand(); 

                if (draggedElement != null && DraggedOverElement.AllowDrop(draggedElement))
                    DraggedOverElement.BackColor = Color.LightGreen;
                else
                    DraggedOverElement.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// When entering the TreeView area, setup the TreeView.
        /// </summary>
        public void DragEnter()
        {
            DraggedOverElement = null;
            TreeView.SelectedNode = null;
            TreeView.BackColor = Color.LightGreen;
        }

        /// <summary>
        /// Reapply the default color of the previous DraggedOverElement.
        /// </summary>
        public void ResetColor()
        {
            if (DraggedOverElement == null) // If the dragged over element was the tree root
                TreeView.BackColor = Color.White;
            else
                DraggedOverElement.ApplyDefaultColor();
        }

        /// <summary>
        /// Remove a node from the TreeView
        /// </summary>
        /// <param name="removedElement"></param>
        public void Remove(TreeElement removedElement)
        {
            TreeView.Nodes.Remove(removedElement);
        }

        /// <summary>
        /// Set the Tree elements to be managed by this TreeManager, build the hierarchy and add them 
        /// to the treeView.
        /// <para />
        /// The elements should not be hierarchised yet and the order is not important. This method will
        /// sort them.
        /// <para />
        /// The array should contain the root element with a nodelevel of -1 where the all the elements at the root 
        /// level (NodeLevel of 0) should point there parent's id.
        /// </summary>
        /// <param name="treeElements"></param>
        public void SetTreeElements(TreeElement[]? treeElements)
        {
            // Refresh the treeView
            TreeView.Nodes.Clear();

            if (treeElements == null)
                return;

            Array.Sort(treeElements);

            // Define the root level as the lowest level.
            // The first element is ignored as it is the root element
            // used to specify the root childrens elements
            int rootLevel = treeElements[1].NodeLevel;
            int index = 2;

            // Add each elements with the same level as the root level
            // to the root of the TreeView and build the hierarchy recursively
            // for each of them.
            for (int i = 1; i < treeElements.Length; i++)
            {
                TreeElement rootElement = treeElements[i];

                if (rootElement.NodeLevel != rootLevel)
                    return;

                BuildHierarchy(rootElement, treeElements, index++); // recursive build of the hierarchy

                TreeView.Nodes.Add(rootElement);

                TreeView.Sort();
            }
        }

        /// <summary>
        /// Build the tree hierarchy by associating parents-children relationships.
        /// This method uses recursion on the children array to build the tree.
        /// <para />
        /// The index is used to prevent starting each time at the start of the array and
        /// reduce the delay of the method.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="children"></param>
        /// <param name="index"></param>
        public void BuildHierarchy(TreeElement parent, TreeElement[] children, int index)
        {

            for (int i = index; i < children.Length; i++)
            {
                TreeElement child = children[i];

                if (child.ParentId == parent.Id)
                {
                    // The interface check with (child is ICategory checkInterface) syntax did not work...
                    // This alternate works well at least.
                    ICategory? checkInterface = parent as ICategory;

                    if (checkInterface != null)
                    {
                        parent.Nodes.Add(child);
                        BuildHierarchy(child, children, index + 1);
                    }
                        
                }
            }
        }
    }
}