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
using JobSearchLibrary;

namespace JobTrackerBeta
{
    /// <summary>
    /// Interaction logic for ViewJobs.xaml
    /// </summary>
    public partial class ViewJobs : Page
    {
        public ViewJobs()
        {
            InitializeComponent();
            SQLConnections sqlConnection = new SQLConnections();
            List<string> items = new List<string>();
            items = sqlConnection.FillComboBoxFromDatabase("SELECT CompanyName FROM Jobs ORDER BY CompanyID DESC");
            lbDisplayJobs.ItemsSource = items;
        }

    }
    //public class CompanyNameItem
    //{
    //    public string CompanyName { get; set; }

    //}
}
