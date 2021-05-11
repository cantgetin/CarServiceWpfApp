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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        protected Car _editedCar;
        protected int _editedIndex;
        public EditWindow(Car part, int index)
        {
            _editedCar = part;
            _editedIndex = index;
            InitializeComponent();
            textBoxManufacturer.Text = part.Manufacturer.ToString();
            textBoxModel.Text = part.Model.ToString();
            textBoxYear.Text = part.Year.ToString();
            textBoxFault.Text = part.Fault.ToString();
            ClientRepository.CreateInstance();
            ServiceRepository.CreateInstance();
            EmployeeRepository.CreateInstance();
            comboBoxOwner.SelectedIndex = part.OwnerId;
            comboBoxService.SelectedIndex = part.ServiceID;
            comboBoxEmployee.SelectedIndex = part.EmployeeID;
            ArrivalDatePicker.SelectedDate = part.ArrivalDate;
            DepartureDatePicker.SelectedDate = part.DepartureDate;

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

            if (part.ImagePath != null) image.Source = new BitmapImage(new Uri(part.ImagePath));
        }

        private void Btn_Accept(object sender, RoutedEventArgs e)
        {
            _editedCar.Manufacturer = textBoxManufacturer.Text;
            _editedCar.Model = textBoxModel.Text;
            _editedCar.Year = int.Parse(textBoxYear.Text);
            _editedCar.Fault = textBoxFault.Text;
            _editedCar.ArrivalDate = (DateTime)ArrivalDatePicker.SelectedDate;
            _editedCar.DepartureDate = (DateTime)DepartureDatePicker.SelectedDate;

            _editedCar.OwnerId = comboBoxOwner.SelectedIndex;
            _editedCar.ServiceID = comboBoxService.SelectedIndex;
            _editedCar.EmployeeID = comboBoxEmployee.SelectedIndex;
            _editedCar.ServiceTitle = ServiceRepository.GetClientById(_editedCar.ServiceID).Title;
            CarRepository.ChangeElement(_editedIndex, _editedCar);
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
                _editedCar.ImagePath = op.FileName.ToString();
            }
        }
    }
}
