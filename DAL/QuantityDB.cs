using DTO;
using Serilog;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// This class is the DB access layer for quantity types and quantity measures.
    /// </summary>
    public static class QuantityDB
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of all quantity types or an empty list</returns>
        /// <exception cref="Exception"></exception>
        public static List<QuantityType> GetAllQuantityTypes()
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            List<QuantityType> list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, Name  
                                    FROM QuantityType;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<QuantityType>();

                    while (reader.Read())
                    {

                        QuantityType quantityType = new QuantityType(
                                reader.GetInt32(0), // Id
                                reader.GetString(1) // Name
                            );

                        list.Add(quantityType);
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the quantity types : {e}", e.Message);
                throw new Exception("Error while loading the quantity types.", e);
            }

            return list;
        }

        /// <summary>
        /// Get a quantity type by its Id.
        /// </summary>
        /// <param name="quantityTypeId"></param>
        /// <returns>Quantity type or null</returns>
        /// <exception cref="Exception"></exception>
        public static QuantityType? GetQuantityTypeById(int quantityTypeId)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            QuantityType? quantityType = null;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, Name  
                                    FROM QuantityType;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        quantityType = new QuantityType(
                                reader.GetInt32(0), // Id
                                reader.GetString(1) // Name
                            );
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the quantity type by Id : {e}", e.Message);
                throw new Exception("Error while loading the quantity type.", e);
            }

            return quantityType;
        }

        /// <summary>
        /// Get a base measur for the corresponding quantity type, retrieved by its Id.
        /// </summary>
        /// <param name="quantityTypeId"></param>
        /// <returns>Measure or null</returns>
        /// <exception cref="Exception"></exception>
        public static Measure? GetBaseMeasureFor(int quantityTypeId)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            Measure? measure = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // The measure with Amount 1 is considered the base measure
                    string query = @"SELECT Id, Name, Amount, QuantityTypeId   
                                    FROM QuantityMeasure 
                                    WHERE QuantityTypeId = @quantityTypeId 
                                    AND Amount = 1;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@quantityTypeId", quantityTypeId);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        measure = new Measure(
                                reader.GetInt32(0), // Id
                                reader.GetString(1), // Name
                                reader.GetDouble(2), // Amount
                                reader.GetInt32(3) // Quantity Type Id
                            );
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the base measure : {e}", e.Message);
                throw new Exception("Error while loading the base measure.", e);
            }

            return measure;
        }

        /// <summary>
        /// Get the list of measures for a quantity type.
        /// </summary>
        /// <param name="quantityTypeId"></param>
        /// <returns>List of measure</returns>
        /// <exception cref="Exception"></exception>
        public static List<Measure> GetMeasuresFor(int quantityTypeId)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            List<Measure> list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, Name, Amount, QuantityTypeId 
                                    FROM QuantityMeasure 
                                    WHERE QuantityTypeId = @quantityTypeId;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@quantityTypeId", quantityTypeId);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<Measure>();

                    while (reader.Read())
                    {

                        Measure quantityType = new Measure(
                                reader.GetInt32(0), // Id
                                reader.GetString(1), // Name
                                reader.GetDouble(2), // Amount
                                reader.GetInt32(3) // Quantity Type Id
                            );

                        list.Add(quantityType);
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the measures : {e}", e.Message);
                throw new Exception("Error while loading the measures.", e);
            }

            return list;
        }
    }
}



