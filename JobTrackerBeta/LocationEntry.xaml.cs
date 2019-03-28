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
    /// Interaction logic for LocationEntry.xaml
    /// </summary>
    public partial class LocationEntry : Page
    {
        public LocationEntry()
        {
            InitializeComponent();
            canceledMessage.Visibility = Visibility.Hidden;
            canvasPanel.Visibility = Visibility.Visible;
        }
        List<string> states = new List<string>();

        private void Click_SubmitButton(object sender, RoutedEventArgs e)
        {
            //get combobox
            var comboBoxState = boxState as ComboBox;

            //set selected value to string
            string stateSelected = comboBoxState.SelectedItem as string;

            //get int value for stateID
            int stateIDValue = GetStateID(stateSelected);

            try
            {
                LocationInfo.City = txtCity.Text;
                LocationInfo.StateID = stateIDValue;
                LocationInfo.Rating = int.Parse(txtRating.Text);
                LocationInfo.Notes = txtNotes.Text;
            }
            catch (FormatException)
            {
                MessageBox.Show("Rating must be a number", "Error", MessageBoxButton.OK, MessageBoxImage.None);
                return;
            }
            if(string.IsNullOrEmpty(txtCity.Text) || string.IsNullOrEmpty(txtNotes.Text) || string.IsNullOrEmpty(txtRating.Text) || stateSelected is null)
            {
                MessageBox.Show("You must have City, State, and Rating all filled out in order to submit", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SQLConnections sqlConnection = new SQLConnections();
            sqlConnection.AddLocation();
            MessageBoxResult result = MessageBox.Show("Location added!", "Success", MessageBoxButton.OKCancel, MessageBoxImage.None);
            if (result == MessageBoxResult.OK)
            {
                //clear text boxes
                canceledMessage.Visibility = Visibility.Hidden;
                txtCity.Clear();
                boxState.SelectedItem = null;
                txtRating.Clear();
                txtNotes.Clear();
                boxState.SelectedItem = null;
            }
            else
            {
                sqlConnection.DeleteLastLocationRecord();
                canceledMessage.Visibility = Visibility.Visible;
            }
        }

        public void boxState_Loaded(object sender, RoutedEventArgs e)
        {
            SQLConnections sqlConnection = new SQLConnections();

            var comboBox = boxState as ComboBox;
            states = sqlConnection.FillComboBoxFromDatabase("SELECT State FROM [dbo].[States]");
            comboBox.ItemsSource = states;

        }

        /*
         * Iterates through list of states and assigns ID. 
         * Fixed IDs so this is an attempt to save time and avoid making an 
         * unnessesary connection to the database
         */
        public int GetStateID(string stateName)
        {
            int stateID = 0;
            for (int i = 0; i <= 50; i++)
            {
                if (stateName == states[i])
                {
                    stateID = i +1;
                    return stateID;
                }
            }
                    return -1;
        }

        private void RatingBox_Clicked(object sender, DependencyPropertyChangedEventArgs e)
        {
            canvasPanel.Visibility = Visibility.Hidden;

        }

        private void RatingBox_Unselected(object sender, RoutedEventArgs e)
        {
            canvasPanel.Visibility = Visibility.Visible;

        }
    }
}
