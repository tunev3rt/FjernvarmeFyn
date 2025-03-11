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
using System.Windows.Shapes;

namespace FjernvarmeFynLogin.View
{
    /// <summary>
    /// Interaction logic for CreateTicketWindow.xaml
    /// </summary>
    public partial class CreateTicketWindow : Window
    {
        public CreateTicketWindow()
        {
            InitializeComponent();
        }

     

        private void bugBtn_Click(object sender, RoutedEventArgs e)
        {
            SubmitBugWindow submitBugWindow = new SubmitBugWindow();
            {
                submitBugWindow.ShowDialog();
            }
        }

        private void wishBtn_Click(object sender, RoutedEventArgs e)
        {
            SubmitWishWindow submitWishWindow = new SubmitWishWindow();
            {
                submitWishWindow.ShowDialog();
            }
        }

        private void featureBtn_Click(object sender, RoutedEventArgs e)
        {
            SubmitFeatureWindow submitFeatureWindow = new SubmitFeatureWindow();
            {
                submitFeatureWindow.ShowDialog();
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
