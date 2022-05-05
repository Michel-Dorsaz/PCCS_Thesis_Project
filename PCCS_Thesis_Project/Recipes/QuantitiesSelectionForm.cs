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
                dataGridView.Rows.Add(index+1, tuple.Item1.Text + "\r\nTest", tuple.Item2.Amount); // Add index, name and amount
                
                // Add ComboBox items to the last cell
                DataGridViewRow row = dataGridView.Rows[index];
                ((DataGridViewComboBoxCell)row.Cells[3]).DataSource = QuantitiesManager.GetMeasuresFor(tuple.Item1.QuantityTypeId);
                ((DataGridViewComboBoxCell) row.Cells[3]).DisplayMember = "Name";
                ((DataGridViewComboBoxCell) row.Cells[3]).Value = tuple.Item2.Measure.Name;
                index++;
            }

            UpdateNutiments();

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
                double quantity = 0;


                if (dataGridView.Rows[e.RowIndex].Cells[2].Value is string)
                {
                    try
                    {
                        quantity = double.Parse((string) dataGridView.Rows[e.RowIndex].Cells[2].Value);
                    }
                    catch(FormatException)
                    {
                        MessagesManager.InfoMessage("Value " + dataGridView.Rows[e.RowIndex].Cells[2].Value + " incorrect !\r\n" +
                        "A quantity must be a number !\r\n(Decimal allowed. Use ',' as separator, example: 1,01)", MessageBoxButtons.OK);

                        // Reset the original value if format error
                        dataGridView.Rows[e.RowIndex].Cells[2].Value = Ingredients[index].Item2.Amount;
                        return;
                    }
                    
                }
                else
                {
                    quantity = (double)dataGridView.Rows[e.RowIndex].Cells[2].Value;
                    
                }

                if (quantity > QuantitiesManager.MAX_VALUE || quantity <= QuantitiesManager.MIN_VALUE)
                {
                    MessagesManager.InfoMessage("Value " + quantity + " incorrect !\r\n"
                        + "A quantity must be greater than " + QuantitiesManager.MIN_VALUE
                        + " and lower or equal to " + QuantitiesManager.MAX_VALUE, MessageBoxButtons.OK);

                    // Reset the original value
                    dataGridView.Rows[e.RowIndex].Cells[2].Value = Ingredients[index].Item2.Amount;
                }
                else
                {
                    index = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value - 1;
                    Ingredients[index].Item2.Amount = quantity;
                }

                UpdateNutiments();

            }
            if(e.ColumnIndex == 3)
            {
                
                DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell) dataGridView.Rows[e.RowIndex].Cells[3];
                int ingredientIndex = (int) dataGridView.Rows[e.RowIndex].Cells[0].Value-1;
                int ItemIndex = cbCell.Items.IndexOf(cbCell.Value.ToString());

                Ingredients[ingredientIndex].Item2.Measure = (Measure) cbCell.Items[ItemIndex];

                UpdateNutiments();
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
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpdateNutiments()
        {
            double grammes = 0, glucid = 0, lipid = 0, protein = 0;

            foreach (Tuple<Ingredient, Quantity> tuple in Ingredients)
            {
                double quantity = tuple.Item2.Amount * tuple.Item2.Measure.AmountInGramme;
                grammes += quantity;
                glucid += tuple.Item1.Glucid * quantity;
                lipid += tuple.Item1.Lipid * quantity;
                protein += tuple.Item1.Protein * quantity;
            }

            glucid = (Math.Round(glucid / grammes, 2));
            lipid = (Math.Round(lipid / grammes, 2));
            protein = (Math.Round(protein / grammes, 2));

            double upperThreshold1 = 1+IngredientsManager.WARNING_THRESHOLD_1;
            double lowerThreshold1 = 1-IngredientsManager.WARNING_THRESHOLD_1;

            double upperThreshold2 = 1+IngredientsManager.WARNING_THRESHOLD_2;
            double lowerTthreshold2 = 1-IngredientsManager.WARNING_THRESHOLD_2;



            if (glucid < IngredientsManager.GLUCID_THRESHOLD * lowerThreshold1 || glucid > IngredientsManager.GLUCID_THRESHOLD * upperThreshold1)
                labelGlucidValue.BackColor = Color.Orange;
            if (glucid < IngredientsManager.GLUCID_THRESHOLD * lowerTthreshold2 || glucid > IngredientsManager.GLUCID_THRESHOLD * upperThreshold2)
                labelGlucidValue.BackColor = Color.Red;

            if (lipid < IngredientsManager.LIPID_THRESHOLD * lowerThreshold1 || lipid > IngredientsManager.LIPID_THRESHOLD * upperThreshold1)
                labelLipidValue.BackColor = Color.Orange;
            if (lipid < IngredientsManager.LIPID_THRESHOLD * lowerTthreshold2 || lipid > IngredientsManager.LIPID_THRESHOLD * upperThreshold2)
                labelLipidValue.BackColor = Color.Red;

            if (protein < IngredientsManager.PROTEIN_THRESHOLD * lowerThreshold1 || protein > IngredientsManager.PROTEIN_THRESHOLD * upperThreshold1)
                labelProteinValue.BackColor = Color.Orange;
            if (protein < IngredientsManager.PROTEIN_THRESHOLD * lowerTthreshold2 || protein > IngredientsManager.PROTEIN_THRESHOLD * upperThreshold2)
                labelProteinValue.BackColor = Color.Red;


            labelGlucidValue.Text = glucid.ToString();
            labelLipidValue.Text = lipid.ToString();
            labelProteinValue.Text = protein.ToString();

        }
    }
}
