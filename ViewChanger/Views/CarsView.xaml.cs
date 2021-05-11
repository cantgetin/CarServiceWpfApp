using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ViewChanger.Objects;
using ViewChanger.Repositories;

namespace ViewChanger.Views
{
    /// <summary>
    /// Логика взаимодействия для CarsView.xaml
    /// </summary>
    public partial class CarsView : UserControl
    {
        protected static ObservableCollection<Car> _cars;
        protected static ObservableCollection<Client> _clients;
        protected static ObservableCollection<Employee> _employees;
        //protected static int selectedCar;
        protected static Client previousClient;
        protected static Employee previousEmployee;
        public CarsView()
        {
            CarRepository.CreateInstance();
            ClientRepository.CreateInstance();
            EmployeeRepository.CreateInstance();
            InitializeComponent();
            _cars = CarRepository.GetRepository();
            _clients = ClientRepository.GetAutoParts();
            _employees = EmployeeRepository.GetAutoParts();
            partsList.ItemsSource = _cars;
        }

        private void partsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car selectedCar = (Car)partsList.SelectedItem;
            if (selectedCar != null)
            {
                Client selectedCarOwner = ClientRepository.GetClientById(selectedCar.OwnerId);
                clientList.Items.Remove(previousClient);
                clientList.Items.Add(selectedCarOwner);
                previousClient = selectedCarOwner;

                Employee selectedCarEmployee = EmployeeRepository.GetClientById(selectedCar.EmployeeID);
                employeeList.Items.Remove(previousEmployee);
                employeeList.Items.Add(selectedCarEmployee);
                previousEmployee = selectedCarEmployee;
            }

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (partsList.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали автомобиль!");
            }
            else
            {
                int test = Convert.ToInt32(partsList.SelectedItem.GetType().GetProperty("Id").GetValue(partsList.SelectedItem));
                var d = CarRepository.GetElementByIndex(test);
                string message = "Вы точно хотите удалить из списка " + d.Manufacturer.ToString() + "?";
                string caption = "Уведомление";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show(message, caption, buttons, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    CarRepository.DeleteElementByIndex(test);
                }
            }
            clientList.Items.Clear();
            employeeList.Items.Clear();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (partsList.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали автомобиль!");
            }
            else
            {
                int test = Convert.ToInt32(partsList.SelectedItem.GetType().GetProperty("Id").GetValue(partsList.SelectedItem));
                var d = CarRepository.GetElementByIndex(test);
                int ind = partsList.SelectedIndex;
                EditWindow win = new EditWindow(d, partsList.SelectedIndex);
                win.ShowDialog();
                partsList.Items.Refresh();
                employeeList.Items.Refresh();
                clientList.Items.Refresh();
                partsList.SelectedIndex = ind;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            CarAddWindow win = new CarAddWindow();
            win.ShowDialog();
            partsList.Items.Refresh();
        }

        // Функция выполняет код при закрытии окна
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //AutoPartRepository.Serialize();
        }

        private void BtnMore_Click(object sender, RoutedEventArgs e)
        {
            if (partsList.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали автомобиль!");
            }
            else
            {
                var d = CarRepository.GetElementByIndex(partsList.SelectedIndex);
                CarDetails win = new CarDetails(d);
                win.ShowDialog();
                partsList.Items.Refresh();
            }
        }

    }
}

