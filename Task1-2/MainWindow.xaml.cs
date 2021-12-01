using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task1_2.Context;
using Task1_2.Models;

namespace Task1_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new ApplicationContext();
            _context.Organisations.Load();
            _context.Contracts.Load();
            DataGrid_Organisation.ItemsSource = _context.Organisations.Local.ToBindingList();
            Datagrid_Contract.ItemsSource = _context.Contracts.Local.ToBindingList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _context.Dispose();
        }

        private void DataGrid_Organisation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Organisation index = DataGrid_Organisation.SelectedItem as Organisation;
            //Datagrid_Contract.ItemsSource = _context.Contracts.Local.ToBindingList().Where(a => a.OrganisationId == index.Id);
        }

        private void Button_AddOrganisation_Click(object sender, RoutedEventArgs e)
        {
            Organisation organisation = new Organisation{ Name = TextBox_NameOrganisation.Text, Address = TextBox_AddresOrganisation.Text};
            _context.Organisations.Add(organisation);
            _context.SaveChanges();
        }

        private void Button_DeleteOrganistion_Click(object sender, RoutedEventArgs e)
        {
            Organisation index = DataGrid_Organisation.SelectedItem as Organisation;
            _context.Organisations.Remove(
                _context.Organisations.Where(a =>a.Name == index.Name).FirstOrDefault());

            _context.SaveChanges();
        }

        private void TextBox_Sum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_AddContract_Click(object sender, RoutedEventArgs e)
        {
            Organisation index = DataGrid_Organisation.SelectedItem as Organisation;
            index = _context.Organisations.Find(index.Id);
            index.Contracts.Add(new Contract { Sum = Convert.ToInt32(TextBox_SumContract.Text), Date = (DateTime)DatePicker_DateContract.SelectedDate });
            _context.SaveChanges();
            //Datagrid_Contract.ItemsSource = _context.Contracts.Local.ToBindingList().Where(a => a.OrganisationId == index.Id);
        }

        private void Button_DeleteContract_Click(object sender, RoutedEventArgs e)
        {
            Organisation index = DataGrid_Organisation.SelectedItem as Organisation;
            Contract contract = Datagrid_Contract.SelectedItem as Contract;
            _context.Contracts.Remove(contract);
            _context.SaveChanges();
            //Datagrid_Contract.ItemsSource = _context.Contracts.Local.ToBindingList().Where(a => a.OrganisationId == index.Id);

        }
    }
}
