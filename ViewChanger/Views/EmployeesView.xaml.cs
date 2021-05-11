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
using ViewChanger.Windows;

namespace ViewChanger.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : UserControl
    {
        private void clientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        protected static ObservableCollection<Car> _cars;
        protected static ObservableCollection<Client> _clients;
        protected static ObservableCollection<Employee> _employees;
        //protected static int selectedCar;
        protected static Client previousClient;
        protected static Employee previousEmployee;

        public EmployeesView()
        {
            CarRepository.CreateInstance();
            ClientRepository.CreateInstance();
            EmployeeRepository.CreateInstance();
            InitializeComponent();
            _cars = CarRepository.GetRepository();
            _clients = ClientRepository.GetAutoParts();
            _employees = EmployeeRepository.GetAutoParts();
            clientList.ItemsSource = _employees;
        }

        private void partsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*Car selectedCar = (Car)clientList.SelectedItem;
            if (selectedCar != null)
            {
                Client selectedCarOwner = ClientRepository.GetClientById(selectedCar.OwnerId);
                clientList.Items.Remove(previousClient);
                clientList.Items.Add(selectedCarOwner);
                previousClient = selectedCarOwner;
            }
            Employee selectedCarEmployee = EmployeeRepository.GetClientById(selectedCar.OwnerId);
            employeeList.Items.Remove(previousEmployee);
            employeeList.Items.Add(selectedCarEmployee);
            previousEmployee = selectedCarEmployee;*/
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (clientList.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали работника для удаления!");
            }
            else
            {
                int test = Convert.ToInt32(clientList.SelectedItem.GetType().GetProperty("Id").GetValue(clientList.SelectedItem));
                var d = EmployeeRepository.GetClientById(test);
                string message = "Вы точно хотите удалить из списка работника " + d.Surname.ToString() + " " + d.Name.ToString() + " " + d.Middlename.ToString() + "?";
                string caption = "Уведомление";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show(message, caption, buttons, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    EmployeeRepository.DeleteElement(test);
                }
            }
            clientList.Items.Refresh();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (clientList.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали элемент для удаления!");
            }
            else
            {
                int test = Convert.ToInt32(clientList.SelectedItem.GetType().GetProperty("Id").GetValue(clientList.SelectedItem));
                PersonEditWindow win = new PersonEditWindow(2, test, (Employee)clientList.SelectedItem);
                win.ShowDialog();
                clientList.Items.Refresh();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            PersonAddWindow win = new PersonAddWindow(2);
            win.ShowDialog();
            clientList.Items.Refresh();
        }

        // Функция выполняет код при закрытии окна
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //AutoPartRepository.Serialize();
        }

        private void BtnMoreInfo(object sender, RoutedEventArgs e)
        {

        }
    }
}
