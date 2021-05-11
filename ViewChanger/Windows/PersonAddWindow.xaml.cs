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

namespace ViewChanger.Windows
{
    /// <summary>
    /// Логика взаимодействия для PersonAddWindow.xaml
    /// </summary>
    public partial class PersonAddWindow : Window
    {
        protected Client _addedClient;
        protected Employee _addedEmployee;
        protected int person;
        //protected int _editedIndex;
        public PersonAddWindow(int type)
        {
            _addedClient = new Client();
            _addedEmployee = new Employee();
            person = type;
            InitializeComponent();
        }

        private void Btn_Accept(object sender, RoutedEventArgs e)
        {
            if (person == 1)
            {
                _addedClient.Name = textBoxName.Text;
                _addedClient.Surname = textBoxSurname.Text;
                _addedClient.Middlename = textBoxMiddlename.Text;
                _addedClient.PhoneNumber = textBoxPhoneNumber.Text;
                _addedClient.Address = textBoxAddress.Text;
                _addedClient.DateOfBirth = (DateTime)birthDatePicker.SelectedDate;
                ClientRepository.AddPart(_addedClient);
            }
            else if (person == 2)
            {
                _addedEmployee.Name = textBoxName.Text;
                _addedEmployee.Surname = textBoxSurname.Text;
                _addedEmployee.Middlename = textBoxMiddlename.Text;
                _addedEmployee.PhoneNumber = textBoxPhoneNumber.Text;
                _addedEmployee.Address = textBoxAddress.Text;
                _addedEmployee.DateOfBirth = (DateTime)birthDatePicker.SelectedDate;
                EmployeeRepository.AddPart(_addedEmployee);
            }
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
                if (person == 1) _addedClient.ImagePath = op.FileName.ToString();
                else if (person == 2) _addedEmployee.ImagePath = op.FileName.ToString();
            }
        }
    }
}
