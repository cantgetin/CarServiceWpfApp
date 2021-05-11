using Microsoft.Win32;
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
using System.Windows.Shapes;
using ViewChanger.Objects;
using ViewChanger.Repositories;

namespace ViewChanger.Views
{
    /// <summary>
    /// Логика взаимодействия для CarAddWindow.xaml
    /// </summary>
    public partial class CarAddWindow : Window
    {
        protected Car _addedCar;
        //protected int _editedIndex;
        public CarAddWindow()
        {
            _addedCar = new Car();
            InitializeComponent();
            ClientRepository.CreateInstance();
            ServiceRepository.CreateInstance();
            EmployeeRepository.CreateInstance();

            var lol = ClientRepository.GetAutoParts();
            foreach (var item in lol)
            {
                comboBoxOwner.Items.Add("ID:" + item.Id + " | " + item.Name + " " + item.Surname);
            }

            var lol2 = ServiceRepository.GetAutoParts();
            foreach (var item in lol2)
            {
                comboBoxService.Items.Add("ID:" + item.Id + " | " + item.Title);
            }

            var lol3 = EmployeeRepository.GetAutoParts();
            foreach (var item in lol3)
            {
                comboBoxEmployee.Items.Add("ID:" + item.Id + " | " + item.Name + " " + item.Surname);
            }

        }

        private void Btn_Accept(object sender, RoutedEventArgs e)
        {
            _addedCar.Manufacturer = textBoxManufacturer.Text;
            _addedCar.Model = textBoxModel.Text;
            _addedCar.Year = int.Parse(textBoxYear.Text);
            _addedCar.Fault = textBoxFault.Text;
            _addedCar.ArrivalDate = (DateTime)ArrivalDatePicker.SelectedDate;
            _addedCar.DepartureDate = (DateTime)DepartureDatePicker.SelectedDate;

            _addedCar.OwnerId = comboBoxOwner.SelectedIndex;
            _addedCar.ServiceID = comboBoxService.SelectedIndex;
            _addedCar.EmployeeID = comboBoxEmployee.SelectedIndex;
            CarRepository.AddElement(_addedCar);
            //CarsView.Ref
            this.Close();
        }

        private void Btn_ChangeImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(op.FileName));
                _addedCar.ImagePath = op.FileName.ToString();
            }
        }
    }
}
