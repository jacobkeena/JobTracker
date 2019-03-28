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
using JobSearchLibrary;

namespace JobTrackerBeta
{
    /// <summary>
    /// Interaction logic for AddPositionWindow.xaml
    /// </summary>
    public partial class AddPositionWindow : Window
    {
        public AddPositionWindow()
        {
            InitializeComponent();
        }

        private void AddPosition_Clicked(object sender, RoutedEventArgs e)
        {
            SQLConnections sqlConnections = new SQLConnections();
            string newPosition = NewPosition.Text;
            sqlConnections.AddPosition(newPosition);
            int position = sqlConnections.FindPositionID(newPosition);
            this.Close();
            //@@identityscope
        }
    }
}
