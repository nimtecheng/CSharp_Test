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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialCarList();
        }
        private void InitialCarList()
        {
            List<Car> carlist = new List<Car>()
            {
                new Car(){ Automaker="Tesla",Name="Model3",Year="2017",TopMileage="220"},
                new Car(){ Automaker="Tesla",Name="ModelX",Year="2012",TopMileage="565"},
                new Car(){ Automaker="Tesla",Name="ModelY",Year="2019",TopMileage="505"},
                new Car(){ Automaker="Tesla",Name="ModelS",Year="2012",TopMileage="647"}

            };
            foreach (Car car in carlist)
            {
                CarListItemView view = new CarListItemView();
                view.Car = car;
                listBoxCars.Items.Add(view);
            }
        
        }
        private void listBoxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarListItemView view = e.AddedItems[0] as CarListItemView;
            if (view != null)
                detailView.Car = view.Car;
        }
    }


    public class Car
    {
        public string Automaker { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string TopMileage { get; set; }

    }
}
