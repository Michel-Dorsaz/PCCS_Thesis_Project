namespace DTO
{
    public class Quantity
    {
        public double Amount { get; set; }
        public Measure Measure { get; set; }

        public Quantity(double amount, Measure measure)
        {
            Amount = amount;
            Measure = measure;
        }
    }
}
