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
    /// Interaction logic for JobEntry.xaml
    /// </summary>
    public partial class JobEntry : Page
    {
        public JobEntry()
        {
            InitializeComponent();
            canceledMessage.Visibility = Visibility.Hidden;
        }
        




        private void Click_SubmitButton(object sender, RoutedEventArgs e)
        {
            SQLConnections sqlconnection = new SQLConnections();
           
            // get comobox
            var comboBoxRating = boxRating as ComboBox;
            var comboBoxPosition = boxPosition as ComboBox;
            var comboBoxLocation = boxLocation as ComboBox;
            
            //set selected value to string
            string ratingSelected = comboBoxRating.SelectedItem as string;
            string positionSelected = comboBoxPosition.SelectedItem as string;
            string locationSelected = comboBoxLocation.SelectedItem as string;
            
            // get Indentity value for sql query
            int ratingValue = AssignRatingValue(ratingSelected);
            //int positionValue = 0;
            //if (!(positionSelected is null))
            //{
            //    positionValue = sqlconnection.FindPositionID(positionSelected);
            //}

            //Assign properties in static class
            JobInfo.CompanyName = txtCompanyName.Text;
            JobInfo.Position = positionSelected;
            JobInfo.Location = locationSelected;
            JobInfo.SalaryRange = txtSalary.Text;
            JobInfo.CEOName = txtCEO.Text;
            JobInfo.MissionStatement = txtMissionStatement.Text;
            JobInfo.Rating = ratingValue;
            JobInfo.Benefits = txtBenefits.Text;
            JobInfo.Comments = txtComments.Text;
            JobInfo.Recruiter = txtRecruiterName.Text;
            JobInfo.JobLink = txtJobLink.Text;
            
            // Validation
            if (ratingValue == 5)
            {
                MessageBox.Show("You must select a Rating in order to submit the job information", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtCompanyName.Text) || positionSelected is null || locationSelected is null)
            {
                MessageBox.Show("Please make sure Company Name, Postion, and Location are all filled out.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Insert to Jobs table in database
            sqlconnection.NewJob();
            MessageBoxResult result = MessageBox.Show("Submission complete!", "Success!", MessageBoxButton.OKCancel, MessageBoxImage.None);
            if (result == MessageBoxResult.OK)
            {
                //clear text boxes
                txtBenefits.Clear();
                txtCEO.Clear();
                txtComments.Clear();
                txtCompanyName.Clear();
                txtJobLink.Clear();
                txtMissionStatement.Clear();
                txtRecruiterEmail.Clear();
                txtRecruiterName.Clear();
                txtRecruiterPhoneNumber.Clear();
                txtSalary.Clear();
                boxLocation.SelectedItem = null;
                boxPosition.SelectedItem = null;
                boxGenderBox.SelectedItem = null;
                boxRating.SelectedItem = null;
                canceledMessage.Visibility = Visibility.Hidden;
            }
            else
            {
                sqlconnection.DeleteLastJobRecord();
                canceledMessage.Visibility = Visibility.Visible;
            }


        }
        
        private void PositionBox_Changed(object sender, SelectionChangedEventArgs e)
        {
            bool addPosition = false;
            var comboBox = sender as ComboBox;
            string selection = comboBox.SelectedItem as string;
            addPosition = CheckPositionSelected(selection);
            if(addPosition == true)
            {
                AddPositionWindow addPositionWindow = new AddPositionWindow();
                addPositionWindow.Show();
            }

        }

        private void PositionBox_Loaded(object sender, EventArgs e)
        {
            SQLConnections sqlConnection = new SQLConnections();

            var comboBox = sender as ComboBox;
            List<string> positions = new List<string>();
            positions = sqlConnection.FillComboBoxFromDatabase("SELECT JobTitle FROM [dbo].[Position]");
            positions.Add("Add Position");
            comboBox.ItemsSource = positions;


        }
        private void LocationBox_Changed(object sender, SelectionChangedEventArgs e)
        {
            bool addLocation = false;
            var comboBox = sender as ComboBox;
            string selection = comboBox.SelectedItem as string;
            addLocation = CheckPositionSelected(selection);
            if (addLocation == true)
            {
                MessageBoxResult result = MessageBox.Show("You are about to navigate away from this page. All input will have to be re-entered after adding a location", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new System.Uri("LocationEntry.xaml", UriKind.RelativeOrAbsolute));
                }
                else
                    return;
            }

        }

        private void LocationBox_Loaded(object sender, EventArgs e)
        {
            SQLConnections sqlConnection = new SQLConnections();

            var comboBox = sender as ComboBox;
            List<string> positions = new List<string>();
            positions = sqlConnection.FillComboBoxFromDatabase("SELECT City FROM [dbo].[Location]");
            positions.Add("Add Location");
            comboBox.ItemsSource = positions;


        }

        private void RatingBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> ratings = new List<string>();
            ratings.Add("Overqualified");
            ratings.Add("Qualified");
            ratings.Add("Challenging");
            ratings.Add("Need more to apply");

            // get combobox ref
            var comboBox = sender as ComboBox;

            // assign itemsource to list above
            comboBox.ItemsSource = ratings;

            // make first item selected
            //comboBox.SelectedIndex = 0;

        }
        private int AssignRatingValue(string rating)
        {
                if (rating == "Overqualified")
                {
                    return 1;
                }
                if (rating == "Qualified")
                {
                    return 2;
                }
                if (rating == "Challenging")
                {
                    return 3;
                }
                if (rating == "Need more to apply")
                {
                    return 4;
                }
                else
                    return 5;
        }

       
        private bool CheckPositionSelected(string boxSelection)
        {
            if (boxSelection == "Add Position")
            {
                return true;
            }
            if (boxSelection == "Add Location")
            {
                return true;
            }
            else
                return false;
        }
    }
}
