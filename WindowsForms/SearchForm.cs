using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsForms
{
    /// <summary>
    /// Форма поиска
    /// </summary>
    public partial class SearchForm : Form
    {
        /// <summary>
        /// Datagried из первой формы
        /// </summary>
        private DataGridView _dataGridView;

        /// <summary>
        /// Текущий список объектов из первой формы
        /// </summary>
        private BindingList<VehicleBase> _vehiclesMas;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dataGridView"></param>
		/// <param name="vehicles"></param>
		public SearchForm(DataGridView dataGridView, BindingList<VehicleBase> vehicles)
        {
            InitializeComponent();
            this._dataGridView = dataGridView;
            _vehiclesMas = vehicles;
        }
        /// <summary>
        /// Событие при загрузке формы поиска
        /// </summary>
        private void SearchForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
        /// <summary>
        /// Событие при нажатии на кнопку поиска
        /// </summary>
        private void SearchVehicle(object sender, EventArgs e)
        {
            try
            {
                _dataGridView.ClearSelection();
                if (TypeTextBox.Text == ""
                    && NameTextBox.Text == ""
                    && SpeedTextBox.Text == ""
                    && ConsumptionBox1.Text == "")
                {
                    MessageBox.Show("Search parameters are empty");
                    return;
                }
                bool isSmthFound = false;
                int count = 0;
                foreach (VehicleBase vehicle in _vehiclesMas)
                {
                    if (!matchCheckBox.Checked)
                    {

                        if ((vehicle.TypeOfVehicle.ToString().Contains(TypeTextBox.Text)
                                && TypeTextBox.Text != "") ||
                            (vehicle.Name.ToString().Contains(NameTextBox.Text)
                                && NameTextBox.Text != "") ||
                            (vehicle.OilConsumption.ToString().Contains(ConsumptionBox1.Text)
                                && ConsumptionBox1.Text != "") ||
                            (vehicle.Speed.ToString().Contains(SpeedTextBox.Text)
                                && SpeedTextBox.Text != ""))
                        {
                            _dataGridView.Rows[count].Selected = true;
                            isSmthFound = true;
                        }
                        count++;
                    }
                    else
                    {
                        if ((vehicle.TypeOfVehicle.ToString() == TypeTextBox.Text 
							&& TypeTextBox.Text != "") ||
                           (vehicle.OilConsumption.ToString() == ConsumptionBox1.Text 
						   && ConsumptionBox1.Text != "") ||
                            (vehicle.Name.ToString() == NameTextBox.Text 
							&& NameTextBox.Text != "") ||
                        (vehicle.Speed.ToString() == SpeedTextBox.Text 
						&& SpeedTextBox.Text != ""))
                        {
                            _dataGridView.Rows[count].Selected = true;
                            isSmthFound = true;
                        }
                        count++;
                    }
                }
                if (!isSmthFound)
                {
                    MessageBox.Show("Nothing is found");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
