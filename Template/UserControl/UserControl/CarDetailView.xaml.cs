using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControlExample
{
    /// <summary>
    /// Interaction logic for CarDetailView.xaml
    /// </summary>
    public partial class CarDetailView : UserControl
    {
        public CarDetailView()
        {
            InitializeComponent();
        }


        private Car car;

        public Car Car
        {
            get { return car; }
            set
            { 
                car = value;
                textBlockName.Text = car.Name;
                textBlockYear.Text = car.Year;
                textBlockTopMileage.Text = car.TopMileage;
                textBlockAutomaker.Text = car.Automaker;
                string uriStr = string.Format(@"/Resources/Image/{0}.jpg", car.Name);
                imagePhoto.Source = new BitmapImage(new Uri(uriStr, UriKind.Relative));
            }
        }

    }
}
