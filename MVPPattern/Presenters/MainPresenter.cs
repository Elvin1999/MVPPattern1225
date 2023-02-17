using MVPPattern.Data;
using MVPPattern.Model;
using MVPPattern.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPPattern.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly CarContext _db;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _db = new CarContext();

            _view.LoadButtonClick += ViewLoadButtonClick;

            _view.AddButtonClick += ViewAddButtonClick;

            _view.SelectionChange += ViewSelectionChange;
            _view.CarDoubleClick += ViewCarDoubleClick;
        }

        private void ViewCarDoubleClick(object sender, EventArgs e)
        {
            try
            {
                var car = _view.SelectedCar;
                var dialog = MessageBox.Show("Are you sure to delete ?", car.ToString(), MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    _db.Cars.Remove(car);
                    _db.SaveChanges();
                    var cars = _db.Cars.ToList();
                    _view.Cars = cars;
                }
            }
            catch (Exception)
            {


            }

            ClearViewFields();


        }

        private void ClearViewFields()
        {
            _view.ModelText = String.Empty;
            _view.VendorText = String.Empty;
            _view.YearText = String.Empty;
            _view.ColorText = String.Empty;
            _view.TransmissionText = String.Empty;
        }

        private void ViewSelectionChange(object sender, EventArgs e)
        {
            var car = _view.SelectedCar;
            if (car != null)
            {
                _view.ModelText = car.Model;
                _view.VendorText = car.Vendor;
                _view.ColorText = car.Color;
                _view.YearText = car.Year.ToString();
                _view.TransmissionText = car.Transmission;
            }
        }

        private void ViewAddButtonClick(object sender, EventArgs e)
        {
            var car = new Car
            {
                Model = _view.ModelText,
                Vendor = _view.VendorText,
                Year = int.Parse(_view.YearText),
                Color = _view.ColorText,
                Transmission = _view.TransmissionText
            };

            ClearViewFields();


            _db.Cars.Add(car);
            _db.SaveChanges();
        }

        private void ViewLoadButtonClick(object sender, EventArgs e)
        {
            var cars = _db.Cars.ToList();
            _view.Cars = cars;
        }
    }
}
