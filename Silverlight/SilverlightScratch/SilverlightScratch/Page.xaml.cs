using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightScratch {
    public partial class Page : UserControl {
        public Page() {
            InitializeComponent();
        }
        private bool isClicked = false;
        private void testButton_Click(object sender, RoutedEventArgs e) {
            if (isClicked) {
                testButton.Content = "You pushed Me!";
                isClicked = false;
            } else {
                testButton.Content += " ..";
            }
        }
    }
}
