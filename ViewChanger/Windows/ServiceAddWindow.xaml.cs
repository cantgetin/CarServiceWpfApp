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
    /// Логика взаимодействия для ServiceAddWindow.xaml
    /// </summary>
    public partial class ServiceAddWindow : Window
    {
        protected Service _addedService;
        //protected int _editedIndex;
        public ServiceAddWindow()
        {
            InitializeComponent();
            _addedService = new Service();
        }

        private void Btn_Accept(object sender, RoutedEventArgs e)
        {
            _addedService.Title = textBoxTitle.Text;
            _addedService.Price = int.Parse(textBoxPrice.Text);
            _addedService.HourDuration = double.Parse(textBoxHours.Text);
            ServiceRepository.AddPart(_addedService);
            this.Close();
        }
    }
}
