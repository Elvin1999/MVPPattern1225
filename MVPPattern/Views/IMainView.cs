using MVPPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPPattern.Views
{
    public interface IMainView
    {
        EventHandler<EventArgs> AddButtonClick { get; set; }
        EventHandler<EventArgs> LoadButtonClick { get; set; }
        EventHandler<EventArgs> SelectionChange { get; set; }
        EventHandler<EventArgs> CarDoubleClick { get; set; }

        Car SelectedCar { get; }
        List<Car> Cars { set; }
        string ModelText { get; set; }
        string VendorText { get; set; }
        string ColorText { get; set; }
        string TransmissionText { get; set; }
        string YearText { get; set; }
    }
}
