﻿using System;
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
using FlatPurchase_Agent.ViewModels;

namespace FlatPurchase_Agent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new FlatPurchaseViewModel();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FlatPurchaseViewModel vm = DataContext as FlatPurchaseViewModel;

                if(vm.Register())
                {
                    MessageBox.Show("Нову заявку на продаж квартири додано в базу");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
