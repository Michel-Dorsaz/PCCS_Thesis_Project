using DTO;

namespace UI
{

    /// <summary>
    /// This interface determine the contracts of the UserControl displaying the selected TreeElement of the TreeView.
    /// </summary>
    public interface ISelection
    {

        /// <summary>
        /// Called to save the current displayed TreeElement.
        /// </summary>
        void Save();

        /// <summary>
        /// Called to update the current displayed TreeElement.
        /// </summary>
        /// <param name="node"></param>
        void Update(TreeElement node);
    }
}
