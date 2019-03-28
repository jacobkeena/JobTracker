using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JobSearchLibrary
{
    public class SQLConnections
    {
        public string strConn = @"Data Source=DESKTOP-CFGVQLT\SQLEXPRESS01;Database=JobSearch;integrated security=SSPI;MultipleActiveResultSets=true;";

        #region Insert Query Statements
        public void NewJob()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strConn))
                {
                    SqlCommand sqlComm = new SqlCommand("INSERT INTO [Jobs] (CompanyName, PositionID, LocationID, SalaryRange, RatingID, CEOName,MissionStatement,Benefits,Comments,RecruiterID,JobLink)" +
                " VALUES (@CompanyName, (SELECT PositionID FROM Position WHERE JobTitle = @Position), (SELECT LocationID FROM Location WHERE City = @Location), @SalaryRange,@Rating, @CEOName,@MissionStatement,@Benefits,@Comments,(SELECT RecruiterID FROM Recruiters WHERE RecruiterID = @Recruiter),@JobLink)", sqlConnection);

                    sqlComm.Parameters.AddWithValue("@CompanyName", System.Data.SqlDbType.NVarChar);
                    sqlComm.Parameters.AddWithValue("@Position", System.Data.SqlDbType.Int);
                    sqlComm.Parameters.AddWithValue("@Location", System.Data.SqlDbType.Int);
                    sqlComm.Parameters.AddWithValue("@SalaryRange", System.Data.SqlDbType.NVarChar);
                    sqlComm.Parameters.AddWithValue("@Rating", System.Data.SqlDbType.NVarChar);
                    sqlComm.Parameters.AddWithValue("@CEOName", System.Data.SqlDbType.NVarChar);
                    sqlComm.Parameters.AddWithValue("@MissionStatement", System.Data.SqlDbType.NVarChar);
                    sqlComm.Parameters.AddWithValue("@Benefits", System.Data.SqlDbType.NVarChar);
                    sqlComm.Parameters.AddWithValue("@Comments", System.Data.SqlDbType.NVarChar);
                    sqlComm.Parameters.AddWithValue("@Recruiter", System.Data.SqlDbType.NVarChar);
                    sqlComm.Parameters.AddWithValue("@JobLink", System.Data.SqlDbType.NVarChar);

                    sqlComm.Parameters["@CompanyName"].Value = JobInfo.CompanyName;
                    sqlComm.Parameters["@Position"].Value = JobInfo.Position;
                    sqlComm.Parameters["@Location"].Value = JobInfo.Location;
                    sqlComm.Parameters["@SalaryRange"].Value = JobInfo.SalaryRange;
                    sqlComm.Parameters["@Rating"].Value = JobInfo.Rating;
                    sqlComm.Parameters["@CEOName"].Value = JobInfo.CEOName;
                    sqlComm.Parameters["@MissionStatement"].Value = JobInfo.MissionStatement;
                    sqlComm.Parameters["@Benefits"].Value = JobInfo.Benefits;
                    sqlComm.Parameters["@Comments"].Value = JobInfo.Comments;
                    sqlComm.Parameters["@Recruiter"].Value = JobInfo.Recruiter;
                    sqlComm.Parameters["@JobLink"].Value = JobInfo.JobLink;

                    sqlComm.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlComm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AddLocation()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strConn))
                {
                    SqlCommand sqlComm = new SqlCommand("INSERT INTO Location VALUES (@City,@StateID,@Rating,@Notes)", sqlConnection);

                    sqlComm.Parameters.AddWithValue("@City", System.Data.SqlDbType.NVarChar);
                    sqlComm.Parameters.AddWithValue("@StateID", System.Data.SqlDbType.Int);
                    sqlComm.Parameters.AddWithValue("@Rating", System.Data.SqlDbType.Int);
                    sqlComm.Parameters.AddWithValue("@Notes", System.Data.SqlDbType.NVarChar);

                    sqlComm.Parameters["@City"].Value = LocationInfo.City;
                    sqlComm.Parameters["@StateID"].Value = LocationInfo.StateID;
                    sqlComm.Parameters["@Rating"].Value = LocationInfo.Rating;
                    sqlComm.Parameters["@Notes"].Value = LocationInfo.Notes;

                    sqlComm.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlComm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void AddPosition(string newPosition)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strConn))
                {
                    SqlCommand sqlComm = new SqlCommand("INSERT INTO Position VALUES (@Position)", sqlConnection);

                    sqlComm.Parameters.AddWithValue("@Position", System.Data.SqlDbType.NVarChar);

                    sqlComm.Parameters["@Position"].Value = newPosition;


                    sqlComm.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlComm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Collect list data
        public List<string> FillComboBoxFromDatabase(string sqlQuery)
        {
            try
            {
                List<string> columnData = new List<string>();
                using (SqlConnection sqlConnection = new SqlConnection(strConn))
                {
                    SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConnection);

                    sqlComm.Connection = sqlConnection;
                    sqlConnection.Open();
                    using (SqlDataReader reader = sqlComm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnData.Add(reader.GetString(0));
                        }
                    }
                }
                return columnData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion


        public int FindPositionID(string position)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strConn))
                {
                    SqlCommand sqlComm = new SqlCommand("SELECT positionID FROM Position where JobTitle = @Position", sqlConnection);

                    sqlComm.Parameters.AddWithValue("@Position", System.Data.SqlDbType.NVarChar);

                    sqlComm.Parameters["@Position"].Value = position;


                    sqlComm.Connection = sqlConnection;
                    sqlConnection.Open();
                    var x = sqlComm.ExecuteScalar();
                    int positionID = 0;
                    if (x != null)
                    { positionID = (int)x; }


                    return positionID;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region Delete records from database
        public void DeleteLastJobRecord()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strConn))
                {
                    SqlCommand sqlComm = new SqlCommand("DELETE FROM Jobs WHERE CompanyID =(SELECT MAX(CompanyID) FROM Jobs)", sqlConnection);
                    sqlComm.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlComm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void DeleteLastLocationRecord()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strConn))
                {
                    SqlCommand sqlComm = new SqlCommand("DELETE FROM Location WHERE LocationID =(SELECT MAX(LocationID) FROM Location)", sqlConnection);
                    sqlComm.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlComm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
