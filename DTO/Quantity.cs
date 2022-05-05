namespace DTO
{
    public class Quantity
    {
        private double _Amount;
        public double Amount
        {
            get
            {
                return Math.Round(_Amount, 2);
            }
            set
            {
                _Amount = value;
            }
        }
        public Measure Measure { get; set; }

        public Quantity(double amount, Measure measure)
        {
            Amount = amount;
            Measure = measure;
        }
    }
}
