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
    /// Логика взаимодействия для PersonEditWindow.xaml
    /// </summary>
    public partial class PersonEditWindow : Window
    {
        protected Client _editedClient;
        protected Employee _editedEmployee;
        protected int person;
        protected int indexG;
        //protected int _editedIndex;
        public PersonEditWindow(int type, int index, Client d)
        {
            _editedClient = new Client();
            person = type;
            indexG = index;
            InitializeComponent();
            textBoxName.Text = d.Name;
            textBoxSurname.Text = d.Surname;
            textBoxMiddlename.Text = d.Middlename;
            textBoxPhoneNumber.Text = d.PhoneNumber;
            birthDatePicker.SelectedDate = d.DateOfBirth;
            textBoxAddress.Text = d.Address;
            if (d.ImagePath != null) image.Source = new BitmapImage(new Uri(d.ImagePath));
            _editedClient.ImagePath = d.ImagePath;
            _editedClient.Id = d.Id;
        }

        public PersonEditWindow(int type, int index, Employee d)
        {
            _editedEmployee = new Employee();
            person = type;
            indexG = index;
            InitializeComponent();
            textBoxName.Text = d.Name;
            textBoxSurname.Text = d.Surname;
            textBoxMiddlename.Text = d.Middlename;
            textBoxPhoneNumber.Text = d.PhoneNumber;
            birthDatePicker.SelectedDate = d.DateOfBirth;
            textBoxAddress.Text = d.Address;
            if (d.ImagePath != null) image.Source = new BitmapImage(new Uri(d.ImagePath));
            _editedEmployee.ImagePath = d.ImagePath;
            _editedEmployee.Id = d.Id;
        }

        private void Btn_Accept(object sender, RoutedEventArgs e)
        {
            if (person == 1)
            {
                _editedClient.Name = textBoxName.Text;
                _editedClient.Surname = textBoxSurname.Text;
                _editedClient.Middlename = textBoxMiddlename.Text;
                _editedClient.PhoneNumber = textBoxPhoneNumber.Text;
                _editedClient.Address = textBoxAddress.Text;
                _editedClient.DateOfBirth = (DateTime)birthDatePicker.SelectedDate;
                
                
                ClientRepository.ChangeElement(indexG, _editedClient);
            }
            else if (person == 2)
            {
                _editedEmployee.Name = textBoxName.Text;
                _editedEmployee.Surname = textBoxSurname.Text;
                _editedEmployee.Middlename = textBoxMiddlename.Text;
                _editedEmployee.PhoneNumber = textBoxPhoneNumber.Text;
                _editedEmployee.Address = textBoxAddress.Text;
                _editedEmployee.DateOfBirth = (DateTime)birthDatePicker.SelectedDate;
                
                EmployeeRepository.ChangeElement(indexG, _editedEmployee);
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
                if (person == 1) _editedClient.ImagePath = op.FileName.ToString();
                else if (person == 2) _editedEmployee.ImagePath = op.FileName.ToString();
            }
        }
    }
}
