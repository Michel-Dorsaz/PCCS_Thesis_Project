namespace DTO.Interfaces
{
    /// <summary>
    /// Interface defining the contracts of a category.
    /// </summary>
    public interface ICategory
    {
        /// <summary>
        /// This method checks if a TreeElement contains another one in is children or the children of
        /// its children.
        /// <para />
        /// Returns true if the parent contains the potential child, false otherwise.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="potentialChild"></param>
        /// <returns></returns>
        bool Contains(TreeElement parent, TreeElement potentialChild);
    }
}
