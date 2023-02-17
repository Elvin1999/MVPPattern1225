using MVPPattern.Model;
using MVPPattern.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPPattern
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public EventHandler<EventArgs> AddButtonClick { get; set; }
        public EventHandler<EventArgs> LoadButtonClick { get; set; }
        public EventHandler<EventArgs> SelectionChange { get; set; }
        public EventHandler<EventArgs> CarDoubleClick { get ; set ; }
        public List<Car> Cars
        {
            set
            {
                carListBox.DataSource = null;
                carListBox.DataSource = value;
            }
        }

        public string ModelText { get => modelTxtb.Text; set => modelTxtb.Text = value; }
        public string VendorText { get => vendortxtB.Text; set => vendortxtB.Text = value; }
        public string ColorText { get => colorTxtb.Text; set => colorTxtb.Text = value; }
        public string TransmissionText { get => transmissionTxtb.Text; set => transmissionTxtb.Text = value; }
        public string YearText { get => yearTxtb.Text; set => yearTxtb.Text = value; }
        public Car SelectedCar
        {
            get
            {
                return carListBox.SelectedItem as Car;
            }
        }


        private void addBtn_Click(object sender, EventArgs e)
        {
            AddButtonClick.Invoke(sender, e);
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            LoadButtonClick.Invoke(sender, e);
        }

        private void carListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectionChange.Invoke(sender, e);
        }

        private void carListBox_DoubleClick(object sender, EventArgs e)
        {
            CarDoubleClick.Invoke(sender, e);
        }
    }
}
