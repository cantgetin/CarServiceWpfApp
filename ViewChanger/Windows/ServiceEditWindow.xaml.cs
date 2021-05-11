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
    /// Логика взаимодействия для ServiceEditWindow.xaml
    /// </summary>
    public partial class ServiceEditWindow : Window
    {
        protected Service _editedService;
        //protected int _editedIndex;
        public ServiceEditWindow(Service d)
        {
            InitializeComponent();
            _editedService = d;
            textBoxTitle.Text = d.Title;
            textBoxPrice.Text = d.Price.ToString();
            textBoxHours.Text = d.HourDuration.ToString();
        }

        private void Btn_Accept(object sender, RoutedEventArgs e)
        {
            _editedService.Title = textBoxTitle.Text;
            _editedService.Price = int.Parse(textBoxPrice.Text);
            _editedService.HourDuration = double.Parse(textBoxHours.Text);
            ServiceRepository.ChangeElement(_editedService.Id,_editedService);
            this.Close();
        }
    }
}
