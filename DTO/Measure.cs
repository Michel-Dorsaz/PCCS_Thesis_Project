namespace DTO
{
    /// <summary>
    /// This class represents a quantity measure such as kg, g, mg, L, ml, cl...
    /// </summary>
    public class Measure
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// The ratio between the basic measure and this one, usefull to converts measure quantities.
        /// <para/>
        /// The basic measure has an amount of 1.
        /// <para/>
        /// By exemple, Kg has an amount of 1000 because the basic measure for weight is g.
        /// </summary>
        public double Amount { get; set; }

        public int QuantityTypeId { get; set; }

        public Measure(int id, string name, double amount, int quantityTypeId)
        {
            Id = id;
            Name = name;
            Amount = amount;
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
