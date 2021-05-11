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
    /// Логика взаимодействия для CarDetails.xaml
    /// </summary>
    public partial class CarDetails : Window
    {
        protected Car _detailedCar;
        public CarDetails(Car d)
        {
            _detailedCar = d;
            InitializeComponent();
            ServiceRepository.CreateInstance();
            CarTitle.Content = d.Manufacturer + " " + d.Model;
            CarYear.Content = "Год выпуска: " + d.Year;
            CarOwner.Content = "Владелец: " + ClientRepository.GetAutoPart(d.OwnerId).Surname + " " + ClientRepository.GetAutoPart(d.OwnerId).Name + " " + ClientRepository.GetAutoPart(d.OwnerId).Middlename;
            CarServiceTitle.Content = "Предоставляемая услуга: " + ServiceRepository.GetClientById(d.ServiceID).Title;
            CarEmployee.Content = "Работник: " + EmployeeRepository.GetClientById(d.EmployeeID).Name +" "+ EmployeeRepository.GetClientById(d.EmployeeID).Surname;
            CarArrivalDate.Content = "Автомобиль поступил: " + d.ArrivalDate;
            CarDepartureDate.Content = "Автомобиль должен быть сделан к: " + d.ArrivalDate;
            CarFault.Content = "Заявленная неисправность: " + d.Fault;
            if (d.ImagePath != null) image.Source = new BitmapImage(new Uri(d.ImagePath));
        }


        /*protected Car _editedCar;
        protected int _editedIndex;
        public EditWindow(Car part, int index)
        {
            _editedCar = part;
            _editedIndex = index;
            InitializeComponent();
            textBoxManufacturer.Text = part.Manufacturer.ToString();
            textBoxModel.Text = part.Model.ToString();
            textBoxYear.Text = part.Year.ToString();
            if (part.ImagePath != null) image.Source = new BitmapImage(new Uri(part.ImagePath));
        }

        private void Btn_Accept(object sender, RoutedEventArgs e)
        {
            _editedCar.Manufacturer = textBoxManufacturer.Text;
            _editedCar.Model = textBoxModel.Text;
            _editedCar.Year = int.Parse(textBoxYear.Text);
            CarRepository.ChangeElement(_editedIndex, _editedCar);
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
        }*/
    }
}
