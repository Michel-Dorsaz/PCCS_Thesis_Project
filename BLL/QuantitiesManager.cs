using DAL;
using DTO;

namespace BLL
{

    /// <summary>
    /// This class is the business logic for quantity types and measures
    /// </summary>
    public static class QuantitiesManager
    {
        /// <summary>
        /// The maximum value allowed for a quantity.
        /// </summary>
        public const double MAX_VALUE = 100000;

        /// <summary>
        /// The minimum value allowed for a quantity.
        /// </summary>
        public const double MIN_VALUE = 0;


        /// <summary>
        /// Get a quantity type by its DB related Id.
        /// </summary>
        /// <param name="quantityTypeId"></param>
        /// <returns>Quantity type or null</returns>
        public static QuantityType? GetQuantityTypeById(int quantityTypeId)
        {
            try
            {
                return QuantityDB.GetQuantityTypeById(quantityTypeId);
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
                return null;
            }
              
        }

        /// <summary>
        /// Get a list of all existing quantity types.
        /// </summary>
        /// <returns>List of quantityTypes or null</returns>
        public static List<QuantityType>? GetAllQuantityTypes()
        {
            try
            {
                return QuantityDB.GetAllQuantityTypes();
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
                return null;
            }
                
        }

        /// <summary>
        /// Get the base measure for a quantity type.
        /// <para/>
        /// By example, the basic measure for Weight is 'g' and for Volume is 'ml'.
        /// </summary>
        /// <param name="quantyTypeId"></param>
        /// <returns>Measure or null</returns>
        public static Measure? GetBaseMeasureFor(int quantyTypeId)
        {
            try
            {
                return QuantityDB.GetBaseMeasureFor(quantyTypeId);

            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
                return null;
            }
        }

        /// <summary>
        /// Get a measure by its name
        /// </summary>
        /// <param name="measureName"></param>
        /// <returns>Measure or null</returns>
        public static Measure? GetMeasureByName(string measureName)
        {
            try
            {
                return QuantityDB.GetMeasureByName(measureName);

            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
                return null;
            }
        }

        /// <summary>
        /// Get the list of measure that belongs to a quantity type, retrieved by the
        /// Id of the quantity type.
        /// </summary>
        /// <param name="quantityTypeId"></param>
        /// <returns>List of measure or null</returns>
        public static List<Measure>? GetMeasuresFor(int quantityTypeId)
        {
            try
            {
                return QuantityDB.GetMeasuresFor(quantityTypeId);

            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
                return null;
            }
        }

        /// <summary>
        /// Convert a quantity from a measure to another.
        /// <para/>
        /// ConvertMeasureAmount(1000, g, kg) converts 1000g to kg, which return 1.
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>Converted quantity as double</returns>
        public static double ConvertMeasureAmount(double quantity, Measure source, Measure target)
        {

            return (quantity * source.AmountInGramme) / target.AmountInGramme;
        }
    }
}
