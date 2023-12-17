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
    /// Interaction logic for CarListItemView.xaml
    /// </summary>
    public partial class CarListItemView :UserControl
    {
        public CarListItemView()
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
                this.textBlockName.Text = car.Name;
                this.textBlockYear.Text = car.Year;
                string uriStr = string.Format(@"/Resources/Logo/{0}.jpg",car.Automaker);
                this.imageLogo.Source = new BitmapImage(new Uri(uriStr, UriKind.Relative));
            
            }
        }

    }
  
}
