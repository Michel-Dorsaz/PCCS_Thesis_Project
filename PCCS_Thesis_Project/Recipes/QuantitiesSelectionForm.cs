using BLL;
using DTO;
using Serilog;

namespace UI.Recipes
{
    /// <summary>
    /// This Form is used to set the quantities for a selection of ingredients.
    /// </summary>
    public partial class QuantitiesSelectionForm : Form
    {
        public List<Tuple<Ingredient, Quantity>> Ingredients { get; set; }

        public QuantitiesSelectionForm(List<Tuple<Ingredient, Quantity>> ingredients)
        {
            InitializeComponent();

            Ingredients = ingredients;

            LoadData(ingredients);
        }

        private void LoadData(List<Tuple<Ingredient, Quantity>> ingredients)
        {
                 
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Dictionary<int, Tuple<Ingredient, Quantity>> data = new Dictionary<int, Tuple<Ingredient, Quantity>>(ingredients.Count);

            int index = 0;

            // Create the DataGridView rows for each ingredients

            foreach (Tuple<Ingredient, Quantity> tuple in ingredients)
            {
                dataGridView.Rows.Add(index, tuple.Item1.Text + "\r\nTest", tuple.Item2.Amount); // Add index, name and amount
                
                // Add ComboBox items to the last cell
                DataGridViewRow row = dataGridView.Rows[index];
                ((DataGridViewComboBoxCell)row.Cells[3]).DataSource = QuantitiesManager.GetMeasuresFor(tuple.Item1.QuantityTypeId);
                ((DataGridViewComboBoxCell) row.Cells[3]).DisplayMember = "Name";
                ((DataGridViewComboBoxCell) row.Cells[3]).Value = tuple.Item2.Measure.Name;
                index++;
            }

            dataGridView.CellEndEdit += new DataGridViewCellEventHandler(Cell_OnEndEdit);
        }

        /// <summary>
        /// This method ensure the input values format is respected and save the modification inside their corresponding
        /// ingredients.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cell_OnEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            // Modification on column 2 (Quantity) must be of type double
            if (e.ColumnIndex == 2)
            {
                int index = 0;
                try
                {
                    double quantity = double.Parse((string)dataGridView.Rows[e.RowIndex].Cells[2].Value);
                    index = (int) dataGridView.Rows[e.RowIndex].Cells[0].Value;
                    Ingredients[index].Item2.Amount = quantity;
                }
                catch (Exception ex)
                {
                    Log.Information("QuantitiesSelectionPage - on cell edit error : {e}", ex.Message);
                    MessagesManager.WarningMessage("Number format only !", MessageBoxButtons.OK);

                    // Reset the original value if format error
                    dataGridView.Rows[e.RowIndex].Cells[2].Value = Ingredients[index].Item2.Amount;
                }
            }
            if(e.ColumnIndex == 3)
            {
                
                DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell) dataGridView.Rows[e.RowIndex].Cells[3];
                int ingredientIndex = (int) dataGridView.Rows[e.RowIndex].Cells[0].Value;
                int ItemIndex = cbCell.Items.IndexOf(cbCell.Value.ToString());

                Ingredients[ingredientIndex].Item2.Measure = (Measure) cbCell.Items[ItemIndex];
            }
        }

        /// <summary>
        /// This method is raised when the user click on the continue button.
        /// It close the forms with Dialogresult continue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonValue_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Continue;
            Close();
        }

        /// <summary>
        /// This method is raised when the user click on the cancel button.
        /// It close the forms with Dialogresult cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
