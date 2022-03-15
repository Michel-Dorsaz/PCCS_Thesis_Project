namespace DTO
{
    /// <summary>
    /// This class represents a quantity type such as weight, volume, unit...
    /// </summary>
    public class QuantityType
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public QuantityType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
