﻿using Microsoft.EntityFrameworkCore;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Page9.xaml
    /// </summary>
    public partial class Page9 : Page
    {
        public ObservableCollection<Task> CollectionTasks = new(Service.db.Tasks.Include(x => x.Status));
        public Page9()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tblog.Text == null)
            {
                MessageBox.Show("Введите логин, по которому хотите искать");
            }
            if (tblog.Text != null)
            {
                CollectionTasks = new(Service.db.Tasks.Where(x => x.Creator.Login == tblog.Text));
                lbox5.ItemsSource = CollectionTasks; 
            }
        }
    }
}