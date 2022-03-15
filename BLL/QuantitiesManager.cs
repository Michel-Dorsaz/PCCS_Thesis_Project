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
        /// By example, the basic measure for Weight is 'g' and for Volume is 'L'.
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
        /// <para/>
        /// Throws an exception if the measures do not belong to the same quantity type.
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>Converted quantity as double</returns>
        /// <exception cref="Exception"></exception>
        public static double ConvertMeasureAmount(double quantity, Measure source, Measure target)
        {
            if (source.QuantityTypeId == target.QuantityTypeId)
                return (quantity * source.Amount) / target.Amount;
            else
                throw new Exception("Cannot convert from " + source.Name + " to " + target.Name + " : the measures need to belong to the same quantity type !");
        }
    }
}
