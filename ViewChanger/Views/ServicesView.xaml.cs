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
    /// Логика взаимодействия для ServicesView.xaml
    /// </summary>
    public partial class ServicesView : UserControl
    {
        private void clientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        protected static ObservableCollection<Service> _services;
        

        public ServicesView()
        {
            ServiceRepository.CreateInstance();
            _services = ServiceRepository.GetAutoParts();
            InitializeComponent();
            servicesList.ItemsSource = _services;
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
            if (servicesList.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали услугу для удаления!");
            }
            else
            {
                int test = Convert.ToInt32(servicesList.SelectedItem.GetType().GetProperty("Id").GetValue(servicesList.SelectedItem));
                var d = ServiceRepository.GetClientById(test);
                string message = "Вы точно хотите удалить из списка услугу " + d.Title.ToString() + "?";
                string caption = "Уведомление";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show(message, caption, buttons, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ServiceRepository.DeleteElement(test);
                }
            }
            servicesList.Items.Refresh();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (servicesList.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали элемент для удаления!");
            }
            else
            {
                int test = Convert.ToInt32(servicesList.SelectedItem.GetType().GetProperty("Id").GetValue(servicesList.SelectedItem));
                ServiceEditWindow win = new ServiceEditWindow((Service)servicesList.SelectedItem);
                win.ShowDialog();
                servicesList.Items.Refresh();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ServiceAddWindow win = new ServiceAddWindow();
            win.ShowDialog();
            servicesList.Items.Refresh();
        }

        // Функция выполняет код при закрытии окна
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //AutoPartRepository.Serialize();
        }

        private void BtnMoreInfo(object sender, RoutedEventArgs e)
        {

        }

        private void servicesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
