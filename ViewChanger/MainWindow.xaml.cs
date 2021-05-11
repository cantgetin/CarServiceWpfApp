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
using ViewChanger.ViewModels;


namespace ViewChanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow C1;

        public void LoginComplete()
        {
            ChangeButtonsState();
            btnCars.Background = Brushes.PaleTurquoise;
            DataContext = new CarsViewModel();
        }
        public void ChangeButtonsState()
        {
            btnCars.IsEnabled = !btnCars.IsEnabled;
            btnClients.IsEnabled = !btnClients.IsEnabled;
            btnEmployees.IsEnabled = !btnEmployees.IsEnabled;
            btnServices.IsEnabled = !btnServices.IsEnabled;
            btnSettings.IsEnabled = !btnSettings.IsEnabled;
        }
        public MainWindow()
        {
            C1 = this;
            InitializeComponent();
            DataContext = new LoginViewModel();
            ChangeButtonsState();
        }

        //private void RedView_Clicked(object sender, RoutedEventArgs e)
        //{
        //    DataContext = new RedViewModel();
        //}

        //private void BlueView_Clicked(object sender, RoutedEventArgs e)
        //{
        //    DataContext = new BlueViewModel();
        //}

        //private void OrangeView_Clicked(object sender, RoutedEventArgs e)
        //{
        //    DataContext = new OrangeViewModel();
        //}

        private void btnServices_Clicked(object sender, RoutedEventArgs e)
        {
            btnSetDefaultColor();
            btnServices.Background = Brushes.PaleTurquoise;
            DataContext = new ServicesViewModel();
        }

        private void btnEmployees_Clicked(object sender, RoutedEventArgs e)
        {
            btnSetDefaultColor();
            btnEmployees.Background = Brushes.PaleTurquoise;
            DataContext = new EmployeesViewModel();
        }

        private void btnClients_Clicked(object sender, RoutedEventArgs e)
        {
            btnSetDefaultColor();
            btnClients.Background = Brushes.PaleTurquoise;
            DataContext = new ClientViewModel();
        }

        private void btnCars_Clicked(object sender, RoutedEventArgs e)
        {
            btnSetDefaultColor();
            btnCars.Background = Brushes.PaleTurquoise;
            DataContext = new CarsViewModel();
        }

        public void btnSetDefaultColor()
        {
            btnServices.Background = Brushes.LightGray;
            btnEmployees.Background = Brushes.LightGray;
            btnClients.Background = Brushes.LightGray;
            btnCars.Background = Brushes.LightGray;
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
