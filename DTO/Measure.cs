namespace DTO
{
    /// <summary>
    /// This class represents a quantity measure such as kg, g, mg, L, ml, cl...
    /// </summary>
    public class Measure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AmountInGramme { get; set; }

        public int QuantityTypeId { get; set; }

        public Measure(int id, string name, double amount, int quantityTypeId)
        {
            Id = id;
            Name = name;
            AmountInGramme = amount;
            QuantityTypeId = quantityTypeId;
        }

        /// <summary>
        /// Override of the Equals method used to allow the method IndexOf() of a DataGridViewCell.Item to 
        /// retrieve the index of an item by its value, only represented as a string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if(obj is string)
                return ((string) obj).Equals(Name);

            return base.Equals(obj); ;
        }
    }
}
